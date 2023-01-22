using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZigZagDungeon
{
    public class NewGameSetup : MonoBehaviour
    {
        private string soundManagerMusicName = "Music";
        private PlayerInput playerInput;
        SoundManager soundManager;



        private void Start()
        {
            playerInput = FindObjectOfType<PlayerInput>();
            soundManager = FindObjectOfType<SoundManager>();
            Setup();
        }


        private void Setup()
        {
            GetComponent<PauseGame>().Pause();
            DisablePlayerInput();
        }
        private void DisablePlayerInput() => playerInput.enabled = false;

        

        public void StartNewGame()
        {
            soundManager.Play(soundManagerMusicName);
            GetComponent<PauseGame>().Unpause();
            EnablePlayerInput();
        }

        private void EnablePlayerInput()
        {
            playerInput.enabled = true;


            EndSetup();
        }
        private void EndSetup()
        {
            this.enabled = false;

        }

    }
}