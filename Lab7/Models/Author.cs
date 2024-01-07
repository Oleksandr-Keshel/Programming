using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string topic { get; set; }
        public string title { get; set; }
        public string article_text { get; set; }
        public string illustration { get; set; }

        public override string ToString()
        {
            return $"Author's name: {this.name} - Topic: {this.topic} - Title: {this.title}";
        }
    }
}
