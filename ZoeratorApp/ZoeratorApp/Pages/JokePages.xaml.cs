using Android.Widget;
using Firebase.Xamarin.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZoeratorApp.Droid;

namespace ZoeratorApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JokePages : ContentPage
	{
        public JokePages()
        {
            InitializeComponent();
        }

        public JokePages(string key, string title)
        {
            InitializeComponent();

            //Altera o titulo da página
            this.Title = title;

            GetJokes(key);
            //Atribui o método "ShareJoke" ao evento ItemTapped da lista
            JokeList.ItemTapped += ShareJoke;
        }

        /// <summary>
        /// Método para compartilhar as piadas
        /// </summary>
        private async void ShareJoke(object sender, ItemTappedEventArgs e)
        {
            //Atribui o item selecionado ao objeto "Joke"
            Joke joke = (Joke)e.Item;

            //Variável para guardar a opção selecionada
            string opcao = "";
            try
            {
                //Exibe um ActionSheet para o usuário escolher a ação a ser realizada
                var action = await DisplayActionSheet("Compartilhe a piada - " + joke.title, "Cancelar", null, "Compartilhar", "Copiar o texto");
                opcao = action.ToString();
                //Faz um switch entre as opções
                switch (opcao)
                {
                    //Se o usuário clicou em "compartilhar"
                    case "Compartilhar":
                        //Instancia o objeto ShareMessage que será responsável por 
                        //abstrair os métodos de compartilhamento do dispositivo
                        ShareMessage msg = new ShareMessage();
                        //Atribui o titulo
                        msg.Title = joke.title;
                        //Atribui o texto
                        msg.Text = joke.title + Environment.NewLine + joke.body;

                        //Variavel de opções de compartilhamento
                        var opt = new ShareOptions();

                        //Exibe a janela de compartilhamento do Sistema
                        await CrossShare.Current.Share(msg, opt);
                        break;
                    case "Copiar o texto":
                        //Copia o texto da piada para a área de transferência
                        await CrossShare.Current.SetClipboardText(joke.title + Environment.NewLine + joke.body);

                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Método que recupera as piadas de acordo com a categoria selecionada
        /// </summary>
        /// <param name="key">Key da categoria</param>
        async void GetJokes(string key)
        {
            //Instancia o objeto firebase
            var firebase = new FirebaseClient("https://zoerator.firebaseio.com/");

            //atribui o resultado a variavel "jokes"
            var jokes = await firebase
                .Child("piadas/" + key)
                .OnceAsync<Joke>();

            //Instancia o dataModel para popular o listview
            JokeDataModel jokeDataModel = new JokeDataModel();
            jokeDataModel.jokeList = new List<Joke>();

            //Para cada resultado de "jokes", adiciona na lista (jokeList) do dataModel
            foreach (var joke in jokes)
            {
                Joke jokeItem = new Joke();
                jokeItem.body = joke.Object.body;
                jokeItem.title = joke.Object.title;

                jokeDataModel.jokeList.Add(jokeItem);
            }

            //Insere no itemSource da ListView
            JokeList.ItemsSource = jokeDataModel.jokeList;
        }
    }
}