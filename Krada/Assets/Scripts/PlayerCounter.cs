using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour {

    public Text counter;
    public Text LevelName;
    private int StartNumber;
    private int LeftNumber;
    public Animator ScreenFade;
    public int ArtLost=0;
    private bool Restart = false;
    private bool OK;
    public Animator prompt;
    public Text endingtext;
    private int PlayersLeft {
		get {
            return GameObject.FindGameObjectsWithTag("InactivePlayer").Length + GameObject.FindGameObjectsWithTag("Player").Length; 
		}
	}


    void Awake()
    {
        ArtLost = 0;
        StartNumber = PlayersLeft;
        PlayerPrefs.SetInt("Passed", Application.loadedLevel);
        LevelName.text = "LEVEL " + Application.loadedLevel;
        OK = false;
    }
    
    void Update()
    {
        LeftNumber=PlayersLeft;
        counter.text = "Starting Art: " + StartNumber + "\nRemaining Art: " + LeftNumber;
        if(LeftNumber==0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ScreenFade.SetBool("Open", true);
            if(ArtLost >= (StartNumber/2))
            {
                Restart=true;
                endingtext.text="Art saved: " + (StartNumber-ArtLost) + " Art Lost: " + ArtLost + "\nYou haven't saved enough Art! \nPress OK! to restart level " + Application.loadedLevel + ".";
            } 
            else 
            {
                endingtext.text="Art saved: " + (StartNumber-ArtLost) + " Art Lost: " + ArtLost + "\nHooray, you saved enough Art! \nPress OK! to continue to level " + (Application.loadedLevel+1) + ".";
            }

            prompt.SetTrigger("Ending");
            if (OK)
            {
                if (Restart)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
                else
                {
                    Application.LoadLevel(Application.loadedLevel + 1);
                }
            }
        }
    }
    public void SetOK()
    {
        OK = true;
    }
}

    

