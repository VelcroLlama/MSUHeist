using UnityEngine;
using System.Collections;

public class PauseControl : MonoBehaviour {

    public Animator pause;
    public Animator start;

    void Awake()
    {
        Time.timeScale = 0;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause.GetBool("Open"))
            {
                pause.SetBool("Open", false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false; 


            }
            else
            {
                pause.SetBool("Open", true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; 

            }
        }
        
    
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartPanelClose()
    {
        start.SetBool("OK", true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}
