using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementModelLib
{
    public class Book_Borrowing
    {
        DateOnly returningDate;
        public int Id { get; private set; }
        public Patron Patron { get; set; }
        public Book Book { get; set; }
        public DateOnly BorrowingDate { get; set; }
        public DateOnly DueDate { get; set; }
        public double LateReturnFee;
        
        public DateOnly ReturningDate { get => returningDate; set 
            {
                returningDate = value;
                LateReturnFee = CalculateLateReturnFee(BorrowingDate, DueDate, value);
            } }

        public double CalculateLateReturnFee(DateOnly borrowingDate, DateOnly dueDate, DateOnly returningDate)
        {
            
            if (returningDate > dueDate)
            {
                DateTime borrowingDateTime = new DateTime(borrowingDate.Year, borrowingDate.Month, borrowingDate.Day);
                DateTime dueDateTime = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day);
                DateTime returningDateTime = new DateTime(returningDate.Year, returningDate.Month, returningDate.Day);
                TimeSpan lateDays = returningDateTime - dueDateTime;
                double daysLate = lateDays.TotalDays;
                return daysLate * 20;
            }
            return 0;
        }
        public Book_Borrowing() 
        {
            Id = 0;
            Patron = new Patron();
            Book = new Book();
            BorrowingDate = new DateOnly();
            DueDate = new DateOnly();
            LateReturnFee = 0;
        }
        public Book_Borrowing(int id ,Patron patron, Book book, DateOnly borrowingDate, DateOnly dueDate)
        {
            Id = id;
            Patron = patron;
            Book = book;
            Book.Availability = "Booked";
            BorrowingDate = borrowingDate;
            DueDate = dueDate;
            ReturningDate = new DateOnly();
            LateReturnFee = 0;
        }
        public override string ToString()
        {
            return $"Borrowing Id : {Id} \n Patron Details : {Patron} \n Book Details : ${Book} \n Borrowing Date : {BorrowingDate} \n  Due Date : ${DueDate}";
        }
    }
}
