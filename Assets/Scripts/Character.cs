using System;
using UnityEngine;

[Serializable]
public class Character : MonoBehaviour
{
    public int LifeMax = 100;
    public int Life = 100;
    public Sprite SpritePortrait;
    public SpriteRenderer Visual;
    public Animator CharacterAnimator;
    public int NormalAttackDamage = 10;

    public Color CanAttackColor = Color.white;
    public Color StandByColor = Color.grey;
    private bool _hasAttackedThisTurnOrIsStuned = false;
    public int Mana = 1;
    public bool HasAttackedThisTurnOrIsStuned
    {
        get { return _hasAttackedThisTurnOrIsStuned; }
        set
        {
            _hasAttackedThisTurnOrIsStuned = value;
            Visual.color = _hasAttackedThisTurnOrIsStuned ? StandByColor : CanAttackColor;
        }
    }

    private void Start()
    {

        //PlayerPrefs.GetString("Joueur1");
        //PlayerPrefs.GetString("Joueur2");
        Life = LifeMax;
        //PlayerPrefs.SetString("CharacaterID", "Warrior,Mage");
        //"Warrior,Mage".Split(',');

    }
    public bool isAlive()
    {
        return Life > 0;
    }

    public bool HaveMana()
    {
        return Mana > 0;
    }
    virtual internal void Attack(Character defender)
    {
        print($"{name} is attacking {defender.name} of type {defender.GetType()}");
        CharacterAnimator.SetTrigger("attack");

        TurnManager.Instance.HasAttacked(this);
        

        if (defender.GetType() == typeof(Ally)) ((Ally)defender).Hit(damage: NormalAttackDamage);
        else if (defender.GetType() == typeof(Enemy)) ((Enemy)defender).Hit(damage: NormalAttackDamage);

        
    }
    virtual internal void Hit(int damage)
    {
        print($"{name} is hit and took {damage} damages");
    }
}
