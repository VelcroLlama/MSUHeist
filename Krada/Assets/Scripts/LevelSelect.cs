using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

    public Button[] LevelsButton;
    private int i;

    public void ButtonActivate()
    {
        if (PlayerPrefs.HasKey("Passed"))
        {
            for (i = 1; i < LevelsButton.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt("Passed"))
                    LevelsButton[i].interactable = true;
                else
                LevelsButton[i].interactable = false;

            }
        }
        else
        {
            for (i = 1; i < LevelsButton.Length; i++)
            {
                    LevelsButton[i].interactable = false;
            }
        }
    }
    public int level;

    public void LoadLevel1()
    {
        Application.LoadLevel(1);
    }
    public void LoadLevel2()
    {
        Application.LoadLevel(2);
    }
    public void LoadLevel3()
    {
        Application.LoadLevel(3);
    }
    public void LoadLevel4()
    {
        Application.LoadLevel(4);
    }
    public void LoadLevel5()
    {
        Application.LoadLevel(5);
    }
    public void LoadLevel6()
    {
        Application.LoadLevel(6);
    }
    public void LoadLevel7()
    {
        Application.LoadLevel(7);
    }
    public void LoadLevel8()
    {
        Application.LoadLevel(8);
    }

}
