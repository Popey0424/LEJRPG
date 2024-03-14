using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrid : MonoBehaviour
{
     public GameObject PrefabCharacterGrid;
    [SerializeField] public List<CharacterData> characters;

    private void Start()
    {
        foreach (var character in characters)
        {
            GameObject characterGO = GameObject.Instantiate(PrefabCharacterGrid, transform);
            CharacterUI characterUI = characterGO.GetComponent<CharacterUI>();
            characterUI.Picture.sprite = character.Visual;
            characterUI.Picture.GetComponent<RectTransform>().pivot = character.Offset;
            characterUI.Picture.GetComponent<RectTransform>().sizeDelta = character.Size;
            characterUI.TextName.text = character.Name;
        }
    }
}
