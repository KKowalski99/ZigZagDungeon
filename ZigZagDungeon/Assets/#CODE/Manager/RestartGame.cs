using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZigZagDungeon
{
    public class RestartGame : MonoBehaviour
    {

        UIHandler uiHandler;

        private void Start()
        {
            uiHandler = GetComponent<UIHandler>();
        }
        
        public void Restart()
        {
            uiHandler.restartActive = false;
            string thisSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisSceneName);
        }
    }
}