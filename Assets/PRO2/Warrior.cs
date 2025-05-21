using UnityEngine;

// INHERITANCE: Warrior inherits from Character
public class Warrior : Character
{
    // Additional attributes specific to Warrior
    private int _strength;
    private int _defense;
    private int _durabilty;

    // TODO: Add getter/setter properties for Warrior-specific attributes
    public int Strengthw
    {
        get { return _strength; }
        set { _strength = value < 0 ? 0 : value; }
    }

    public int Defense
    {
        get { return _defense; }
        set { _defense = value < 0 ? 0 : value; }
    }

    public int Durabilty
    {
        get { return _durabilty; }
        set { _ = value < 0 ? 0 : value; }
    }
    // Constructor
    public Warrior(string name) : base(name)
    {
        
        _strength = 10; // Initialize Warrior-specific attributes
        _defense = 8; // Initialize Warrior-specific attributes
        _durabilty = 8; // TODO: Set other Warrior-specific initial values

    }

    // POLYMORPHISM: Override the Attack method
    public override void Attack()
    {
        // TODO: Implement Warrior-specific attack logic
        int damage = Strength * 3; // - Calculate damage based on strength
        Debug.Log($"{Name} swings a mighty sword and deals {damage} damage!"); // - Display a Warrior-specific attack message
    }

    // ABSTRACTION: Implement the abstract SpecialAbility method
    public override void SpecialAbility()
    {
        Debug.Log($"{Name} use the shield Bash to stun the enemy ");  // TODO: Implement Warrior's special ability (e.g., "Berserk", "Shield Bash")
        Debug.Log($"{Name} uses Shield Bash!");
        int bonusDamage = Strength * 2 + Defense; // TODO: Add special ability effects
    }

    // POLYMORPHISM: Override GetMaxHealth to make Warriors more tanky
    public override int GetMaxHealth()
    {
        // TODO: Implement a Warrior-specific formula for max health
        // Warriors should have more health than the base calculation
        return base.GetMaxHealth() + (Defense * 5);
    }

    // Additional Warrior-specific methods
    public void Defend()
    {
        int defenseBoost = 5;
        Defense += defenseBoost;
        Debug.Log($"{Name} takes a defensive stance, increasing defense by {defenseBoost} ");
    }
}

// TODO: Create two more character classes: Mage and Archer
// Each should inherit from Character and implement unique abilities and attributes

