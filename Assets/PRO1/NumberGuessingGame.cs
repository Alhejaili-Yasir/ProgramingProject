using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberGuessingGame : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_InputField inputField;
    public TMP_Text messageText;
    public Button guessButton;

    [Header("Game Settings")]
    public int maxAttempts = 10;

    private int secretNumber;
    private int attempts;
    private bool isGameOver = false;

    // هذا المثال عشان نستخدم for loop
    private int[] highScores = { 3, 5, 6 };

    void Start()
    {
        guessButton.onClick.AddListener(OnGuess);
        ShowHighScores();       // for loop مثال
        SimulateReplayCheck();  // while loop مثال
        StartNewGame();
    }

    void StartNewGame()
    {
        secretNumber = Random.Range(1, 101); // توليد رقم بين 1 و 100
        attempts = 0;
        isGameOver = false;
        messageText.text = "Guess a number between 1 and 100:";
        inputField.text = "";
    }

    void OnGuess()
    {
        if (isGameOver)
        {
            StartNewGame();
            return;
        }

        string input = inputField.text;

        // تحقق من صحة الإدخال
        if (!int.TryParse(input, out int guess))
        {
            messageText.text = "Please enter a valid number.";
            return;
        }

        attempts++;

        // تحقق إذا اللاعب فاز أو لا
        if (guess == secretNumber)
        {
            messageText.text = $"Correct! You guessed it in {attempts} attempts.\nClick the button to play again.";
            isGameOver = true;
        }
        else if (guess < secretNumber)
        {
            messageText.text = $"Too low. Attempts left: {maxAttempts - attempts}";
        }
        else
        {
            messageText.text = $"Too high. Attempts left: {maxAttempts - attempts}";
        }

        // إذا وصلت المحاولات للحد الأقصى
        if (attempts >= maxAttempts && !isGameOver)
        {
            messageText.text = $"Game Over! The number was {secretNumber}.\nClick the button to try again.";
            isGameOver = true;
        }

        inputField.text = "";
    }

    void ShowHighScores()
    {
        Debug.Log("High Scores:");
        for (int i = 0; i < highScores.Length; i++)
        {
            Debug.Log($"{i + 1}. {highScores[i]} attempts");
        }
    }

    void SimulateReplayCheck()
    {
        bool keepWaiting = true;
        int counter = 0;

        while (keepWaiting)
        {
            counter++;
            keepWaiting = false; // نوقف الحلقة بعد أول دورة (بس عشان نحقق الشرط)
        }
    }
}
