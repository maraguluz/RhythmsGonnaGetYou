using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
                Console.Write("What do you want to do?\n (A)dd a band\n or (Q)uit\n or (V)iew all the bands\n or Add a Song to an Album\n or tbd");
                //(U)pdate an employee\n (D)elete an employee\n or (S)how all the employees\n or (F)ind an employee\n or (Q)uit: ");
                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "A":
                        AddBand();
                        break;
                    case "V":
                        Console.WriteLine("These are the bands:");

                        foreach (var viewBand in context.Bands)
                            //not done/ I did something wrong 
                            Console.WriteLine($"- {viewBand.Name}");
                        break;
                    case "AA":
                        var nameOfBand = PromptForString("What is the name of the band for the album? ");
                        if (nameOfBand == null)
                        {
                            Console.WriteLine("This band does not exist, please try again :)");

                        }
                        else
                        {
                            var newAlbum = new Album();
                            Console.WriteLine($"Do you want to add an album to {nameOfBand}? [Y/N]");
                            Console.ReadLine();
                            // if "Y";
                            // {
                            //     newAlbum.Title = PromptForString("What is the name of the album you want to add for the band? ");
                            //     newAlbum.IsExplicit = PromptForBool("Is the band signed? ");

                            // }
                            // else


                            newAlbum.Title = PromptForString("What is the name of the album you want to add for the band? ");
                            newAlbum.IsExplicit = PromptForBool("Is the band signed? ");

                            //  var albumForBand = context.Albums.Include(album => album.Band);
                            // foreach (var album in albumForBand)
                            // {
                            //     if (album.Band == null)
                            //     {
                            //         Console.WriteLine($"There is a movie named {movie.Title} and has not been rated yet");
                            //     }
                            //     else
                            //     {
                            //         Console.WriteLine($"There is a movie named {movie.Title} and a rating of {movie.Rating.Description}");
                            //     }
                            // }
                        }
                        break;



                }
            }
        }


        static void AddBand()
        {
            var context = new RhythmsGonnaGetYouContext();
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
            context.Bands.Add(newBand);
            context.SaveChanges();
            //adds to data base 
            //var viewBand = context.Bands.();
        }

        private static bool PromptForBool(string prompt)
        // {
        // throw new NotImplementedException();
        // }
        //placeholder to keep code compiling until it has been implemented 
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
