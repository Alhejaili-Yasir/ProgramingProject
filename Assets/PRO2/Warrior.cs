using UnityEngine;

// INHERITANCE: Warrior inherits from Character
public class Warrior : Character
{
    private int _defense;

    // ENCAPSULATION: Public property with validation
    public int Defense
    {
        get { return _defense; }
        private set { _defense = Mathf.Max(0, value); }
    }

    // Constructor
    public Warrior(string name) : base(name)
    {
        Strength = 15;
        Agility = 8;
        Intelligence = 5;
        Defense = 12;
        Health = GetMaxHealth(); // Set starting health based on Warrior-specific formula
    }

    // POLYMORPHISM: Override the base Attack method
    public override void Attack()
    {
        int damage = Strength * 2;
        Debug.Log($"{Name} slashes with a sword and deals {damage} damage!");
    }

    // ABSTRACTION: Implement Warrior's special ability
    public override void SpecialAbility()
    {
        Debug.Log($"{Name} uses Shield Bash! It stuns the enemy and deals bonus damage.");
    }

    // POLYMORPHISM: Override GetMaxHealth to give Warriors more durability
    public override int GetMaxHealth()
    {
        return base.GetMaxHealth() + (Defense * 2);
    }

    // Extra Warrior-specific ability
    public void Defend()
    {
        Debug.Log($"{Name} enters a defensive stance, increasing defense temporarily.");
        Defense += 5;
    }
}
