using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

public class InstantiateCharacter : MonoBehaviour
{
    public List<GameObject> Prefabs = new List<GameObject>();
    public GameObject[] PositionCharas = new GameObject[2];
    public GameObject ParentCharacter;

    private GameObject[] _characters = new GameObject[2];


    private void Start()
    {
        for(int i = 0; i < _characters.Length; i++)
        {
            int nb  = 1 + i;
            string nbstr = "Joueur1" + nb.ToString();
            _characters[i] = Instantiate(GetPrefab(PlayerPrefs.GetString(nbstr)), ParentCharacter.transform);
            _characters[i].transform.position = PositionCharas[i].transform.position;
        }
    }

    private GameObject GetPrefab(string prefabName)
    {
        foreach (var prefab in Prefabs)
        {
            if (prefab.name == prefabName)
                return prefab;
        }

        return null;
    }
}
