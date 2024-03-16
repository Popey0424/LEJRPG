using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GetReadyForTheNextBattle: MonoBehaviour
{
    public Animation animationToPlay;
    
    public float delayAfterAnimation = 1.0f; // Ajoutez le temps d'attente souhait� ici

    private bool animationPlayed = false;

    void Update()
    {
        if (!animationPlayed && !animationToPlay.isPlaying)
        {
            animationToPlay.Play();
            animationPlayed = true;
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        // Attend la fin de l'animation
        yield return new WaitForSeconds(animationToPlay.clip.length);

        // Attend un petit temps suppl�mentaire
        yield return new WaitForSeconds(delayAfterAnimation);

        // Charge la sc�ne suivante
        SceneManager.LoadScene("Gameplay");
    }
}