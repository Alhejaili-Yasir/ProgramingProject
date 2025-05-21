using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the base Character class that demonstrates abstraction and encapsulation
public abstract class Character
{
    // ENCAPSULATION: Private fields with public properties
    private string _name;
    private int _health;
    private int _level;
    private int _experience;
    private int _strength; // TODO: Add more character attributes (strength, agility, intelligence, etc.)
    private int _agility; // TODO: Add more character attributes (strength, agility, intelligence, etc.)
    private int _intelligence; // TODO: Add more character attributes (strength, agility, intelligence, etc.)




    // Properties demonstrate encapsulation - controlled access to private fields
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Health
    { 
        get { return _health; }
        
        set { _health = value < 0 ? 0 : value; } // TODO: Implement a setter that ensures health doesn't go below 0
    }


    public int Level
    {
        get { return _level; }
        private set { _level = value; } // Private setter - can only be changed inside the class
    }

    public int Experience
    {
        get { return _experience; }
        private set { _experience = value; } // Private setter - can only be changed inside the class
    }

    public int Strength
    {
        get { return _strength; }
        private set { _strength = value; } // Private setter - can only be changed inside the class
    }

    public int Agility
    {
        get { return _agility; }
        private set { _agility = value; } // Private setter - can only be changed inside the class
    }

    public int Intelligence
    {
        get { return _intelligence; }
        private set { _intelligence = value; } // Private setter - can only be changed inside the class
    }



    // TODO: Implement the remaining properties for your attributes > i did for the strength ,agility , intelligence

    // Constructor
    public Character(string name)
    {
        _name = name;
        _level = 1;
        _health = 100;
        _experience = 0;
        _strength = 0;
        _agility = 0;
        _intelligence = 0;

    }

    // ABSTRACTION: Abstract method that derived classes must implement
    // This shows how we can define behavior that all characters must have,
    // but the implementation details can vary between character types
    public abstract void SpecialAbility();

    // Virtual method that can be overridden by derived classes
    // This demonstrates POLYMORPHISM - same method name but different behavior in derived classes
    public virtual void Attack()
    {
        Debug.Log($"{_name} attacks for base damage!");
        int baseDamage = _strength * 2;// TODO: Implement base attack logic
    }

    // Method to gain experience and potentially level up
    public void GainExperience(int amount)
    {
        _experience += amount;
        Debug.Log($"{_name} gained {amount} experience points!");
        _experience += amount; // TODO: Implement level up logic based on experience thresholds
        // Check if the character should level up
        CheckLevelUp();
    }

    // Private method for checking level up conditions
    private void CheckLevelUp()
    {
        // TODO: Implement level up logic
        int requiredXP = _level * 100;
        // If experience is greater than or equal to required amount:
        if (_experience >= requiredXP)
        {
            _experience -= requiredXP;
            _level++; // - Increase level
            _health = 100; // - Update stats
            _strength += 2; // - Update stats
            _agility += 1; // - Update stats
            _intelligence += 1; // - Update stats
            Debug.Log($"{_name} leveled up to level {_level}!"); // - Display level up message
        }
    }

    // Method for taking damage
    public void TakeDamage(int damage)
    {
        // TODO: Implement damage logic
        _health -= damage; // - Reduce health by damage amount
        if (_health < 0) _health = 0; // - Ensure health doesn't go below 0

        Debug.Log($"{_name} took {damage} damage. Current health: {_health}"); // - Display appropriate messages

        if (_health == 0)
        {
            Debug.Log($"{_name} has been defeated!"); // - Display appropriate messages
        }
    }

    // Method to display character information
    public string GetCharacterInfo()
    {
        // TODO: Return a string containing all character information
        return $"Name: {_name}, Level: {_level}, HP: {_health}/{GetMaxHealth()}, " +
       $"XP: {_experience}, STR: {_strength}, AGI: {_agility}, INT: {_intelligence}";
    }

    // Method to get the maximum health based on level
    public virtual int GetMaxHealth()
    {
        // Basic formula: 100 HP + 10 per level
        return 100 + (_level * 10);
    }
}
