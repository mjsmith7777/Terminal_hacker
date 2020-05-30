using UnityEngine;

public class Intitalize : MonoBehaviour
{
    // Game configuration data
    string[] levelOnePasswords = { "libby", "zerocool", "acidburn", "crashoveride", "outerlimits" };
    string[] levelTwoPasswords = { "richardgill", "joey", "deceased", "harass", "arrest" };
    string[] levelThreePasswords = { "god", "elingson", "theplague", "eugene", "davinci" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the TV Station");
        Terminal.WriteLine("Press 2 for the Secret Service");
        Terminal.WriteLine("Press 3 for a sweet Gibson");
        Terminal.WriteLine("Type help for list of commands.");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "cd ..")
        {
            ShowMainMenu();
        }
        else if (input == "clear")
        {
            ShowMainMenu();
        }
        else if (input == "help")
        {
            PrintHelpMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void PrintHelpMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Type \"cd ..\" to go back a directory");
        Terminal.WriteLine("Type \"clear\" to clear screen and go to main menu.");
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "Zerocool" || input == "zerocool")
        {
            Terminal.WriteLine("HACK THE PLANET");
        }
        else
        {
            Terminal.WriteLine(input + " command not reconized");
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint:" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index = Random.Range(0, levelOnePasswords.Length);
                password = levelOnePasswords[index];
                break;
            case 2:
                int index2 = Random.Range(0, levelTwoPasswords.Length);
                password = levelTwoPasswords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, levelThreePasswords.Length);
                password = levelThreePasswords[index3];
                break;
            default:
                Debug.LogError("Inlvalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("What do you want to watch?");
                Terminal.WriteLine(@"
 ___________
|  .----.  o|
| |      | o| 
| |      | o|
|__`----`___|
 `         `
                ");
                break;
            case 2:
                Terminal.WriteLine("Made Richard Gills life suck!!!");
                Terminal.WriteLine(@"
      _ 
  ___-(o) ___ 
 ////\_|_/\\\\
       | 
      '|`      ");
                break;
            case 3:
                Terminal.WriteLine("Garbage File Copied");
                Terminal.WriteLine(@"
 ______
| |__| |
|  ()  |
|______|
                ");
                break;
        }
    }
}
