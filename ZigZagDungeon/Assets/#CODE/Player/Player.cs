using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ZigZagDungeon
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public static Player Instance;
        private PlayerLocomotion playerLocomotion;
        private PlayerAnimationHandler playerAnimationHandler;
        public GameObject root;
        public Animator anim;

        private void Awake()
        {
            if (!Instance) Instance = this;
            else Destroy(this);

            if (speed == 0) Debug.LogError("speed value is set to 0");

            if (TryGetComponent(out PlayerLocomotion _playerLocomotion)) playerLocomotion = _playerLocomotion;
            else Debug.LogError("PlayerLocomotion script has not been found");

            if (TryGetComponent(out PlayerAnimationHandler _playerAnimationHandler)) playerAnimationHandler = _playerAnimationHandler;
            else Debug.LogError("playerAnimationHandler script has not been found");


            if (TryGetComponent(out Animator _anim)) anim = _anim;
            else Debug.LogError("Player animator has not been found");
        }
        public void ChangeDirectionInput() => playerLocomotion.ChangeDirection(root);

        public void CharacterIsFalling()
        {
            playerLocomotion.enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            FindObjectOfType<GameManager>().Restart();
        }
        public void PerformAttack(Enemy enemy) => playerAnimationHandler.PerformAttackOnEnemy(enemy);   
    }
}