using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Library
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public List<Book> Books { get; set; }

        public User(int id, string name, string family)
        {
            Id = id;
            Name = name;
            Family = family;
            Books = new List<Book>();
        }
    }
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Age { get; set; }
        public int Count { get; set; }

        public Book(string title, string author, string genre, DateTime age, int count)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Age = age;
            Count = count;
        }
    }
}
