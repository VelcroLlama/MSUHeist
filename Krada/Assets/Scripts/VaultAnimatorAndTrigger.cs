using UnityEngine;
using System.Collections;

public class VaultAnimatorAndTrigger : MonoBehaviour {

    public Animator vault;
    public Animator screen;
    public bool entered = false;
    private bool count = false;
    private float lastTime=0;
    private float timePassed=0;
    private GameObject enteringObject; //ovo tu popuni sa onim objektom koji triggera stvar
    private bool CanClose=false;


	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (entered)
        {
            vault.SetBool("Entered", true);
            Destroy(enteringObject, 0.4f);
            screen.SetBool("Open", true);
            count = true;
            lastTime = Time.timeSinceLevelLoad;
            entered = false;
            Time.timeScale = 0;
            CanClose=true;

        }
        if (CanClose)
        {
            screen.SetBool("Open", false);
            CanClose = false;
        }

        if (count)
        {
            timePassed += (Time.timeSinceLevelLoad - lastTime);
            lastTime = Time.timeSinceLevelLoad;
            if (timePassed > 4)
            {
                count = false;
                timePassed = 0;
                lastTime = 0;
                Time.timeScale = 1;
            }
        }

	}

}
