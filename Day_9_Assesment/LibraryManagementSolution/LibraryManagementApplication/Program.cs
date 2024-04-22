using LibraryManagementBLLib;
using LibraryManagementModelLib;

namespace LibraryManagementApplication
{
    
    internal class Program
    {
        BookService BookMethods = new BookBL();
        PatronService PatronMethods = new PatronBL();
        BorrowingBl BorrowingMehtods = new BorrowingBl();
        int HandlingIntegerInput()
        {
            int num;
            while(int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("**Please Enter a Vaild Intger**");
            }
            return num;
        }
        float HandlingFloatInput()
        {
            float num;
            while (float.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("**Please Enter a Vaild Decimal**");
            }
            return num;
        }
        string HandlingPhoneNumber()
        {
            string str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please Enter a Valid Phone Number");
                }
            } while (string.IsNullOrEmpty(str) || str.Length != 10);
            return str;
        }
        string HandlingStringInput(string Msg)
        {
            string? str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine(Msg);
                }
            }while(string.IsNullOrEmpty(str));
            return str;
        }
        DateOnly HandlingDateOnlyInput()
        {
            DateTime date;
            string input;

            do
            {
                
                input = Console.ReadLine();
            } while (!DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date));

            DateOnly dateOnly = new DateOnly(date.Year, date.Month, date.Day);
            return dateOnly;
        }
        Book TakeBookDetailsFromConsole()
        {
            Console.WriteLine("Enter Book Title");
            string title = HandlingStringInput("Please Enter a Valid  Title");
            Console.WriteLine("Enter Book Author Name : ");
            string author = HandlingStringInput("Please Enter a Vaild Name");
            Console.WriteLine("Enter Book Publication Date (YYYY-MM-DD) format ");
            DateOnly publicationdate = HandlingDateOnlyInput();
            int id = BookMethods.Count() + 1;
            Book book = new Book(id, title, author, publicationdate);
            return book;

        }
        Patron TakePatronDetailsFromConsole()
        {
            Console.WriteLine("Enter Patron Name");
            string name = HandlingStringInput("Please Enter a Valid  Title");
            Console.WriteLine("Enter Phone Number : ");
            string phoneNumber = HandlingPhoneNumber();
            Console.WriteLine("Enter Adress");
            string publicationdate = HandlingStringInput("Please Enter a Valid Adress");
            int id = PatronMethods.Count() + 1;
            Patron patron = new Patron(id, name, phoneNumber, publicationdate);
            return patron;
        }

        void PrintMenu()
        {
            Console.WriteLine("-------Library Management------------");
            Console.WriteLine("11 Show All Books ");
            Console.WriteLine("12 Add a new Book");
            Console.WriteLine("13 Edit Book Details");
            Console.WriteLine("14 Delete a Book");
            Console.WriteLine("21 Show All Users");
            Console.WriteLine("22 Add User");
            Console.WriteLine("23 Upate User");
            Console.WriteLine("24 Delete Uer");
            Console.WriteLine("31 Borrow Book");
            Console.WriteLine("32 Show All Req");
            Console.WriteLine("41 Return Book");
            Console.WriteLine("0 To exit");
            Console.WriteLine("-------------------------------------");
        }
        void ShowAllBooks()
        {
            
            try
            {
                List<Book> books = BookMethods.GetAllBook();
                for (int i = 0; i < books.Count; i++)
                {
                    Console.WriteLine(books[i]);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return;
        }
        void AddBooks()
        {
            try
            {
                Console.WriteLine("Please Enter Book Details\n");
                
                Book response = BookMethods.AddBook(TakeBookDetailsFromConsole());
                Console.WriteLine("Book Sucesfully Added");
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message + "Error Msg");
            }
            return;
           
        }
        void UpdateBookDetails()
        {
            Console.WriteLine("Please Enter Id of Book To be Updated : " );
            int id = HandlingIntegerInput();
            Console.WriteLine("Enter the which Feild to Update");
            string feild= HandlingStringInput("Please Enter a Valid string");
            Console.WriteLine(feild);
            if (feild == "Title" )
            {
                try
                {
                    Console.WriteLine("Please Enter New Book Title ");
                    string title = HandlingStringInput("Please Enter a vaild Tittle");
                    var response =  BookMethods.ChangeBookTitle(title, id);
                    Console.WriteLine("Book Updated Sucesfully\n");
                    Console.WriteLine(response);
                } catch (NullReferenceException ex) 
                {
                    Console.WriteLine(ex.Message);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;

            }
            Console.WriteLine("There is No Such Feild");

        }
        void DeleteBook()
        {
            Console.WriteLine("Please Enter id of book to be Deleted");
            int id = HandlingIntegerInput();
            try
            {
                bool response = BookMethods.DeleteBook(id);
                if (response) { Console.WriteLine("Book sucessfully Delted"); 
            }
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void ShowAllUsers()
        {
            try
            {
                List<Patron> users = PatronMethods.GetAllPatrons();
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(users[i]);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return;

        }
        void AddUser()
        {
            try
            {
                Console.WriteLine("Please Enter User Details\n");

                Patron response = PatronMethods.AddPatron(TakePatronDetailsFromConsole());
                Console.WriteLine("User Sucesfully Added");
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;

        }
        void UpateUser()
        {
            Console.WriteLine("Please Enter Id of User To be Updated : ");
            int id = HandlingIntegerInput();
            Console.WriteLine("Enter the which Feild to Update");
            string feild = HandlingStringInput("Please Enter a Valid string");
            Console.WriteLine(feild);
            if (feild == "Name")
            {
                try
                {
                    Console.WriteLine("Please Enter New Name of User ");
                    string name = HandlingStringInput("Please Enter a vaild name");
                    var response = PatronMethods.ChangePatronName(name, id);
                    Console.WriteLine("User Updated Sucesfully\n");
                    Console.WriteLine(response);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return;

            }
            Console.WriteLine("There is No Such Feild");
        }
        void DeleteUser()
        {
            Console.WriteLine("Please Enter id of User to be Deleted");
            int id = HandlingIntegerInput();
            try
            {
                bool response = PatronMethods.DeletePatron(id);
                if (response)
                {
                    Console.WriteLine("User sucessfully Delted");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void BorrowBook()
        {
            try
            {
                Console.WriteLine("Please Enter id of the book to borrow");
                int bookId = HandlingIntegerInput();
                Console.WriteLine("Please Enter User Id who is borrowing");
                int userId = HandlingIntegerInput();
                Book book = BookMethods.GetBookbyId(bookId);
                if(book.Availability == "Booked") { Console.WriteLine("The Book isAlready Booked"); return; }
                Patron patron = PatronMethods.GetPatronbyId(userId);
                int id = BorrowingMehtods.Count() + 1;
                Console.WriteLine("Please Enter Borrowing Date : ");
                DateOnly currentDate = HandlingDateOnlyInput();
                Console.WriteLine("Enter Returning Date (YYYY-MM-DD) format");
                DateOnly dueDate = HandlingDateOnlyInput();
                if (dueDate < currentDate) { Console.WriteLine("Please Check the due date and retry"); return; }
                Book_Borrowing Request = new Book_Borrowing(id, patron, book, currentDate, dueDate);
                bool raised = BorrowingMehtods.BorrowingRequest(Request);
                if (raised) { Console.WriteLine("Borrow Request Added Sucesfully"); }
            } catch (NullReferenceException ex) { Console.WriteLine(ex.Message); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        void ReturnBook()
        {
            Console.WriteLine("Please Enter Borrow Req Id ");
            int id = HandlingIntegerInput();
            Book_Borrowing req = BorrowingMehtods.GetReqById(id);
            Console.WriteLine("Please Enter the Returning Date in (YYYY-MM-DD) format ");
            req.ReturningDate = DateOnly.FromDateTime(DateTime.Now.Date);
            if(req.ReturningDate < req.BorrowingDate) { Console.WriteLine("Please Check the Returnind Date and retry");return; }
            double Fees = BorrowingMehtods.EndRequest(req);
            Console.WriteLine($"The duefee to be paid : {Fees} ");
            return;
        }
        void ShowAllRequest()
        {
            try
            {
                List<Book_Borrowing> requests = BorrowingMehtods.GetAllRequest();
                for (int i = 0; i < requests.Count; i++)
                {
                    Console.WriteLine(requests[i]);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return;
        }
        void DeleteReq()
        {
            try
            {
                Console.WriteLine("Please Enter Borrow Id req to be deleted");
                int id = HandlingIntegerInput();
                bool response = BorrowingMehtods.Delete(id);
                if (response) { Console.WriteLine("Deleted Sucesfully"); }
            }catch(NullReferenceException ex) { Console.WriteLine(ex.Message); }
            catch(Exception ex) { Console.WriteLine(ex.Message ); } 
        }
        void Menu()
        {
          int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please Enter the Choice");
                choice =HandlingIntegerInput();
                
                switch (choice)
                {
                    case 11:
                        ShowAllBooks();
                        break;
                     case 12:
                        AddBooks();
                        break;
                    case 13:
                        UpdateBookDetails();
                        break;
                    case 14:
                        DeleteBook();
                        break;
                    case 21:
                        ShowAllUsers();
                        break;
                    case 22:
                        AddUser();
                        break;
                    case 23:
                        UpateUser();
                        break;
                    case 24:
                        DeleteUser();
                        break ;
                    case 31:
                        BorrowBook();
                        break;
                    case 32:
                        ShowAllRequest();
                        break;
                    case 41:
                        ReturnBook();
                        break;
                    case 42:
                        DeleteReq();
                        break;
                    default: Console.WriteLine("-----Bye---------"); break;
                }

            }while(choice != 0);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Menu();
        }
    }
}
