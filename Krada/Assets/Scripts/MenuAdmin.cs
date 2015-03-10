using UnityEngine;
using System.Collections;

public class MenuAdmin : MonoBehaviour
{
    public Animator menu;
    public Animator options;
    public Animator levels;

    void Awake()
    {
        menu.SetBool("closed", false);
        options.SetBool("closed", true);
        levels.SetBool("closed", true);
    }
    
    public void MenuChange()
    {
        if (!menu.GetBool("closed"))
            {
                menu.SetBool("closed", true);
            }
            else
            {
                menu.SetBool("closed", false);
            }

    }

    public void OptionsChange()
    {
        if (!options.GetBool("closed"))
            {
                options.SetBool("closed", true);
            }
            else
            {
                options.SetBool("closed", false);
            }
    }

    public void LevelsChange()
    {
        if (!levels.GetBool("closed"))
        {
            levels.SetBool("closed", true);
        }
        else
        {
            levels.SetBool("closed", false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}