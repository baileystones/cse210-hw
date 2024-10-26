public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        ShowCountdown(5);
        
        Console.WriteLine("Breathe in...");
        ShowCountdown(4);
        Console.WriteLine("Now breathe out...");
        ShowCountdown(4);

        DisplayEndingMessage();
    }
}