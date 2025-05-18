using UnityEngine;

// INHERITANCE: Archer inherits from Character
public class Archer : Character
{
    private float _criticalChance;

    // ENCAPSULATION: Public property with simple validation
    public float CriticalChance
    {
        get { return _criticalChance; }
        private set { _criticalChance = Mathf.Clamp(value, 0f, 1f); }
    }

    // Constructor
    public Archer(string name) : base(name)
    {
        Strength = 10;
        Agility = 15;
        Intelligence = 6;
        CriticalChance = 0.25f; // 25% chance to land a critical hit
        Health = GetMaxHealth();
    }

    // POLYMORPHISM: Override the base Attack method
    public override void Attack()
    {
        int baseDamage = Strength + Agility;
        bool isCritical = Random.value < CriticalChance;

        if (isCritical)
        {
            int critDamage = baseDamage * 2;
            Debug.Log($"{Name} lands a CRITICAL hit with an arrow, dealing {critDamage} damage!");
        }
        else
        {
            Debug.Log($"{Name} shoots an arrow and deals {baseDamage} damage.");
        }
    }

    // ABSTRACTION: Implement Archer's special ability
    public override void SpecialAbility()
    {
        int shots = 3;
        int damagePerShot = Agility;

        Debug.Log($"{Name} uses Multi-Shot, firing {shots} arrows!");

        for (int i = 1; i <= shots; i++)
        {
            Debug.Log($"Arrow {i}: {damagePerShot} damage");
        }
    }

    // POLYMORPHISM: Adjust max health slightly below base
    public override int GetMaxHealth()
    {
        return base.GetMaxHealth() - 10; // Slightly less durable than base class
    }
}
