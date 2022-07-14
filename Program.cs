using System;
using System.Linq;

namespace RhythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Rhythms Gonna Get You!!  ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            //this converts a string to a corresponding 32-bit signed integer value, if it cant be converted then the method returns a fa;se Boolean value the out is what you want it to convert to 

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            var context = new RhythmsGonnaGetYouContext();
            var keepGoing = true;

            DisplayGreeting();


            while (keepGoing)
            {

                Console.WriteLine();
                Console.Write("What do you want to do?\n (A)dd a band\n or (Q)uit: ");
                //(U)pdate an employee\n (D)elete an employee\n or (S)how all the employees\n or (F)ind an employee\n or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "A":
                        AddBand();



                        //context.Bands.Add(newBand);
                        //context.SaveChanges();

                        var viewBand = context.Bands.();
                        Console.WriteLine($"{viewBand}");


                }
            }
        }

        private static void AddBand()
        {
            var newBand = new Band();
            //control l picks the lines you want and shift alt a comments them out 
            newBand.Name = PromptForString("What is the name of the band? ");
            newBand.CountryOfOrigin = PromptForString("Where is the band from? ");
            newBand.NumberOfMembers = PromptForInteger("How many members are in the band?");
            newBand.Website = PromptForString("What is the band's website? ");
            newBand.Style = PromptForString("What is the style of the band? ");
            newBand.IsSigned = PromptForBool("Is the band signed? ");
            newBand.ContactName = PromptForString("What is the name of the manager? ");
            newBand.ContactPhoneNumber = PromptForString("What is the band's phone number? ");
        }

        private static bool PromptForBool(string v)
        {
            throw new NotImplementedException();
        }
        //what does this mean?? 
    }
