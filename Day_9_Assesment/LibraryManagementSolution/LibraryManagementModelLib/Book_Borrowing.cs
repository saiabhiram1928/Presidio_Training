using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLib
{
    public class Book_Borrowing
    {
        public int Id { get; private set; }
        public Patron Patron { get; set; }
        public Book Book { get; set; }
        public DateOnly BorrowingDate { get; set; }
        public DateOnly DueDate { get; set; }   
        public Book_Borrowing() 
        {
            Id = 0;
            Patron = new Patron();
            Book = new Book();
            BorrowingDate = new DateOnly();
            DueDate = new DateOnly();
        }
        public Book_Borrowing(int id ,Patron patron, Book book, DateOnly borrowingDate, DateOnly dueDate)
        {
            Id = id;
            Patron = patron;
            Book = book;
            Book.Availability = "Booked";
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
        }
        public override string ToString()
        {
            return $"Borrowing Id : {Id} \n Patron Details : {Patron} \n Book Details : ${Book} \n Borrowing Date : {BorrowingDate} \n  Due Date : ${DueDate}";
        }
    }
}
