namespace CowBullApplication
{
    internal class Program
    {
        /// <summary>
        /// Takes string input , validates it and loop until you enter the valid string 
        /// </summary>
        /// <returns>String</returns>
        string HandlingStringInput()
        {
            string str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(str) || str?.Length !=4)
                    Console.WriteLine("Please Enter a valid string \n");
            } while (string.IsNullOrWhiteSpace(str) || str.Length != 4);
            return str;

        }
        /// <summary>
        /// Contains Controller logic for CowAndBull game 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="main"></param>
        /// <returns>Integer Array of size 2 where arr[0] represents cow and arr[1] represents bull</returns>
        int[] CountOfCowsAndBulls(string str,  string main)
        {
            int[] cowandbull = new int[2];
            char[] temp = (main.ToCharArray());
            for (int i = 0; i < 4; i++) 
            {
               
                if (str[i] == main[i]) {cowandbull[0]++ ; temp[i] = '#';  continue; }
                int index = Array.IndexOf(temp, str[i]);
                if (index > 0)
                {
                    temp[index] = '#';
                    cowandbull[1]++;
                }
            }
            return cowandbull;
        }
        /// <summary>
        /// Main function 
        /// </summary>
        void CowAndBullGame()
        {
            Console.WriteLine("Please Enter Main Word : ");
            string main = HandlingStringInput(),str;
            do 
            {
                Console.WriteLine("Please Enter the Guess Word: ");
                str = HandlingStringInput();
                int[] CowAndBull = CountOfCowsAndBulls(str, main);
                if (CowAndBull[0] != 4)
                   Console.WriteLine($"Cow : {CowAndBull[0]} , Bull : {CowAndBull[1]}");
                else
                {

                    Console.WriteLine("Congrate You Won");
                    break;
                }
            } while (str != "-1" );
            return;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CowAndBullGame();   
         
        }
    }
}
