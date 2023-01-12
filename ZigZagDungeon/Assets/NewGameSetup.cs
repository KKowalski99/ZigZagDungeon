using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewGameSetup : MonoBehaviour
{
    private InputManager inputManager;
    private Player player;



    private void Start()
    {
        if (FindObjectOfType<InputManager>() != null)
        {
            inputManager = FindObjectOfType<InputManager>();
            inputManager.enabled = false;
        }
        else
        {
            Debug.LogError("PlayerInputHandler script could not be found");
        }

        player = FindObjectOfType<Player>();
        inputManager = FindObjectOfType<InputManager>();



        Invoke(nameof(Setup), 0.01f);

    }


    private void Setup()
    {
        GetComponent<PauseGame>().Pause();
        DisablePlayerInput();
    }
    private void DisablePlayerInput()
    {
        inputManager.enabled = false;
       
    }

    public void StartNewGame()
    {
        EnablePlayerInput();
        GetComponent<PauseGame>().Unpause();
    }

    private void EnablePlayerInput()
    {
        inputManager.enabled = true;
     

        EndSetup();
    }
    private void EndSetup()
    {
        this.enabled = false;

    }
    
}
