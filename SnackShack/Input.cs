using System;

namespace SnackShack
{
    public class Input : InputImplementation
    {
        public override int CustomerWants(string quesiton, string type, string quesiton2)
        {
            return GetUserInput(quesiton, type, quesiton2);
        }

        public int GetUserInput(string question, string type, string quesiton2)
        {
            Console.WriteLine(question);

            try
            {
                bool answer2 = false;
                int answer = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(quesiton2);

                try
                {
                    var readLine = Console.ReadLine() ?? "no";

                    answer2 = readLine.ToLower().StartsWith("y");

                }
                catch (Exception)
                {
                    Console.WriteLine("IO error trying to read your answer needs to be a small integer" + "\n");                                    
                }

                ProcessAnswer(answer, type, answer2);                
            }
            catch
            {                
                Console.WriteLine("IO error trying to read your answer needs to be a small integer" + "\n");                
            }

            CustomerInput(question, type, quesiton2);

            return 0;
        }
    }
}