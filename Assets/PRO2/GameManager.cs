using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // UI References
    [SerializeField] private TextMeshProUGUI characterInfoText;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button specialAbilityButton;
    [SerializeField] private Button takeDamageButton;
    [SerializeField] private Button switchCharacterButton;

    // Character references
    private List<Character> characters = new List<Character>();
    private int currentCharacterIndex = 0;

    // Start is called when the script is first enabled
    void Start()
    {
        // Initialize UI buttons
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        specialAbilityButton.onClick.AddListener(OnSpecialAbilityButtonClicked);
        takeDamageButton.onClick.AddListener(OnTakeDamageButtonClicked);
        switchCharacterButton.onClick.AddListener(OnSwitchCharacterButtonClicked);

        // Create character objects
        InitializeCharacters();

        // Display initial character info
        UpdateCharacterInfoDisplay();
    }

    // Initialize character objects
    private void InitializeCharacters()
    {
        // TODO: Create instances of your character classes
        // Add at least one of each character type to the characters list

        // Example:
        characters.Add(new Warrior("Aragorn"));
        characters.Add(new Mage("Gragorn")); // TODO: Add a Mage
        characters.Add(new Archer("Dragorn")); // TODO: Add an Archer
    }

    // Handle attack button click
    private void OnAttackButtonClicked()
    {
        Character currentCharacter = characters[currentCharacterIndex];
        currentCharacter.Attack(); // TODO: Call the current character's Attack method
        UpdateCharacterInfoDisplay(); // Update the UI display
    }

    // Handle special ability button click
    private void OnSpecialAbilityButtonClicked()
    {
        Character currentCharacter = characters[currentCharacterIndex];
        currentCharacter.SpecialAbility(); // TODO: Call the current character's SpecialAbility method
        UpdateCharacterInfoDisplay(); // Update the UI display
    }

    // Handle take damage button click
    private void OnTakeDamageButtonClicked()
    {      
        Character currentCharacter = characters[currentCharacterIndex];
        int damage = Random.Range(5, 21); // TODO: Make the current character take a random amount of damage
        currentCharacter.TakeDamage(damage); 
        UpdateCharacterInfoDisplay(); // Update the UI display
    }

    // Handle switch character button click
    private void OnSwitchCharacterButtonClicked()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Count;// TODO: Switch to the next character in the list
        UpdateCharacterInfoDisplay();// Update the UI display
    }

    // Update the character info display
    private void UpdateCharacterInfoDisplay()
    {
        // TODO: Update the UI with the current character's information
        // Use the GetCharacterInfo method and any other relevant information
        Character currentCharacter = characters[currentCharacterIndex]; 
        characterInfoText.text = currentCharacter.GetCharacterInfo(); 
    }

    // Handle gaining experience and display level up messages
    private void GainExperienceForCurrentCharacter()
    {
        Character currentCharacter = characters[currentCharacterIndex];
        int xp = Random.Range(10, 51);  // TODO: Make the current character gain a random amount of experience
        currentCharacter.GainExperience(xp);
        UpdateCharacterInfoDisplay(); // Update the UI display
    }
}
