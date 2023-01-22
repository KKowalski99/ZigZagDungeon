using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class PlayerLocomotion : MonoBehaviour
    {

        Player player;
        enum Direction { Left, Right };
        Direction dir;

        private float speed;



        private void Start()
        {
            player = GetComponent<Player>();
            speed = player.speed;

            dir = Direction.Left;

        }
        void FixedUpdate() => Locomotion();
        

        void Locomotion()
        {
            if (dir == Direction.Left)
            {
                transform.Translate(-0.45f * speed, 0, 0.45f * speed);
            }
            else
            {
                transform.Translate(0.45f * speed, 0, 0.45f * speed);
            }
        }

        public void ChangeDirection(GameObject root)
        {

            if (dir == Direction.Right)
            {
                dir = Direction.Left;

                root.transform.eulerAngles = new Vector3(root.transform.eulerAngles.x, -45, root.transform.eulerAngles.z);

            }
            else if (dir == Direction.Left)
            {
                dir = Direction.Right;

                root.transform.eulerAngles = new Vector3(root.transform.eulerAngles.x, 45, root.transform.eulerAngles.z);
            }
        }

    }
}