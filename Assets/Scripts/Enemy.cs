using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{

    public Canvas Canvas;
    public GameObject PrefabHitPoint;
    public CameraShake cameraShake;
    public GameObject PrefabKO;
    
    internal override void Attack(Character defender)
    {
        if (HasAttackedThisTurnOrIsStuned) return;
        base.Attack(defender);
    }

    internal override void Hit(int damage)
    {
        base.Hit(damage);
        GameObject go = GameObject.Instantiate(PrefabHitPoint, Canvas.transform);
        go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
        go.transform.DOLocalMoveY(150, 0.8f);
        go.GetComponent<Text>().DOFade(0, 0.8f);
        GameObject.Destroy(go, 0.8f);
        CharacterAnimator.SetTrigger("hit");
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        
        Life = Mathf.Clamp(Life - damage, 0, LifeMax);

        if (Life == 0)
        {


            GameObject Go = GameObject.Instantiate(PrefabKO, Canvas.transform);
            Go.transform.localPosition = UnityEngine.Random.insideUnitCircle * 100;
            Go.transform.DOLocalMoveY(150, 0.8f);
            Go.GetComponent<Text>().DOFade(0, 0.8f);
            GameObject.Destroy(Go, 0.8f);
            StartCoroutine(EnemyDeathDelay());
            
           
            
            

        }
       
    }

    private IEnumerator EnemyDeathDelay()
    {
        yield return new WaitForSeconds(1f);                 
        Destroy(gameObject);       
        TurnManager.Instance.RemoveEnemy(this);
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
