using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class NextBattle : MonoBehaviour
{

    public Animation animationToPlay;
    public Image imageFade;

    public float delayAfterAnimation = 1.0f; // Ajoutez le temps d'attente souhaité ici

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

        // Attend un petit temps supplémentaire
        yield return new WaitForSeconds(delayAfterAnimation);

        // Charge la scène suivante
        imageFade.DOFade(1, 1.5f).OnComplete(FadeComplete);
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene("Gameplay2");
    }
}

