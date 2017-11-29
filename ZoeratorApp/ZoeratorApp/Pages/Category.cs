using System;
using System.Collections.Generic;
using System.Text;

namespace ZoeratorApp.Pages
{
    public class Category
    {
        public string key { get; set; }
        public string name { get; set; }
        
    }

    public class CategoryDataModel
    {
        public List<Category> categoryList;

        /// <summary>
        /// Sobrecarga do construtor para adicionar os valores ao List
        /// </summary>
        public CategoryDataModel(string name, string key)
        {
            categoryList = new List<Category>();
            categoryList.Add(new Category()
            {
                name = name,
                key = key
            });
        }

        public CategoryDataModel() { }
    }
}
