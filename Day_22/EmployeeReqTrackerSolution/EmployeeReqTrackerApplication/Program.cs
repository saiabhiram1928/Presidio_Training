using EmployeeReqTrackerBLLibrary;
using EmployeeReqTrackerBLLibrary.Exceptions;
using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Migrations;
namespace EmployeeReqTrackerApplication
{
    
    internal class Program
    {
         bool Islogin = false;
        Employee employee;
        HandlingInput inputhandler = new HandlingInput();
        EmployeeLoginBL employeeLogin = new EmployeeLoginBL();
        RequestBL requestHandler = new RequestBL();
        EmployeeRequest empReqHandler = new EmployeeRequest();  
        SolutionBL solHandler = new SolutionBL();
        FeedbackBl feedbackHandler = new FeedbackBl();

        void PrintMenu()
        {
            Console.WriteLine("-------------Employee Request Tracker-------------");
            if (Islogin == false)
            {
                Console.WriteLine("11) Login");
                Console.WriteLine("12) Register");
            }
            else
            {
                Console.WriteLine("13) Logout");
                Console.WriteLine("14) Profile");
                Console.WriteLine("21) Raise Request");
                Console.WriteLine("22) See All requests Raised by you");
                Console.WriteLine("23) View Solutions For a Request");
                Console.WriteLine("24) Give Comment To Solution");
                Console.WriteLine("25) Give Feedback");
                Console.WriteLine("26) Close Request");
                if (employee.Role.ToLower() == "admin")
                {
                    
                    Console.WriteLine("31) Give Solution");
                    Console.WriteLine("32) View All Requests");
                    Console.WriteLine("33) View Solutions Of Request");
                    Console.WriteLine("34) Show All Solutions");
                    Console.WriteLine("35) View All Requests Of An Employee");
                }
            }
        }
          async Task HandleLoginProcess()
        {
            if (Islogin == true)
            {
                await Console.Out.WriteLineAsync("User Already Loggged In");
                return;
            }

            Console.WriteLine("Enter Id of the Employee : ");
            int id = inputhandler.HandlingIntegerInput();
            Console.WriteLine("Enter Password : ");
            string password = inputhandler.HandlingStringInput("Enter a Valid Password");
            try
            {
               Employee emp =  new Employee() { Password = password , Id = id };
                var res = await employeeLogin.Login(emp);
                if(res == false)
                {
                    await Console.Out.WriteLineAsync("username or password are wrong");
                    return;
                }
                await Console.Out.WriteLineAsync("Login Sucess");
                employee = await employeeLogin.GetDetailsEmployee(emp.Id);
                if(employee != null) Islogin = true;
                return;
            }catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync($"{ex.Message}");
                return;
            }
           
        }
         async Task HandleRegisterProcess()
        {
            await Console.Out.WriteLineAsync("1 ----- hii");
            if (Islogin == true)
            {
                Console.WriteLine("User Already Loggged In");
                return;
            }
            await Console.Out.WriteLineAsync("Please Enter your Name");
            string name = inputhandler.HandlingStringInput("Enter a Valid Name");
            await Console.Out.WriteLineAsync("Please Enter your password");
            string password = inputhandler.HandlingStringInput("Enter a Valid Password");
            var emp =  new Employee() { Name = name, Password = password };
            
            try
            {
                await Console.Out.WriteLineAsync("2)hii");
                var res = await employeeLogin.Register(emp);
                await Console.Out.WriteLineAsync("4 hiii");
                Console.WriteLine(res);
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync($"{ex}");
                return;
            }
        }
        void HandleLogout()
        {
            employee = null;
            Islogin = false;
            return;
        }
        void HandlePrintUserDetails()
        {
            
            Console.WriteLine($"Employee Id : {employee.Id} \n Employee Name: {employee.Name}\n Employee Role : {employee.Role}\n");
        }
        async Task HandleCreateRequest()
        {
             if(Islogin == false)
            {
                Console.WriteLine("Please Login to Create Request");
                return;
            }
            Console.WriteLine("Enter Your Request Message");
            string message = inputhandler.HandlingStringInput("Enter a Valid Message");
            Request req = null;
            try
            {
                 req = await requestHandler.AddRequest(employee, message);
            }catch(DuplicateObjectException dex)
            {
                await Console.Out.WriteLineAsync($"{dex.Message}");
                return;
            }
          if(req == null)
            {
                await Console.Out.WriteLineAsync("Something Went Wrong,Please Try Again");
                return;
            }
            employee.RequestsRaised.Add(req);
            await Console.Out.WriteLineAsync("Request Added SucessFully");
            return;
        }
        async Task HandlePrintAllRequests()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please Login to Create Request");
                return;
            }
            var list = await empReqHandler.AllRequestsRaised(employee.Id);
            if (list== null)
            {
                Console.WriteLine("No Requests Present");
                return;
            }
      
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        async Task PrintSolutionsOfARequest(int id)
        {
            var res = await requestHandler.GetSolutionsOfAReq(id);

            if (res == null)
            {
                await Console.Out.WriteLineAsync("Please check the id and retry");
                return;
            }
            if (res.RequestSolutions == null || res.RequestSolutions.Count == 0)
            {
                await Console.Out.WriteLineAsync("No solutions Provided");
                return;
            }
            var solutions = res.RequestSolutions.ToList();
            foreach (var solution in solutions)
            {
                await Console.Out.WriteLineAsync($"{solution}");
            }

            return;
        }
        async Task HandleViewSolutionsForReqOfAnEmp()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please Login to Create Request");
                return;
            }
            Console.WriteLine("Enter Id of Request");
            int id = inputhandler.HandlingIntegerInput();
            Request req = null;
            try
            {
                 req = await requestHandler.GetRequest(id);
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if(req.RequestRaisedBy != employee.Id)
            {
                Console.WriteLine("Your Dont Have Acess To the Request");
                return;
            }
            await PrintSolutionsOfARequest(req.Id);


        }
        async Task HandleViewSolutionForAReq()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please Login to Create Request");
                return;
            }
            Console.WriteLine("Enter the Req Id");
            int id = inputhandler.HandlingIntegerInput();
            Request req = null;
            try
            {
                req = await requestHandler.GetRequest(id);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            await PrintSolutionsOfARequest(req.Id);
        }
        async Task HandleCommentToSolution()
        {
            if(Islogin == false)
            {
                Console.WriteLine("Please Login to Respond");
                return; 
            }
            Console.WriteLine("Enter Id of the Solution");
            int id = inputhandler.HandlingIntegerInput();
            Console.WriteLine("Please Enter Response ");
            string msg = inputhandler.HandlingStringInput("Please Enter a valid Msg");
            bool res =  false;
            try
            {
                 res = await solHandler.AddCommentToSolution(msg, id);
            }catch(NullReferenceException nex)
            {
                Console.WriteLine(nex.Message);
                return;
            }catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (res == true) Console.WriteLine("Comment Added SucessFully");
            return;
        }
        async Task EndRequest(int empId ,int reqId)
        {
            Console.WriteLine("Do You Want to End a Request , If yes Enter 1 " +
                 "else 0");
            int ok = inputhandler.HandlingIntegerInput();
            if (ok == 0)
            {
                return;
            }
            bool res = false;
            try
            {
                res = await requestHandler.CloseRequest(reqId, empId);
            }
            catch (NullReferenceException nex)
            {
                Console.WriteLine(nex.Message);
                return;
            }
            if (res == false)
            {
                Console.WriteLine("Something Went Wrong");
                return;
            }
           
            Console.WriteLine("Request Closed Sucesfully");
            return;
        }
        async Task HandleCreateFeedback()
        {
            if(Islogin == false)
            {
                Console.WriteLine("Please Login to Give Feedback");
                return;
            }
            Console.WriteLine("Enter Id of the Solution");
            int id = inputhandler.HandlingIntegerInput();
            Solution sol = null;
            try
            {
                sol = await solHandler.GetSolutionById(id);
            }
            catch(NullReferenceException nex) { await Console.Out.WriteLineAsync($"{nex.Message}"); return; }
            await Console.Out.WriteLineAsync("Enter Rating From 0 to 5");
            float rating = inputhandler.HandlingFloatInput();
            await Console.Out.WriteLineAsync("Enter Remarks");
            string remarks = inputhandler.HandlingStringInput("Please Enter a Valid Remarks");
            
            Feedback feedback = new Feedback() { Rating = rating, Remarks = remarks, FeedbackBy = employee.Id, FeedbackDate = DateTime.Now, SolutionId = sol.Id };
            try
            {
                feedback = await feedbackHandler.AddFeedBack(feedback);
            }catch(NullReferenceException nex)
            {
                await Console.Out.WriteLineAsync($"{nex.Message}");
                return;
            }
           
            Console.WriteLine(feedback);
            Console.WriteLine("FeedBack Added SucessFull");
           await EndRequest(sol.SolvedBy, sol.RequestId);
            await solHandler.AceptSolution(sol);
            return;
           
        }
        async Task HandleCloseRequest()
        {
            if(Islogin ==false)
            {
                await Console.Out.WriteLineAsync("Please Login To End request");
                return;
            }
            await Console.Out.WriteLineAsync("Enter Id of the request to be closed");
            int reqid = inputhandler.HandlingIntegerInput();
            await Console.Out.WriteLineAsync("Enter the solution_Id you Liked");
            int solId = inputhandler.HandlingIntegerInput();
            Solution sol = null;
            try
            {
                sol = await solHandler.GetSolutionById(solId);
                
            }catch(NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return;
            }
            await EndRequest(sol.SolvedBy , reqid);
            return;
        }
        async Task HandleCreateSolution()
        {
            if(Islogin == false  )
            {
                Console.WriteLine("Please login ");
                return;
            }
            if(employee.Role.ToLower() != "admin")
            {
                Console.WriteLine("You Dont have previlage for this method");
                return;
            }
          
            Console.WriteLine("Enter the request Id ");
            int reqid = inputhandler.HandlingIntegerInput();
            try
            {
                Request req = await requestHandler.GetRequest(reqid);
                Console.WriteLine(req);
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
           
            bool isReqEnded = false;
            try
            {
                 isReqEnded = await requestHandler.CheckIsReqClosed(reqid);
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (isReqEnded) {  Console.WriteLine("Request Alreday  Ended ");  return; }
            Console.WriteLine("Enter your Solution");
            string solmsg = inputhandler.HandlingStringInput("Enter a Valid Text");
            var res = await solHandler.AddSolution(solmsg, reqid,employee.Id);
            if(res == false) { Console.WriteLine("Something Went Wrong While Adding solution"); return; }
            Console.WriteLine("Solution Added SucessFully");
        }
        async Task HandleShowAllRequest()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please login ");
                return;
            }
            if (employee.Role.ToLower() != "admin")
            {
                Console.WriteLine("You Dont have previlage for this method");
                return;
            }
            var list = await requestHandler.GetAllRequests();
            foreach (Request req in list)
            {
                Console.WriteLine(req);
            }
            return;
        }
        async Task HandleShowAllSolutions()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please login ");
                return;
            }
            if (employee.Role.ToLower() != "admin")
            {
                Console.WriteLine("You Dont have previlage for this method");
                return;
            }
            var list = await solHandler.GetAllSolutions();
            if(list.Count == 0 || list == null)
            {
                Console.WriteLine("No Solutions Present");
                return;
            }

            foreach(Solution solution in list)
            {
                Console.WriteLine(solution);
            }
        }
        async Task HanldeGetAllRequestOfAnEmp()
        {
            if (Islogin == false)
            {
                Console.WriteLine("Please login ");
                return;
            }
            if (employee.Role.ToLower() != "admin")
            {
                Console.WriteLine("You Dont have previlage for this method");
                return;
            }
            Console.WriteLine("Enter the Id of the Employee");
            int id = inputhandler.HandlingIntegerInput();
            
            bool check = await employeeLogin.CheckEmpExists(id);
            if(check == false) { Console.WriteLine("The Employee With Given Id Doesnt exist"); return; }
            var list = await empReqHandler.AllRequestsRaised(id);
            if(list == null || list.Count == 0) {
                Console.WriteLine("No Request Associated With Employee"); return;
            }
            foreach(Request request in list)
            {
                Console.WriteLine(request);
            }
            return;
        }

        async Task Menu()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please Enter the Choice");
                choice = inputhandler.HandlingIntegerInput();

                switch (choice)
                {
                    case 11:
                        await HandleLoginProcess();
                        break;
                    case 12:  
                        await HandleRegisterProcess();
                        break;
                    case 13:
                        HandleLogout();
                        break;
                    case 14:
                        HandlePrintUserDetails();
                        break;
                    case 21:
                        await HandleCreateRequest();
                        break;
                    case 22:
                        await HandlePrintAllRequests();
                        break;
                    case 23:
                       await HandleViewSolutionsForReqOfAnEmp();
                        break;
                    case 24:
                        await HandleCommentToSolution();
                        break;
                    case 25:
                        await HandleCreateFeedback();
                        break;
                    case 26:
                        await HandleCloseRequest();
                        break;
                    case 31:
                        await HandleCreateSolution();
                        break;
                    case 32:
                        await HandleShowAllRequest();
                        break;
                    case 33:
                        await HandleViewSolutionForAReq();
                        break;
                    case 34:
                        await HandleShowAllSolutions();
                        break;
                    case 35:
                        await HanldeGetAllRequestOfAnEmp();
                        break;
                    
                       
                    default:
                        Console.WriteLine("Enter a Valid Choice");
                        break;
                }

            } while (choice != 0);
            Console.WriteLine("-----Bye---------");
        }
        static async Task Main(string[] args)
        {
            await new Program().Menu();
        }
    }
}
