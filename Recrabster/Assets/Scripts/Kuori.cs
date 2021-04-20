using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class Kuori : MonoBehaviour
    {

        public GameObject mestari;
        public Master mestariKoodi;

        // Start is called before the first frame update
        void Start()
        {
            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                mestariKoodi.kuorienMäärä += 1;
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}