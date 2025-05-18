using UnityEngine;

// INHERITANCE: Mage inherits from Character
public class Mage : Character
{
    private int _mana;

    // ENCAPSULATION: Public property with validation
    public int Mana
    {
        get { return _mana; }
        private set { _mana = Mathf.Max(0, value); }
    }

    // Constructor
    public Mage(string name) : base(name)
    {
        Strength = 4;
        Agility = 6;
        Intelligence = 16;
        Mana = 100;
        Health = GetMaxHealth(); // Set starting health
    }

    // POLYMORPHISM: Override the base Attack method
    public override void Attack()
    {
        int damage = Intelligence * 2;
        Debug.Log($"{Name} casts a magic bolt and deals {damage} damage!");
        Mana -= 10;
    }

    // ABSTRACTION: Implement Mage's special ability
    public override void SpecialAbility()
    {
        if (Mana >= 25)
        {
            int damage = Intelligence * 4;
            Debug.Log($"{Name} uses Fireball! It deals {damage} area damage.");
            Mana -= 25;
        }
        else
        {
            Debug.Log($"{Name} doesn't have enough mana to cast Fireball.");
        }
    }

    // POLYMORPHISM: Override GetMaxHealth for a more fragile class
    public override int GetMaxHealth()
    {
        return base.GetMaxHealth() - 20; // Less durable than base
    }

    // Extra method: Regenerate mana over time or by item
    public void RegenerateMana(int amount)
    {
        Mana += amount;
        Debug.Log($"{Name} regenerates {amount} mana. Current mana: {Mana}");
    }
}
