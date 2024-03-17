using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    public GameObject joueur1SpawnPoint;
    public GameObject joueur2SpawnPoint;

   

    public GameObject warriorPrefab;
    public GameObject magePrefab;
    public GameObject oldwarriorPrefab;
    public GameObject bowmanPrefab;
    public GameObject WizzardPrefab;
    public GameObject PaladinPrefab;

    public TurnManager turnManager;
    

    private void Start()
    {
        if (PlayerPrefs.HasKey("Joueur1"))
        {
            string joueur1Choice = PlayerPrefs.GetString("Joueur1");
            SpawnPlayer(joueur1Choice, joueur1SpawnPoint);
        }

        if (PlayerPrefs.HasKey("Joueur2"))
        {
            string joueur2Choice = PlayerPrefs.GetString("Joueur2");
            SpawnPlayer(joueur2Choice, joueur2SpawnPoint);
        }
    }

    private void SpawnPlayer(string playerName, GameObject spawnPoint)
    {
        GameObject playerPrefab = null;

        
        switch (playerName)
        {
            case "Warrior":
                playerPrefab = warriorPrefab;
                break;
            case "Mage":
                playerPrefab = magePrefab;
                break;
            case "OldWarrior":
                playerPrefab = oldwarriorPrefab;
                break;
            case "Bowman":
                playerPrefab = bowmanPrefab;
                break;
            case "Wizzard":
                playerPrefab = WizzardPrefab;
                break;
            case "Paladin":
                playerPrefab = PaladinPrefab;
                break;
            
            default:
                Debug.LogError("Personnage non reconnu : " + playerName);
                break;
        }


        if (playerPrefab != null && spawnPoint != null)
        {
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);

            // Ajoutez le personnage à la liste _allies du TurnManager
            if (turnManager != null)
            {
                Ally allyComponent = playerInstance.GetComponent<Ally>();
                if (allyComponent != null)
                {
                    turnManager.AddAlly(allyComponent);
                }
            }
        }
        else
        {
            Debug.LogError("Impossible d'instancier le personnage pour le joueur : " + playerName);
        }
    }
}
