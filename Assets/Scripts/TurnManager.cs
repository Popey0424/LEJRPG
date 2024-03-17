using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    private static TurnManager _instance;
    public TextMeshProUGUI WIN;
    public static TurnManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance == null) _instance = this;
    }
    [SerializeField] private List<Ally> _allies;
    [SerializeField] private List<Enemy> _enemies;
    private int _turnCount = 0;
    private bool _isEnemiesTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        _allies = new List<Ally>(FindObjectsByType<Ally>(FindObjectsSortMode.InstanceID));
        _enemies = new List<Enemy>(FindObjectsByType<Enemy>(FindObjectsSortMode.InstanceID));
        foreach (Ally ally in _allies) { ally.HasAttackedThisTurnOrIsStuned = false; }
        foreach (Enemy enemy in _enemies) { enemy.HasAttackedThisTurnOrIsStuned = false; }


    }
    private void Update()
    {
        if (_isEnemiesTurn)
        {
            foreach (Enemy enemy in _enemies)
            {
                AttackRandomAlly(enemy);
            }
        }
        if (_enemies.Count == 0)
        {
            StartCoroutine(KO());
        }
    }

    private void AttackRandomAlly(Enemy enemy)
    {
        if (enemy.HasAttackedThisTurnOrIsStuned) return;
        int index = UnityEngine.Random.Range(0, _allies.Count);
        enemy.Attack(_allies[index]);
    }

    public bool HasAttacked<T>(T character) where T : Character
    {
        if (character != null)
        {
            character.HasAttackedThisTurnOrIsStuned = true;
            if (character.GetType() == typeof(Enemy))
            {
                return EnemiesHaveEndedTheirTurn();
            }
            else if (character.GetType() == typeof(Ally))
            {
                return AlliesHaveEndedTheirTurn();
            }
        }
        return false;
    }

    private bool AlliesHaveEndedTheirTurn()
    {
        bool res = true;
        foreach (Ally ally in _allies) { res = res && ally.HasAttackedThisTurnOrIsStuned; }
        if (res)
        {
            SelectionManager.Instance.CurrentSelectionMode = SelectionMode.EnemyTurn;
            _isEnemiesTurn = true;
            foreach (Ally ally in _allies) { ally.HasAttackedThisTurnOrIsStuned = false; }
        }
        print(res ? "This is the end of the allies' turn !" : "You can attack with at least another ally.");
        StartCoroutine(NextTurn());
        return res;
    }
    private bool EnemiesHaveEndedTheirTurn()
    {
        bool res = true;
        foreach (Enemy enemy in _enemies) { res = res && enemy.HasAttackedThisTurnOrIsStuned; }
        if (res)
        {
            SelectionManager.Instance.CurrentSelectionMode = SelectionMode.Default; _isEnemiesTurn = false;
            foreach (Enemy enemy in _enemies) { enemy.HasAttackedThisTurnOrIsStuned = false; }
        }
        StartCoroutine(NextTurn());
        return res;
    }

    IEnumerator NextTurn()
    {
        yield return new WaitForSeconds(3);

    }

    public void AddAlly(Ally ally)
    {
        if (ally != null)
        {
            _allies.Add(ally);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.Remove(enemy);
        }
    }
    IEnumerator KO()
    {
        WIN.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ChangeScene();
        
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("NextBattle");
    }


}
