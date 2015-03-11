using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour {

    public Text counter;
    public Text LevelName;
    private int StartNumber;
    private int LeftNumber;
    public Animator ScreenFade;
    private float seconds = 0f;
    private int PlayersLeft {
		get {
            return GameObject.FindGameObjectsWithTag("InactivePlayer").Length + GameObject.FindGameObjectsWithTag("Player").Length; 
		}
	}


    void Awake()
    {
        StartNumber = PlayersLeft;
        seconds = 0;
        PlayerPrefs.SetInt("Passed", Application.loadedLevel);
        LevelName.text = "LEVEL " + Application.loadedLevel;
    }
    
    void Update()
    {
        LeftNumber=PlayersLeft;
        counter.text = "Starting Art: " + StartNumber + "\nRemaining Art: " + LeftNumber;
        if(LeftNumber==0){
            Time.timeScale=0;
            ScreenFade.SetBool("Open", true);
            seconds+=Time.unscaledDeltaTime;
            if(seconds>1)
            {
                Application.LoadLevel(Application.loadedLevel+1);
            }
        }
    }
}
