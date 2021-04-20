using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Crab
{
    public class Ovi : MonoBehaviour
    {

        public bool locked = false;
        public bool collided = false;
        public GameObject mestari;
        public Master mestariKoodi;
        public string LevelName;
        public bool BossDoor;

        public GameObject lockedDoor;

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
                collided = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collided = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (locked == true)
            {
                if (collided == true && mestariKoodi.bossKeyObtained == true && BossDoor)
                {
                    Destroy(gameObject);
                }
            }
            else if (collided == true && locked == false)
            {
                SceneManager.LoadScene(LevelName);
            }

            if (LevelName == "CrabLevel" && Master.instance.waveCount == 10)
            {
                lockedDoor.SetActive(true);
            }
        }
    }
}