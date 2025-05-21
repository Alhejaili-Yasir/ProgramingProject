using UnityEngine;

public class Mage : Character
{
    private int _mana;
    private int _spellPower;
    private int _wisdom;

    public int Mana
    {
        get { return _mana; }
        set { _mana = value < 0 ? 0 : value; }
    }

    public int SpellPower
    {
        get { return _spellPower; }
        set { _spellPower = value < 0 ? 0 : value; }
    }

    public int Wisdom
    {
        get { return _wisdom; }
        set { _wisdom = value < 0 ? 0 : value; }
    }

    public Mage(string name) : base(name)
    {
        _mana = 100;
        _spellPower = 12;
        _wisdom = 10;
    }

    public override void Attack()
    {
        int damage = SpellPower * 3;
        Debug.Log($"{Name} casts a Fire Bolt and deals {damage} magic damage!");
    }

    public override void SpecialAbility()
    {
        Debug.Log($"{Name} uses Fire Ball to damage all nearby enemies!");
        int specialDamage = SpellPower * 4 + Wisdom;
        Debug.Log($"Fire Ball deals {specialDamage} damage!");
    }

    public override int GetMaxHealth()
    {
        return base.GetMaxHealth() - 20;
    }

    public void ManaRecharge()
    {
        int manaGain = 25;
        Mana += manaGain;
        Debug.Log($"{Name} Sits and restore {manaGain} mana.");
    }
}
