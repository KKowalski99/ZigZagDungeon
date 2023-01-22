using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZigZagDungeon
{
    public class PlayerLocomotion : MonoBehaviour
    {

        Player player;
        enum direction { Left, Right };
        private float speed;

        private static string dir;

        private void Start()
        {
            player = GetComponent<Player>();
            speed = player.speed;

            dir = direction.Left.ToString();

        }
        void FixedUpdate() => Locomotion();
        

        void Locomotion()
        {
            if (dir == direction.Left.ToString())
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

            if (dir == direction.Right.ToString())
            {
                dir = direction.Left.ToString();

                root.transform.eulerAngles = new Vector3(root.transform.eulerAngles.x, -45, root.transform.eulerAngles.z);

            }
            else if (dir == direction.Left.ToString())
            {
                dir = direction.Right.ToString();

                root.transform.eulerAngles = new Vector3(root.transform.eulerAngles.x, 45, root.transform.eulerAngles.z);
            }
        }

    }
}