using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RO.Crab
{
    public class PopUpButtons : MonoBehaviour
    {
        public GameObject spawner;
        public Spawner spawnerKoodi;

        public GameObject mestari;
        public Master mestariKoodi;

        // Start is called before the first frame update
        void Start()
        {
            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();

            if (spawner == null)
                spawner = GameObject.FindWithTag("Spawner");
            spawnerKoodi = spawner.GetComponent<Spawner>();
        }

        // Update is called once per frame
        void Update()
        {
            if (spawner == null)
                spawner = GameObject.FindWithTag("Spawner");
            spawnerKoodi = spawner.GetComponent<Spawner>();
        }

        public void continueButton()
        {
            spawnerKoodi.SendNextWave();
        }

        public void HubButton()
        {
            SceneManager.LoadScene("CrabHub");
        }
    }
}