using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;

    GameManager gameManager;

    [SerializeField] string enemySFXname;

    SoundManager soundManager;

    private int gloryPoints = 20;
    private void Start()
    {
        player = FindObjectOfType<Player>();

        gameManager = FindObjectOfType<GameManager>();

        soundManager = FindObjectOfType<SoundManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.PerformAttack(this);
        }
    }

    public void PerformDeath()
    {
        gameManager.AddGloryPoints(gloryPoints);

        soundManager.Play(enemySFXname);

        Destroy(gameObject);
       
    }
}


