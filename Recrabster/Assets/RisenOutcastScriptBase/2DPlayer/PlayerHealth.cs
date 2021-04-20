using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class PlayerHealth : MonoBehaviour
    {
        public float PlayerStartingHealth = 100;
        public float PlayerCurrentHealth = 1;
        public float PlayerCurrentShield;

        public Slider PlayerHealthbar;
        public float PlayerUIHealth;
        public float UIShield;

        public Slider Shieldbar;
        public GameObject ShieldbarObject;
        public GameObject Kubla;
        public GameObject KublaPrefab;

        Animator anim;

        public GameObject mestari;
        public Master mestariKoodi;

        void Start()
        {
            anim = GetComponent<Animator>();

            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();

            PlayerCurrentHealth = mestariKoodi.Playerhealth;
            PlayerCurrentShield = mestariKoodi.Playershield;

            PlayerUIHealth = PlayerCurrentHealth;
            PlayerHealthbar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
            PlayerHealthbar.maxValue = PlayerStartingHealth;
            Shieldbar = GameObject.FindGameObjectWithTag("Shieldbar").GetComponent<Slider>();
            ShieldbarObject = GameObject.FindGameObjectWithTag("Shieldbar");
            Kubla = GameObject.FindGameObjectWithTag("kubla");
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Vihu" || collision.tag == "Boss")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 1;
                    mestariKoodi.Playershield -= 1;
                }
                else
                {
                    PlayerCurrentHealth -= 1;
                    mestariKoodi.Playerhealth -= 1;
                }
            }

            if (collision.tag == "Spike")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 5;
                    mestariKoodi.Playershield -= 5;
                    mestariKoodi.points -= 5;
                }
                else
                {
                    PlayerCurrentHealth -= 5;
                    mestariKoodi.Playerhealth -= 5;

                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 5;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "VihuTahti")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 3;
                    mestariKoodi.Playershield -= 3;
                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 10;
                }
                else
                {
                    PlayerCurrentHealth -= 3;
                    mestariKoodi.Playerhealth -= 3;
                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 10;
                }
            }
            if (collision.tag == "VihuSakset")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 5;
                    mestariKoodi.Playershield -= 5;
                    mestariKoodi.points -= 5;
                }
                else
                {
                    PlayerCurrentHealth -= 5;
                    mestariKoodi.Playerhealth -= 5;

                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 5;
                }
            }

            if (collision.tag == "BossSakset")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 10;
                    mestariKoodi.Playershield -= 10;
                    mestariKoodi.points -= 10;
                }
                else
                {
                    PlayerCurrentHealth -= 10;
                    mestariKoodi.Playerhealth -= 10;

                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 10;
                }
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Spike")
            {
                if (mestariKoodi.Playershield > 0)
                {
                    PlayerCurrentShield -= 15;
                    mestariKoodi.Playershield -= 15;
                    mestariKoodi.points -= 15;
                }
                else
                {
                    PlayerCurrentHealth -= 10;
                    mestariKoodi.Playerhealth -= 10;

                    if (PlayerCurrentHealth > 0)
                        mestariKoodi.points -= 10;
                }
            }            
        }

        void Update()
        {
            if (Shieldbar == null || ShieldbarObject == null)
            {
                Shieldbar = GameObject.FindGameObjectWithTag("Shieldbar").GetComponent<Slider>();
                ShieldbarObject = GameObject.FindGameObjectWithTag("Shieldbar");
            }

            if (PlayerCurrentHealth == 0 || PlayerCurrentHealth < 0)
            {
                anim.SetBool("isDead", true);
            }
            else
            {
                anim.SetBool("isDead", false);
            }

            if (PlayerHealthbar == null)
            {
                PlayerHealthbar = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
            }

            if (Kubla == null && mestariKoodi.Playershield > 0)
            {
                Kubla = GameObject.FindGameObjectWithTag("kubla");
            }

            PlayerHealthbar.value = PlayerUIHealth;
            Shieldbar.value = UIShield;

            PlayerCurrentHealth = mestariKoodi.Playerhealth;
            PlayerCurrentShield = mestariKoodi.Playershield;

            if (PlayerCurrentHealth < PlayerUIHealth)
            {
                PlayerUIHealth -= 1;
            }

            if (PlayerCurrentHealth > PlayerUIHealth)
            {
                PlayerUIHealth += 1;
            }

            if (PlayerCurrentShield > UIShield)
            {
                UIShield += 1;
            }

            if (PlayerCurrentShield < UIShield)
            {
                UIShield -= 1;
            }

            if (mestariKoodi.Playershield == 0)
            {
                Kubla.SetActive(false);
            }

            if (mestariKoodi.Playershield > 0)
            {
                if (Kubla == null)
                {
                    var NewKubla = Instantiate(Kubla, this.transform.position, Quaternion.identity);
                    this.transform.parent = gameObject.transform;
                }
                else
                {
                    Kubla.SetActive(true);
                }
            }

        }

        private void TakeDamage(float damage)
        {
            PlayerCurrentHealth -= damage;
            mestariKoodi.points -= Mathf.RoundToInt(damage);
        }

        public void GameOver()
        {
            SceneManager.LoadScene("CrabGameOver");
        }
    }
}