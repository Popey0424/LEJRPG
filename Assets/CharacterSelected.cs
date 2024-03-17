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
    // Ajoutez les autres prefabs de personnages nécessaires

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

        // Assignez le prefab correspondant au nom du personnage
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
            // Ajoutez les autres cas pour les autres personnages
            default:
                Debug.LogError("Personnage non reconnu : " + playerName);
                break;
        }

        // Instanciez le prefab du joueur au point de spawn
        if (playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Impossible d'instancier le personnage pour le joueur : " + playerName);
        }
    }
}
