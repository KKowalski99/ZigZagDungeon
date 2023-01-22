using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZigZagDungeon
{
    public class UIButtonsFunctionality : MonoBehaviour
    {    
        UIHandler uiHandler;

        private void Start()
        {
            if (TryGetComponent(out UIHandler _uIHandler)) { uiHandler = _uIHandler; }
            else Debug.LogError("PauseGame  script has not been found");
        }

 
        const string gameUITabName = "game";
        const string menuUITabName = "menu";
        const string quitUITabName = "quit";

        public void OptionsButton(bool buttonPressed)
        {
            if (!buttonPressed) uiHandler.SwitchUITabs(menuUITabName);
            else uiHandler.SwitchUITabs(gameUITabName);
        }  

        public void QuitButton(bool buttonPressed)
        {
            if (!buttonPressed) uiHandler.SwitchUITabs(quitUITabName); 
            else uiHandler.SwitchUITabs(gameUITabName);
        }
            
        
    }
}