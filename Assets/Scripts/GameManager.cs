using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //Text
    [SerializeField]
    TextMeshProUGUI displayAndroid, displayUser, displayWhoWin, DisplayWhy;

    //Panel
    [SerializeField]
    GameObject panelInstructions, panelDown;

    //String Containing The Choice
    public string userChoice, androidChoice;
    string wait;

    //Public Boolean - AndroidControl && UserControl Scripts use this boolean
    public bool gameOnHold, gameRestart, userHasChosen, userRestart, androidRestart;

    //Private Boolean
    bool gameUnderControl, instructionsOn, timerIsRunning;

    //Scores
    int userScores, androidScores;

    //timer
    float timeRemaining;

    //message
    string msg2;

    private void Awake()
    {
        gameManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOnHold = gameUnderControl =false;
        gameRestart = userHasChosen = false;
        userRestart = androidRestart = false;
        timerIsRunning = false;
        timeRemaining = 5;
        wait = "Wait";
        userChoice = androidChoice = wait;
        userScores = androidScores = 0;
        //UserPushInstructions();
        UserPushPlay();
    }

    // Update is called once per frame
    void Update()
    {
        if (userChoice != wait && androidChoice != wait && !gameUnderControl)
        {
            CheckWhoWon();
        }
            
        if (userRestart && androidRestart)
            NewMatch();

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                //Debug.Log("timer = " + (int) timeRemaining);
                msg2 = $"You Chose {userChoice} - Android Chosen {androidChoice} \n Press RESTART To Play Another Match or wait {(int) timeRemaining} ";
                DisplayWhy.text = msg2;
            }
            else
            {
                //Debug.Log("Time has run out!");
                timeRemaining = 0;
                //timerIsRunning = false;
                UserPushRestart();
            }
        }
    }

    //My Functions

    public void UserPushPlay()
    {
        instructionsOn = false;
        panelInstructions.SetActive(instructionsOn);
        gameOnHold = true;
        Time.timeScale = 1;
    }

    public void UserPushInstructions()
    {
        instructionsOn = true;
        panelInstructions.SetActive(instructionsOn);
        Time.timeScale = 0;
    }

    public void UserPushRestart()
    {
        if (gameUnderControl && timeRemaining<=4)
        {
            gameRestart = true;
            gameUnderControl = false;
            userChoice = androidChoice = wait;
            timerIsRunning = false;
            timeRemaining = 5;
        }
    }

    public void UserPushQuitButton()
    {
        Application.Quit();
    }

    void CheckWhoWon()
    {//inizio funzione Controlla Chi Ha Vinto
        gameUnderControl = true;
        
        if (userChoice != androidChoice)
        {//inizio if se scelta dei due giocatori e' diversa
            if (userChoice == "Rock" && androidChoice == "Scissors")
                ShowMsg("User");
            else if(userChoice == "Paper" && androidChoice == "Rock")
                ShowMsg("User");
            else if(userChoice == "Scissors" && androidChoice == "Paper")
                ShowMsg("User");
            else
                ShowMsg("Android");
        }//fine if se scelta dei due giocatori e' diversa
        else
            ShowMsg("Equal");
    }//fine funzione Controlla Chi Ha Vinto

    void ShowMsg(string theWinner)
    {//Inizio funzione mostra messaggio di chi ha vinto
        string msg1;
        if(theWinner == "User")
        {
            msg1 = "YOU WON";
            displayWhoWin.color = new Color(0, 255, 0, 255);
            displayWhoWin.text = msg1;
            userScores++;
            displayUser.text = userScores.ToString();
        }
        else if(theWinner == "Android") {
            msg1 = "Sorry, Android Won";
            displayWhoWin.color = new Color(255, 0, 0, 255);
            displayWhoWin.text = msg1;
            androidScores++;
            displayAndroid.text = androidScores.ToString();
        }
        else
        {
            msg1 = "No Winner Cause Draw";
            displayWhoWin.color = new Color(0, 0, 0, 255);
            displayWhoWin.text = msg1;
        }
        panelDown.SetActive(true);
        timerIsRunning = true;
    }//fine funzione mostra messaggio di chi ha vinto

    void NewMatch()
    {
        gameRestart = userRestart = androidRestart = false;
        panelDown.SetActive(false);
        gameOnHold = true;
        
    }

}
