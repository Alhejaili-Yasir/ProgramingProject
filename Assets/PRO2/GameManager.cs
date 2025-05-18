using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterInfoText;
    [SerializeField] private Button attackButton;
    [SerializeField] private Button specialAbilityButton;
    [SerializeField] private Button takeDamageButton;
    [SerializeField] private Button switchCharacterButton;

    private List<Character> characters = new List<Character>();
    private int currentCharacterIndex = 0;

    private void Start()
    {
        // Setup button functionality
        attackButton.onClick.AddListener(OnAttackButtonClicked);
        specialAbilityButton.onClick.AddListener(OnSpecialAbilityButtonClicked);
        takeDamageButton.onClick.AddListener(OnTakeDamageButtonClicked);
        switchCharacterButton.onClick.AddListener(OnSwitchCharacterButtonClicked);

        // Create characters
        InitializeCharacters();

        // Display info for the first character
        UpdateCharacterInfoDisplay();
    }

    private void InitializeCharacters()
    {
        characters.Add(new Warrior("Aragorn"));
        characters.Add(new Mage("Gandalf"));
        characters.Add(new Archer("Legolas"));
    }

    private Character GetCurrentCharacter()
    {
        return characters[currentCharacterIndex];
    }

    private void OnAttackButtonClicked()
    {
        GetCurrentCharacter().Attack();
        UpdateCharacterInfoDisplay();
    }

    private void OnSpecialAbilityButtonClicked()
    {
        GetCurrentCharacter().SpecialAbility();
        UpdateCharacterInfoDisplay();
    }

    private void OnTakeDamageButtonClicked()
    {
        int randomDamage = Random.Range(10, 30);
        GetCurrentCharacter().TakeDamage(randomDamage);
        UpdateCharacterInfoDisplay();
    }

    private void OnSwitchCharacterButtonClicked()
    {
        currentCharacterIndex = (currentCharacterIndex + 1) % characters.Count;
        Debug.Log($"Switched to: {GetCurrentCharacter().Name}");
        UpdateCharacterInfoDisplay();
    }

    private void UpdateCharacterInfoDisplay()
    {
        characterInfoText.text = GetCurrentCharacter().GetCharacterInfo();
    }
}
