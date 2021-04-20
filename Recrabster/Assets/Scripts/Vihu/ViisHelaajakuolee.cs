using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class ViisHelaajakuolee : MonoBehaviour
    {

        private float health = 5;


        // Use this for initialization
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "PlayerAttack")
            {
                health -= 1;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}