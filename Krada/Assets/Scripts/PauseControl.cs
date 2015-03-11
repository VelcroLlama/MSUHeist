using UnityEngine;
using System.Collections;

public class PauseControl : MonoBehaviour {

    public Animator pause;
    public Animator start;
    private bool started=false;

    void Awake()
    {
        Time.timeScale = 0;
        started = false;
    }

    void Update () {

        
        
        
        if (Input.GetKeyDown(KeyCode.Escape)&& started)
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

        if (Input.GetKeyDown(KeyCode.Escape) && !started)
        {
            start.SetBool("OK", true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            Time.timeScale = 1;
            started = true;
        }
        
    
    }

    public void StartPanelClose()
    {
        start.SetBool("OK", true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
        started = true;
    }

    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        pause.SetBool("Open", false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
