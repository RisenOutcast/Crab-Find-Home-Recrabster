using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class Projectiles : MonoBehaviour
    {
        public Vector2 speed;
        public float time = 2;

        Rigidbody2D rb2d;

        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = speed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Seinä")
            {
                Destroy(gameObject);
            }
            if (collision.tag == "Vihu")
            {
                Destroy(gameObject, 0.01f);
            }
            if (collision.tag == "Boss")
            {
                Destroy(gameObject, 0.01f);
            }
        }


        // Update is called once per frame
        void Update()
        {

            rb2d.velocity = speed;
            Destroy(gameObject, time);

        }
    }
}