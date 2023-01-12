using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIHandler : MonoBehaviour
{
    [SerializeField] Text gloryScoreText;
    [SerializeField] Text goldScoreText;
    [SerializeField] Text totalScoreText;


    [SerializeField] GameObject gameTab;
    [SerializeField] GameObject menuTab;
    [SerializeField] GameObject restartTab;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject quit;


    [SerializeField] Text gloryScoreFinalText;
    [SerializeField] Text goldScoreFinalText;
    [SerializeField] Text totalScoreFinalText;



    private PauseGame pauseGame;
    private PlayerInput playerInput;

    private int gloryScore;
    private int goldScore;

    private void Start()
    {
        pauseGame = GetComponent<PauseGame>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public void UpdateUI(int _gloryScore, int _goldScore)
    {
        gloryScore = _gloryScore;
        gloryScoreText.text = $"Glory: {gloryScore.ToString()}";
        goldScore = _goldScore;
        goldScoreText.text = $"Gold: {goldScore.ToString()}";
       
       
    }

    private void DisplayFinalScore()
    {
        gloryScoreFinalText.text = $"GLORY SCORE: {gloryScore.ToString()}";
       goldScoreFinalText.text = $"GOLD SCORE: {goldScore.ToString()}";


        int totalScore = gloryScore + gloryScore;
        totalScoreFinalText.text = $"TOTAL SCORE: {totalScore.ToString()}";
    }

    public void NewGameStartScreenOn()
    {

    }
    public void NewGameStartScreenOff()
    {

    }


    public void SwitchUITabs(string tabName)
    {
        switch(tabName)
        {
            case "game":
                gameTab.SetActive(true);
                menuTab.SetActive(false);
                restartTab.SetActive(false);
                credits.SetActive(false);
                quit.SetActive(false);

               // pauseGame.Unpause();
             //   playerInput.enabled = true;
                return;

            case "menu":
                gameTab.SetActive(false);
                menuTab.SetActive(true);
                restartTab.SetActive(false);
                credits.SetActive(false);
                quit.SetActive(false);

                pauseGame.Pause();
                playerInput.enabled = false;
                return;

            case "restart":
                gameTab.SetActive(false);
                menuTab.SetActive(false);
                restartTab.SetActive(true);
                credits.SetActive(false);
                quit.SetActive(false);

                playerInput.enabled = false;

                FindObjectOfType<ManageTopBottomUI>().ShowUIElementsOnPlayerFail();
                DisplayFinalScore();

                return;

            case "credits":
                gameTab.SetActive(false);
                menuTab.SetActive(false);
                restartTab.SetActive(false);
                credits.SetActive(true);
                quit.SetActive(false);

                pauseGame.Pause();
                playerInput.enabled = false;

                return;

            case "quit":
                gameTab.SetActive(false);
                menuTab.SetActive(false);
                restartTab.SetActive(false);
                credits.SetActive(false);
                quit.SetActive(true);

                pauseGame.Pause();
                playerInput.enabled = false;

                return;
        }
    }



}
