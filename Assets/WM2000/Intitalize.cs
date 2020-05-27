using System.Collections;
using System.Collections.Generic;
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
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "cd ..")
        {
            ShowMainMenu();
        }
        else if(input == "clear")
        {
            ShowMainMenu();
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

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = levelOnePasswords[1];
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = levelTwoPasswords[4];
            StartGame();
        }
        else if(input == "3")
        {
            level = 3;
            password = levelThreePasswords[0];
            StartGame();
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
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Access Granted");
        }
        else
        {
            Terminal.WriteLine("Access Denied");
        }
    }
}
