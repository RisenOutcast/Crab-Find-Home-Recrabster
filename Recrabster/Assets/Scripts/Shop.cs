using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class Shop : MonoBehaviour
    {
        public GameObject AAAAAAAAAA;
        public GameObject shopPage;

        public GameObject Player;

        public GameObject mestari;
        public Master mestariKoodi;

        public GameObject CheatButton;

        public GameObject Simpukka;
        public GameObject Shield;
        public GameObject Boomerang;

        // Start is called before the first frame update
        void Start()
        {
            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();

            Player = GameObject.FindWithTag("Player");

            CheatButton.SetActive(false);

            if (mestariKoodi.hasBoughtFire1 == true)
            {
                Simpukka.SetActive(false);

                if(mestariKoodi.hasBoughtFire3 == true && mestariKoodi.hasBoughtFire1 == true)
                {
                    Boomerang.SetActive(false);
                }
                else if (mestariKoodi.hasBoughtFire3 == false && mestariKoodi.hasBoughtFire1 == true)
                {
                    Boomerang.SetActive(true);
                }
            }
            else
            {
                Simpukka.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                AAAAAAAAAA.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                AAAAAAAAAA.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (AAAAAAAAAA.activeSelf && !shopPage.activeSelf)
            {
                if ((Input.GetMouseButtonUp(0)))
                {
                    shopPage.SetActive(true);
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
            }

            if (Input.GetKeyDown("escape"))
            {
                shopPage.SetActive(false);
                gameObject.GetComponent<Collider2D>().enabled = true;
            }

            if (Input.GetKeyDown("p"))
            {
                shopPage.SetActive(true);
                gameObject.GetComponent<Collider2D>().enabled = false;
            }

        }
        public void BuyGun()
        {
            if (mestariKoodi.kuorienMäärä < 5)
            {
                Debug.Log("Not Enough");
            }
            else
            {
                mestariKoodi.kuorienMäärä -= 5;
                mestariKoodi.hasBoughtFire1 = true;
                Simpukka.SetActive(false);
                Boomerang.SetActive(true);

            }
        }

        public void BuyBoomerang()
        {
            if (mestariKoodi.kuorienMäärä < 25)
            {
                Debug.Log("Not Enough");
            }
            else
            {
                mestariKoodi.kuorienMäärä -= 25;
                mestariKoodi.hasBoughtFire3 = true;
                Boomerang.SetActive(false);

            }
        }

        public void Weed()
        {
            if (mestariKoodi.kuorienMäärä < 5)
            {
                Debug.Log("Not Enough");
            }
            else
            {
                if (mestariKoodi.Playerhealth < 100)
                {
                    mestariKoodi.Playerhealth += 20;
                    mestariKoodi.kuorienMäärä -= 5;
                }
            }
        }

        public void BuyShield()
        {
            if (mestariKoodi.kuorienMäärä < 15)
            {
                Debug.Log("Not Enough");
            }
            else
            {
                if (mestariKoodi.Playershield < 100)
                {
                    mestariKoodi.Playershield += 100;
                    mestariKoodi.kuorienMäärä -= 15;
                }
            }
        }

        public void CloseShop()
        {
            shopPage.SetActive(false);
        }
    }
}