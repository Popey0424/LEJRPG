using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        CharacterAnimator.SetTrigger("hit");
        
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);

        if (Life == 0)
        {
            Debug.Log("MORT");
        }
       
    }

    private void EnemyDie()
    {

    }

    //private void NextMonster()
    //{
    //    _currentMonster = (_currentMonster + 1);
    //}

    public bool IsAlive()
    {
        return Life > 0;
    }
}
