using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZigZagDungeon
{
    public class PlayerAnimationHandler : MonoBehaviour
    {

        static Enemy enemyReference, enemySecondaryRefence;

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
            if (enemyReference == null)
            {
                enemyReference = enemy;
            }
            else enemySecondaryRefence = enemy;

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

            if (enemySecondaryRefence != null)
            {
                enemyReference = enemySecondaryRefence;
                enemySecondaryRefence = null;
                PerformAttackOnEnemy(enemyReference);
            }
        }
    }
}