using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class Collectible : MonoBehaviour
    {
        GameManager gameManager;

        private int goldPoints = 20;

        [SerializeField] string collectibleSFXname = "GoldSound";

        SoundManager soundManager;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();

            soundManager = FindObjectOfType<SoundManager>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameManager.AddGoldPoints(goldPoints);

                soundManager.Play(collectibleSFXname);

                Destroy(gameObject);

            }
        }
    }
}


