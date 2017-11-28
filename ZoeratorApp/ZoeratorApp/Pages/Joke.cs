using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZoeratorApp.Pages
{
    public class Joke
    {
        public string key { get; set; }
        public string body { get; set; }
        public string title { get; set; }
    }

    public class JokeDataModel
    {
        public List<Joke> jokeList;

        /// <summary>
        /// Sobrecarga do construtor para adicionar os valores ao List
        /// </summary>
        public JokeDataModel(string title, string body, string key)
        {
            jokeList = new List<Joke>();
            jokeList.Add(new Joke()
            {
                body = body,
                title = title,
                key = key
            });
        }

        public JokeDataModel()
        {
        }
    }
}
