public class ListingActivity : Activity
{
     private int _count;
     private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        ShowSpinner(5);

        string prompt = GetRandomPrompt();
        Console.WriteLine($"List as many responses you can to the following prompt: {prompt}");
        ShowCountdown(5);
        GetListFromUser();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        Console.WriteLine("You may begin:");
        Console.WriteLine(">");

        while (true)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (string.IsNullOrEmpty(response))
            {
                break;
            }
            responses.Add(response);
            _count++;
        }
        Console.WriteLine($"You listed {_count} items!");
        return responses;
    }
}