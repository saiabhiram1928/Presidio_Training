using LinqPracticeApplication.Models;

namespace LinqPracticeApplication
{
    internal class Program
    {
        void practice()
        {
            pubsContext context = new pubsContext();
            var books = context.Sales.GroupBy(s => new { s.OrdNum, s.Qty }, s => s, (idQty, sales) =>
           new
           {
               ordernumber = idQty.OrdNum,
               qunatity = idQty.Qty,
               sales = sales.ToList()
           }); ;
            foreach ( var book in books )
            {
                Console.WriteLine($"{book.ordernumber} : order number");
                Console.WriteLine($"{book.qunatity} : quantity");
                Console.WriteLine($"{book.sales.Count} : count");
            }
           
        }

        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            program.practice();

        }
    }
}
