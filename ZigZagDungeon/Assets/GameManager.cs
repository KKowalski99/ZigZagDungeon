using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 public static GameManager instance;
  


    private int gloryScore;



    private int goldScore;
    


    public delegate void totalScoreSum(int gloryPoints, int goldPoints, float time);

    private enum pointsTypes {glory, gold }

    UIHandler uiHandler;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else Destroy(this);

        uiHandler = GetComponent<UIHandler>(); 
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

    private void TotalScoreSum(int gloryPoints, int goldPoints, float time)
    {
        var obj = new GameManager();
        totalScoreSum totalSum = obj.TotalScoreSum;


    }
  

    private void UpdateUI()
    {
        uiHandler.UpdateUI(gloryScore, goldScore);
    }

    public void Restart()
    {
        uiHandler.SwitchUITabs("restart");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}

