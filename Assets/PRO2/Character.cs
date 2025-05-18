using UnityEngine;

public abstract class Character
{
    private string _name;
    private int _health;
    private int _level;
    private int _experience;

    private int _strength;
    private int _agility;
    private int _intelligence;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Health
    {
        get { return _health; }
        set
        {
            _health = Mathf.Max(0, value); 
        }
    }

    public int Level
    {
        get { return _level; }
        private set { _level = value; }
    }

    public int Experience
    {
        get { return _experience; }
        private set { _experience = value; }
    }

    public int Strength
    {
        get { return _strength; }
        protected set { _strength = value; }
    }

    public int Agility
    {
        get { return _agility; }
        protected set { _agility = value; }
    }

    public int Intelligence
    {
        get { return _intelligence; }
        protected set { _intelligence = value; }
    }

    public Character(string name)
    {
        _name = name;
        _level = 1;
        _health = GetMaxHealth();
        _experience = 0;
        _strength = 5;
        _agility = 5;
        _intelligence = 5;
    }

    public abstract void SpecialAbility();

    public virtual void Attack()
    {
        Debug.Log($"{_name} attacks for base damage!");
    }

    public void GainExperience(int amount)
    {
        _experience += amount;
        Debug.Log($"{_name} gained {amount} XP.");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredXP = _level * 100;

        if (_experience >= requiredXP)
        {
            _experience -= requiredXP;
            _level++;
            _health = GetMaxHealth();
            Strength += 2;
            Agility += 2;
            Intelligence += 2;
            Debug.Log($"{_name} leveled up to {Level}!");
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{_name} took {damage} damage. Remaining HP: {Health}");

        if (Health <= 0)
        {
            Debug.Log($"{_name} has been defeated.");
        }
    }

    public string GetCharacterInfo()
    {
        return $"Name: {Name}, Level: {Level}, HP: {Health}/{GetMaxHealth()}, STR: {Strength}, AGI: {Agility}, INT: {Intelligence}";
    }

    public virtual int GetMaxHealth()
    {
        return 100 + (Level * 10);
    }
}
