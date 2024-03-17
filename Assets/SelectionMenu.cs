using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using DG.Tweening;

public class SelectionMenu : MonoBehaviour
{
    public GameObject TheChoiceOne; 
    public GameObject TheChoiceTwo;

    public Sprite Warrior;
    public Sprite OldWarrior;
    public Sprite Wizzard;
    public Sprite Mage;
    public Sprite Bowman;
    public Sprite Paladin;

    public Image Fade;

    

    public bool choiceOne = false;
    public bool choiceTwo = false;

    private string _firstChoice;
    private string _secondChoice;

    private void Start()
    {
        _firstChoice = "Warrior";
        _secondChoice = "Mage";
    }

    public void OnChoiceOne()
    {
        choiceOne = true;
        choiceTwo = false;
    }

    public void OnChoiceTwo()
    {
        choiceOne = false;
        choiceTwo = true;
    }

    public void GoButton()
    {
        PlayerPrefs.SetString("Joueur1", _firstChoice);
        PlayerPrefs.SetString("Joueur2", _secondChoice);
        Fade.DOFade(1, 2.9f).OnComplete(FadeComplete);
        
    }

    public void FadeComplete()
    {
        SceneManager.LoadScene("GetReadyForTheNextBattle");
    }

    public void WarriorChoice()
    {
        if (choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = Warrior;
            _firstChoice = "Warrior";
        }
        if (choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = Warrior;
            _secondChoice = "Warrior";
        }
        
    }
    public void WizzardChoice()
    {
        if(choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = Wizzard;
            _firstChoice = "Wizzard";
        }
        if(choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = Wizzard;
            _secondChoice = "Wizzard";
        }
    }

    public void MageChoice()
    {
        if (choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = Mage;
            _firstChoice = "Mage";

        }
        if (choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = Mage;
            _secondChoice = "Mage";
        }
    }

    public void OldWarriorChoice()
    {
        if(choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = OldWarrior;
            _firstChoice = "OldWarrior";
        }
        if (choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = OldWarrior;
            _secondChoice = "OldWarrior";
        }
    }

    public void PaladinChoice()
    {
        if (choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = Paladin;
            _firstChoice = "Paladin"; 
        }
        if (choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = Paladin;
            _secondChoice = "Paladin";
        }
    }

    public void BowmanChoice()
    {
        if( choiceOne == true)
        {
            TheChoiceOne.gameObject.GetComponent<Image>().sprite = Bowman;
            _firstChoice = "Bowman";
        }
        if (choiceTwo == true)
        {
            TheChoiceTwo.gameObject.GetComponent<Image>().sprite = Bowman;
            _secondChoice = "Bowman";
        }
    }
}
