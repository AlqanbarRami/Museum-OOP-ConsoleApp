using System;
using System.Collections.Generic;

namespace Museet.Models
{
	// TODO: Needs further work
		public class Art : Museum
        {
       
        private string title;
        private string description;
        private string author;
        
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Author { get => author; set => author = value; }
        
        
        public Art()
        {

        }
        public Art(string title, string description, string author)
        {
            this.title = title;
            this.description = description;
            this.author = author;

        }

        public override string ToString()
        {
            return "Title: " + Title + " " + " Description: " + Description + " " + " Author: " + Author;
        }
    
}
}
