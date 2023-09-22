using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour
{
    //Panel
    [SerializeField]
    GameObject panelMsg;

    Animator animUser;
    // Start is called before the first frame update
    void Start()
    {
        animUser = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameManager.gameRestart)
            RestartArm();
    }

    //My Functions

    public void ActivateRock()
    {
        if (GameManager.gameManager.gameOnHold)
            UserActivation("Rock");
        else
            panelMsg.SetActive(true);
    }

    public void ActivatePaper()
    {
        if (GameManager.gameManager.gameOnHold)
            UserActivation("Paper");
        else
            panelMsg.SetActive(true);
    }

    public void ActivateScissors()
    {
        if (GameManager.gameManager.gameOnHold)
            UserActivation("Scissors");
        else
            panelMsg.SetActive(true);
    }

    void RestartArm()
    {
        panelMsg.SetActive(false);
        animUser.SetTrigger("Reset");
        GameManager.gameManager.userRestart = true;
    }

    void UserActivation(string choice)
    {
        GameManager.gameManager.gameOnHold = false;
        GameManager.gameManager.userHasChosen = true;
        GameManager.gameManager.userChoice = choice;
        //Debug.Log("User " + choice);
        animUser.SetTrigger(choice);
    }

}
