using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class StarProjectile : MonoBehaviour
    {
        public float speed;
        public float time = 3;

        Vector3 shootAt;

        public GameObject player;

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            StartCoroutine(FindTransform());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Seinä")
            {
                Destroy(gameObject);
            }
            if (collision.tag == "Player")
            {
                Destroy(gameObject, 0.01f);
            }
        }


        // Update is called once per frame
        void Update()
        {

            Destroy(gameObject, time);

        }

        void FixedUpdate()
        {
            float step = 1 * speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, shootAt, step);
        }

        IEnumerator FindTransform()
        {
            shootAt = player.transform.position;
            yield return new WaitForSeconds(0.1F);
        }
    }
}