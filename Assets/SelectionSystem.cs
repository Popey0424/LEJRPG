using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionSystem : MonoBehaviour
{
    public GraphicRaycaster Raycaster;
    private CharacterUI m_selectedCharacter;
    void Update()
    {
        PointerEventData eventData = new PointerEventData(null);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();

        Raycaster.Raycast(eventData, results);

        if (results.Count > 0)
        {
            CharacterUI character = results[0].gameObject.GetComponent<CharacterUI>();

            if (character != null)
            {
                if (m_selectedCharacter != null && character != m_selectedCharacter)
                {
                    m_selectedCharacter.SelectionBorder.color = new Color(1, 1, 1, 0);
                }

                character.SelectionBorder.color = Color.white;

                m_selectedCharacter = character;
            }
        }
    }
}
