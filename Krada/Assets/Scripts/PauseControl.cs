using UnityEngine;
using System.Collections;

public class PauseControl : MonoBehaviour {

    public Animator pause;
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.GetBool("Open"))
            {
                pause.SetBool("Open", false);
                Time.timeScale = 1;
            }
            else
            {
                pause.SetBool("Open", true);
                Time.timeScale = 0;
            }
        }
        
    
    }

    public void Exit()
    {
        Application.Quit();
    }
}
