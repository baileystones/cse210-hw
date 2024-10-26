using System;
using System.IO; 
using System.Collections.Generic;

public class Journal
{

    private List<Entry> _entries = new List<Entry>();
    
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No entries to show, write your first one!");
            }
            else{
                 foreach (var entry in _entries)
                {
                    entry.Display();
                }
            }
        }
    
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter (file))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine (entry._date);
                outputFile.WriteLine (entry._promptText);
                outputFile.WriteLine (entry._entryText);
                outputFile.WriteLine ();
            }
        }      
        Console.WriteLine("Your entry has been saved.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
        
            for (int i = 0; i < lines.Length; i += 4)
            {
                string date = lines[i];
                string prompt = lines[i + 1];
                string entryText = lines[i + 2];

                Entry entry = new Entry
                {
                    _date = date, 
                    _promptText = prompt,
                    _entryText = entryText
                };

                _entries.Add(entry);
            }
        }
        else
        {
                Console.WriteLine("File not found.");
        }
    }  
}
