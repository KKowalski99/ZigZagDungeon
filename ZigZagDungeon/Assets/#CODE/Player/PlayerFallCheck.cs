using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class PlayerFallCheck : MonoBehaviour
    {
        float offset = -0.01f;

        Player player;
        GameObject _root;

        Vector3 initialPos;

        private void Start()
        {
            player = GetComponent<Player>();

            _root = player.root;

            initialPos = _root.transform.position;
            InvokeRepeating(nameof(GroundCheck), 0, 0.1f);
        }



        void GroundCheck()
        {
            float rootPosY = _root.transform.position.y;
            if (rootPosY < initialPos.y + offset)
            {
                player.CharacterIsFalling();

            }
            else
            {
                return;
            }

        }
    }
}
