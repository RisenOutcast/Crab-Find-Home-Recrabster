using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab {
    public class VihuChase : MonoBehaviour {

        public Transform player;
        public float speed = 50f;

        void Start()
        {

        }

        void Update()
        {
            if (player)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                float step = speed * Time.deltaTime;

                if (dist < 12)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.position, step);
                }
            }
        }
    }
}