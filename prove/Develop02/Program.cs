//DISCLAIMER: I used ChatGPT to help with some debugging and streamlining, but this is my own code and my own ideas.
//EXCEEDING REQUIREMENTS: One of the hardest parts of journaling, for me at least, is consistency. I made my program tell you the number of hours until the end of the following day,so they get in a daily habit of writing. For complete transparency, I used ChatGPT & Google to help me figure out some of the logic of this.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool programRuns = true;

        while (programRuns)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");

            string selection = Console.ReadLine();

            if (selection == "1" )
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string entryText = Console.ReadLine();

                Entry newEntry = new Entry
                {
                    _date = DateTime.Now.ToShortDateString(),
                    _promptText = prompt,
                    _entryText = entryText
                };
                theJournal.AddEntry(newEntry);
                Console.WriteLine("Entry added.");

                //EXCEEDING REQUIREMENTS PORTION
                DateTime currentTime = DateTime.Now;
                DateTime endOfNextDay = currentTime.Date.AddDays(2); 
                TimeSpan timeRemaining = endOfNextDay - currentTime;
                int hoursRemaining = (int)timeRemaining.TotalHours;
                Console.WriteLine($"Thank you for writing. You have {hoursRemaining} hours to write again by the end of tomorrow to keep your streak and build good habits!");
            }
            else if (selection == "2")
            {
                theJournal.DisplayAll();
            }

            else if (selection == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.LoadFromFile(fileName);
            }
            else if (selection == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                theJournal.SaveToFile(fileName);
            }
            else if (selection == "5")
            {
                programRuns = false;
                Console.WriteLine("Thank you, goodbye!");
            }
            else
            {
                Console.WriteLine("Error. Please choose a valid number 1-5.");
            }

        }
   }
}