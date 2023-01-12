using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public static Player instance;

    private PlayerLocomotion playerLocomotion; 
    private PlayerAnimationHandler playerAnimationHandler;
    private InputManager inputManager;
    public GameObject root;

    public Animator anim;



    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

     

        if (speed == 0) Debug.LogWarning("speed value is set to 0");

        if (GetComponent<PlayerLocomotion>() == null) gameObject.AddComponent<PlayerLocomotion>();
        playerLocomotion = GetComponent<PlayerLocomotion>();

        if (GetComponent<InputManager>() == null) gameObject.AddComponent<InputManager>();
        inputManager = GetComponent<InputManager>();

        if (GetComponent<PlayerAnimationHandler>() == null) gameObject.AddComponent<PlayerAnimationHandler>();
        playerAnimationHandler = GetComponent<PlayerAnimationHandler>();


        anim = GetComponent<Animator>();


    }

 public void ChangeDirectionInput()
    {
        playerLocomotion.ChangeDirection(root);
    }

    public void CharacterIsFalling()
    {
    playerLocomotion.enabled = false;
    GetComponent<InputManager>().enabled = false;
        FindObjectOfType<GameManager>().Restart();
    }

    public void PerformAttack(Enemy enemy)
    {
      
        playerAnimationHandler.PerformAttackOnEnemy(enemy);
    }
}
