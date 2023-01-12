using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{

   static Enemy enemyReference;

    Player player;
    private Animator anim;

    readonly string attackBoolInAnimotor = "Attack";
    private void Start()
    {
        player = GetComponent<Player>();
        anim = player.anim;
    }
    

    public void PerformAttackOnEnemy(Enemy enemy)
    {
        enemyReference = enemy;
       
        anim.SetBool(attackBoolInAnimotor.ToString(), true);
    }


    public void EndAttackOnEnemy()
    {
        anim.SetBool(attackBoolInAnimotor.ToString(), false);

        if (enemyReference != null)
        {
            enemyReference.PerformDeath();
            ClearReferanceToEnemy();
        }
    }


   void ClearReferanceToEnemy()
    {
        enemyReference = null;
    }
}
