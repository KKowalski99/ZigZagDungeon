using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace ZigZagDungeon
{
    public class UIHandler : MonoBehaviour
    {
        public static UIHandler Instance;

        [Header("Text")]
        [SerializeField] Text gloryScoreText;
        [SerializeField] Text goldScoreText;
        [SerializeField] Text totalScoreText;

        [Header("TextFinal")]
        [SerializeField] Text gloryScoreFinalText;
        [SerializeField] Text goldScoreFinalText;
        [SerializeField] Text totalScoreFinalText;

        [Header("Tab")]
        [SerializeField] GameObject gameTab;
        [SerializeField] GameObject menuTab;
        [SerializeField] GameObject restartTab;
        [SerializeField] GameObject credits;
        [SerializeField] GameObject quit;


        [Header("Buttons")]
        [SerializeField] Button optionButton;
        [SerializeField] Button quitButton;

        [Header("ButtonsIcons")]
        [SerializeField] Sprite optionButtonDefaultImage;
        [SerializeField] Sprite optionButtonPressedImage;
        [SerializeField] Sprite quitButtonDefaultImage;
        [SerializeField] Sprite quitButtonPressedImage;


        private PauseGame pauseGame;
        private PlayerInput playerInput;
        UIButtonsFunctionality uiButtonManager;

        private int gloryScore;
        private int goldScore;

        [HideInInspector] public bool restartActive;

        private void Awake()
        {
            if (!Instance) Instance = this; 
            else Destroy(this);
        }
        
        private void Start()
        {
            if (TryGetComponent(out PauseGame _pauseGame)) pauseGame = _pauseGame;
            else Debug.LogError("PauseGame  script has not been found");

            if (TryGetComponent(out UIButtonsFunctionality _uiButtonManager)) uiButtonManager = _uiButtonManager;
            else Debug.LogError("UIButtonManager  script has not been found");

            playerInput = FindObjectOfType<PlayerInput>();
        }

        public void UpdateUI(int _gloryScore, int _goldScore)
        {
            gloryScore = _gloryScore;
            gloryScoreText.text = $"Glory: {gloryScore}";
            goldScore = _goldScore;
            goldScoreText.text = $"Gold: {goldScore}";
        }

        private void DisplayFinalScore()
        {
            gloryScoreFinalText.text = $"GLORY SCORE: {gloryScore}";
            goldScoreFinalText.text = $"GOLD SCORE: {goldScore}";

            int totalScore = gloryScore + goldScore;
            totalScoreFinalText.text = $"TOTAL SCORE: {totalScore}";
        }

        #region SwitchUITabs
        public void SwitchUITabs(string tabName)
        {
            switch (tabName)
            {
                case "game":

                    if (restartActive)
                    {
                        goto restarLabel;
                    }
                    else
                    {
                        gameTab.SetActive(true);
                        menuTab.SetActive(false);
                        restartTab.SetActive(false);
                        credits.SetActive(false);
                        quit.SetActive(false);
                    }

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
                restarLabel:

                    restartActive = true;

                    gameTab.SetActive(false);
                    menuTab.SetActive(false);
                    restartTab.SetActive(true);
                    credits.SetActive(false);
                    quit.SetActive(false);

                    playerInput.enabled = false;

                    FindObjectOfType<HideShowTopBottomUIPanels>().ShowUIElementsOnPlayerFail();
                    DisplayFinalScore();

                    restartActive = true;

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
        #endregion

        #region Buttons

        private bool optionButtonPressed;
        private bool quitButtonPressed;
        public void ButtonManager(string buttonName)
        {
            switch (buttonName)
            {
                case "options":
                    if (!optionButtonPressed)
                    {
                        optionButton.image.overrideSprite = optionButtonPressedImage;
                        ButtonState(buttonName, optionButtonPressed);
                        optionButtonPressed = true;

                        if (quitButtonPressed)
                        {
                            quitButton.image.overrideSprite = quitButtonDefaultImage;
                            quitButtonPressed = false;
                        }
                    }
                    else
                    {
                        optionButton.image.overrideSprite = optionButtonDefaultImage;
                        ButtonState(buttonName, optionButtonPressed);
                        optionButtonPressed = false;
                    }

                    return;
                case "quit":
                    if (!quitButtonPressed)
                    {

                        quitButton.image.overrideSprite = quitButtonPressedImage;

                        ButtonState(buttonName, quitButtonPressed);

                        quitButtonPressed = true;

                        if (optionButtonPressed)
                        {
                            optionButton.image.overrideSprite = optionButtonDefaultImage;
                            optionButtonPressed = false;
                        }

                    }
                    else
                    {

                        quitButton.image.overrideSprite = quitButtonDefaultImage;
                        ButtonState(buttonName, quitButtonPressed);
                        quitButtonPressed = false;

                    }
                    return;

            }
        }
        private void ButtonState(string buttonName, bool state)
        {
             if (buttonName == "options") { uiButtonManager.OptionsButton(state); }
            else if (buttonName == "quit") { uiButtonManager.QuitButton(state); }
            else Debug.LogError("button name won't match");
        }

        #endregion
    }
}