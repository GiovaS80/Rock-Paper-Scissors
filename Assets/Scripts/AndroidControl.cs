using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidControl : MonoBehaviour
{
    Animator animAndroid;
    // Start is called before the first frame update
    void Start()
    {
        animAndroid = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.userHasChosen)
            CanStart();
        if (GameManager.gameManager.gameRestart)
            RestartArm();
    }

    //My Functions

    void CanStart()
    {//inizio funzione che fa scegliere ad android
        GameManager.gameManager.userHasChosen = false;
        int numberRandom = Random.Range(1, 4);
        switch (numberRandom)
        {
            case 1:
                AndroidActivation("Rock");
                break;
            case 2:
                AndroidActivation("Paper");
                break;
            case 3:
                AndroidActivation("Scissors");
                break;
            default:
                Debug.Log("ERRRORRRRREEEEEEEEEEEEE");
                break;
        }
    }//fine funzione che fa scegliere ad android

    void AndroidActivation(string choice)
    {
        GameManager.gameManager.androidChoice = choice;
        animAndroid.SetTrigger(choice);
        //Debug.Log("Android " + choice);
    }

    void RestartArm()
    {
        animAndroid.SetTrigger("Reset");
        GameManager.gameManager.androidRestart = true;
    }

}
