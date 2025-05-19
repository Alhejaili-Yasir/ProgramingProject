using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberGuessingGame : MonoBehaviour
{
    // VARIABLES SECTION
    // TODO: Declare your variables here
    // Examples of variables you might need:

    public TMP_InputField inputField; //to read user input
    public Button guessButton; // insted of pressing enter
    public TMP_Text messageText; // here we can show our messages to the user
    int ranNum; // - Variable to store the randomly generated number (int)
    int guess;  // - Variable to store the player's guess (int)
    int attempts; // - Variable to track the number of attempts (int)
    bool isOver;  // - Variable to track if the game is over (bool)
    int maxAttempts = 10;  // - Variable to store the maximum number of allowed attempts (int)
    int[] highScore = { 3, 5, 6 };     // - Variables to track game statistics (int)





    // Start is called when the script is first enabled
    void Start()
    {
        Debug.Log("Welcome to the Number Guessing Game!"); //explaining the game for the user
        StartNewGame();
        DisplayHighScores();
        guessButton.onClick.AddListener(HandleGuess);
    }

    // Method to start a new game
    void StartNewGame()
    {
        // TODO: Initialize a new game
        // 1. Generate a random number between 1 and 100
        // 2. Reset the attempt counter
        // 3. Reset the game over flag
        // 4. Display a message indicating the game has started
        // 5. Prompt the player for their first guess
        ranNum = UnityEngine.Random.Range(1, 101);
        attempts = 0;
        isOver = false; // game status
        Debug.Log("I'm thinking of a number between 1 and 100.");
        Debug.Log("Enter your guess in the text and then press the button");
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Handle player input in the Update method

        if (!isOver)        // 1. Check if the game is still active

        {
            // HINT: To check if Enter was pressed and read input: < ConsoleReadline is not working in the unity console so i will use Unity UI
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) // 2. Check if the player has pressed Enter after typing their guess
            {
                string input = "50";
                // TODO: Process the player's input
                // If the game is active, treat it as a guess
                // If the game is over, check if they want to play again
                ProcessGuess(input);  // 3. Process the guess using the ProcessGuess() method
            }
        }
    }

    void HandleGuess()
    {
        string input = inputField.text;
        ProcessGuess(input);

        if (isOver)
        {
            StartNewGame();
            return;
        }
    }

    // Method to process the player's guess
    void ProcessGuess(string input)
    {
        // TODO: Implement the logic to process the player's guess
        bool isValid = int.TryParse(input, out int guess);
        if (!isValid)
        {
            messageText.text = "Please enter a number.";
            return;
        }// 1. Convert the input string to an integer
         // 2. Validate the input (is it a valid number?)
        if (guess == ranNum)
        {
            messageText.text = $"Correct! You guessed it in {attempts} attempts.";
            EndGame(true);
        }
        else if (guess < ranNum)
        {
            messageText.text = "Too low! Try a higher number.";
        }
        else
        {
            messageText.text = "Too high! Try a lower number."; // 3. Check if the guess is correct, too high, or too low
        }
        attempts++; // 4. Update the attempt counter
        if (attempts >= maxAttempts && guess != ranNum)
        {
            EndGame(false);
        }
        // 5. Check if the player has run out of attempts
        // 6. Provide appropriate feedback to the player

        // HINT: To convert a string to an integer and handle errors:
        // bool isValid = int.TryParse(input, out int guess);
        // if (isValid)
        // {
        //     // Process the valid guess
        // }
        // else
        // {
        //     Debug.Log("That's not a valid number. Try again.");
        // }

        // TODO: Implement CONDITIONAL STATEMENTS (if/else) to check the guess
        // if (guess == secretNumber)
        // {
        //     // Player guessed correctly!
        // }
        // else if (guess < secretNumber)
        // {
        //     // Guess is too low
        // }
        // else
        // {
        //     // Guess is too high
        // }
    }

    // Method to end the game
    void EndGame(bool playerWon)
    {
        // TODO: Implement the logic to end the game
        isOver = true; // 1. Set the game over flag to true

        if (playerWon)
        {
            Debug.Log("Congratulations! You guessed the number!");
            messageText.text += $"You win in {attempts} attempts!"; // 3. Show game statistics (attempts used, etc.)
        }
        else
        {
            Debug.Log("Game Over! You've run out of attempts.");
            messageText.text = $"💥 Game Over! The correct number was {ranNum}."; // show the answer
        }

        Debug.Log("Would you like to play again? (yes/no)");
        messageText.text += "Click the button to play again."; // 4. Prompt the player to play again
    }

    // Method to check if the player wants to play again
    bool CheckPlayAgain(string input) // cuz we are using a button we dont accually need this but i added it just in case its from the requirment
    {
        input = input.ToLower();

        if (input == "yes")
            return true;
        else if (input == "no")
            return false;
        else
        {
            messageText.text = "Please type 'yes' or 'no'.";
            return false;
        }
    }

    // Method to display high scores
    void DisplayHighScores()
    {
        // TODO: Implement the logic to display high scores
        // This is a bonus feature - use a loop to display the top scores
        Debug.Log("HIGH SCORES");
        messageText.text = "HIGH SCORES:\n";
        for (int i = 0; i < highScore.Length; i++)
        {
            messageText.text += $"{i + 1}. {highScore[i]} attempts\n";
        }
        // TODO: Implement a FOR LOOP to display all high scores
        // for (int i = 0; i < highScores.Length; i++)
        // {
        //     Debug.Log($"{i+1}. {highScores[i]} attempts");
        // }
    }

    // Method to implement difficulty levels (BONUS)
    void SetDifficulty(string difficultyLevel)
    {
        // TODO: BONUS - Implement different difficulty levels
        // Use a switch statement or if/else to set game parameters based on difficulty

        // switch (difficultyLevel.ToLower())
        // {
        //     case "easy":
        //         // Set easy difficulty (more attempts, smaller range)
        //         break;
        //     case "medium":
        //         // Set medium difficulty
        //         break;
        //     case "hard":
        //         // Set hard difficulty (fewer attempts, larger range)
        //         break;
        //     default:
        //         // Default to medium difficulty
        //         break;
        // }
    }

    // BONUS: Implement a hint system
    void GiveHint()
    {
        // TODO: BONUS - Implement a hint system
        // 1. Provide a hint that narrows down the possible range
        // 2. Deduct extra attempts as a "cost" for the hint

        // HINT: You might give a range like "The number is between 35 and 47"
    }
}
