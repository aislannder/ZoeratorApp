using Firebase.Xamarin.Database;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZoeratorApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{

        public HomePage ()
		{
			InitializeComponent ();

            //Altera o titulo da página
            this.Title = "Categorias de Piadas";

            GetCategories();

            //Atribui o método "LoadJokePage" ao evento ItemTapped da lista
            Categorys.ItemTapped += LoadJokePage;
        }

        /// <summary>
        /// Método para abrir as piadas de acordo com a categoria selecionada
        /// </summary>
        async private void LoadJokePage(object sender, ItemTappedEventArgs e)
        {
            //Atribui o item selecionado ao objeto Category
            Category category = (Category)e.Item;
            //Faz a chamada para a proxima página
            await Navigation.PushAsync(new JokePages(category.key, category.name));
        }


        /// <summary>
        /// Método para carregar todas as categorias
        /// </summary>
        public async void GetCategories()
        {

            //Instancia o dataModel para popular o listview
            CategoryDataModel categoryDataModel = new CategoryDataModel();
            categoryDataModel.categoryList = new List<Category>();

            //Instancia o objeto firebase
            var firebase = new FirebaseClient("https://zoerator.firebaseio.com/");
            //atribui o resultado a variavel "jokes"
            var categorys = await firebase
                .Child("categories")
                .OnceAsync<Category>();

            //Para cada resultado de "categorys", adiciona na lista (categoryList) do dataModel
            foreach (var category in categorys)
            {

                Category categoryItem = new Category();
                categoryItem.name = category.Object.name;
                categoryItem.key = category.Key;
                categoryDataModel.categoryList.Add(categoryItem);
            }

            loadIndicator.SetBinding(ActivityIndicator.IsRunningProperty,"IsLoading");
            loadIndicator.BindingContext = Categorys;
            loadIndicator.IsVisible = false;

            //Insere no itemSource da ListView
            Categorys.ItemsSource = categoryDataModel.categoryList;
            firebase = null;
        }
    }
}