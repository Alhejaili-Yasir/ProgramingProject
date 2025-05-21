using UnityEngine;

public class Archer : Character
{
    private int _agilityBonus;
    private int _precision;
    private int _stamina;

    public int AgilityBonus
    {
        get { return _agilityBonus; }
        set { _agilityBonus = value < 0 ? 0 : value; }
    }

    public int Precision
    {
        get { return _precision; }
        set { _precision = value < 0 ? 0 : value; }
    }

    public int Stamina
    {
        get { return _stamina; }
        set { _stamina = value < 0 ? 0 : value; }
    }

    public Archer(string name) : base(name)
    {
        _agilityBonus = 10;
        _precision = 8;
        _stamina = 70;
    }

    public override void Attack()
    {
        int damage = AgilityBonus * 2 + Precision;
        Debug.Log($"{Name} fires dealing {damage} damage!");
    }

    public override void SpecialAbility()
    {
        Debug.Log($"{Name} uses Arrow Shower, launching multiple arrows!");
        int specialDamage = AgilityBonus * 2;
        Debug.Log($"Arrow Shower deals {specialDamage} damage to each target.");
    }

    public override int GetMaxHealth()
    {
        return base.GetMaxHealth();
    }

    public void Camouflage()
    {
        Debug.Log($"{Name} performs an skill to avoid the next attack!");
    }
}
