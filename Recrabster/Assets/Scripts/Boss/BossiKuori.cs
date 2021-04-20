using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class BossiKuori : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Master.instance.kuorienMäärä += 1;
                Master.instance.YouWin = true;
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}