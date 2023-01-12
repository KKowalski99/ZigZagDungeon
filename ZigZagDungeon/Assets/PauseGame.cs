using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
  

    public void Pause()
    {
        Time.timeScale = 0;
    }


    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
