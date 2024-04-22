using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLib
{
    public class Book

    {

        public int Id {  get; private set; }
        public string Title { get;  set; } = string.Empty;
        public string Author { get; set; } = string.Empty ;
        public DateOnly Publication_Date { get; set; }
        public string Availability { get; set; } =string.Empty ;

        public Book()
        {
            Id = 0; 
            Title = string.Empty;
            Author = string.Empty;
            Publication_Date = new DateOnly();
            Availability = "Available";
        }
       public Book(int  id , string title, string author, DateOnly publication_date)
        {
            Id = id;
            Title = title;
            Author = author;
            Publication_Date = publication_date;
            Availability = "Available";
        }
        public override string ToString()
        {
            return $"Id : {Id} \n Title : ${Title} \n Author : {Author} \n Publication Date : {Publication_Date} \n Status : {Availability}";
        }
        public override bool Equals(object? obj)
        {
            Book b1, b2;
            b1 = this;
            b2 = (Book)obj;
            return b1.Id.Equals(b2.Id);
        }


    }
}
