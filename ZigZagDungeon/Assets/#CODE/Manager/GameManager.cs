using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        private int gloryScore;
        private int goldScore;

        UIHandler uiHandler;

        private void Awake()
        {
            if (!Instance) Instance = this; else Destroy(this);

            if (TryGetComponent(out UIHandler _uIHandler)) { uiHandler = _uIHandler; }
            else Debug.LogError("PauseGame  script has not been found");
        }

        public void AddGloryPoints(int gloryPoints)
        {
            gloryScore += gloryPoints;
            UpdateUI();
        }

        public void AddGoldPoints(int goldPoints)
        {
            goldScore += goldPoints;
            UpdateUI();
        }

        private void UpdateUI() => uiHandler.UpdateUI(gloryScore, goldScore);
       

        const string restartGame = "restart";
        public void Restart() => uiHandler.SwitchUITabs(restartGame);
        


        public void ExitGame() => Application.Quit();
        
    }

}