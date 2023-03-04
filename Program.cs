using System;

namespace cipher 
{
    class Program
    {
        

        static void Main(string[] args)
        {
            bool restart = true;

            while(restart)
            {
                char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };
                
                Console.WriteLine("Enter the string to encrypt: ");
                string input;
                do
                {
                    input = Console.ReadLine();
                    if (input.Any(c => !char.IsLetter(c)))
                    {
                        Console.WriteLine("Invalid input");
                    }
                } while (input.Any(c => !char.IsLetter(c)));
                // var input = Console.ReadLine();
                
                var inputLowerCase = input.ToLower();
                
                if (input == null || input.Length == 0) 
                {
                    Console.WriteLine("Invalid Input");
                    return;
                }
                Console.WriteLine("Enter the key number you would like to encrypt with:");
                int key = Convert.ToInt32(Console.ReadLine());
                int newKey = key % 26;

                char[] message = inputLowerCase.ToCharArray();
                char[] encrypted = new char[input.Length];

                for (int i = 0; i < message.Length; i++)
                {
                    char letter = message[i];
                    int letterIndex = Array.IndexOf(alphabet, letter);

                    int letterPosition = (letterIndex + newKey) % 26;
                    char letterEncoded = alphabet[letterPosition];
                    encrypted[i] = letterEncoded;
                }            
                string output = String.Join("", encrypted);
                string outputUpperCase = output.ToUpper();

                Console.WriteLine($"Here is the encrypted string: {outputUpperCase}");
                Console.WriteLine("Would you like to restart? [y/n]");
                string? yesNo = Console.ReadLine(); //get the answer

                if(yesNo == "y" || yesNo == "Y" || yesNo == "yes" || yesNo == "Yes") 
                {
                    restart = true;
                }
                else
                {
                    return;  
                }
            }
            restart = false;
        }
    }
}