using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class Master : MonoBehaviour
    {
        public static Master instance = null;

        public string playerName;

        public int waveCount = 0;

        public int enemiesLeft;
        public int points;

        public int kuorienMäärä;

        public GameObject popUp;
        public GameObject popUp2;
        public GameObject popUp3;
        public GameObject keyIcon;

        public bool devMode;

        public bool afterWave;
        public bool afterAllWaves;

        public bool bossKeyObtained = false;

        public bool hasBoughtFire1 = false;
        public bool hasBoughtFire3 = false;

        public GameObject kokoCanvas;
        public GameObject Pelaaja;

        public TMP_Text pointsText;
        public TMP_Text kuorienMääräText;
        public TMP_Text waves;

        public bool YouWin;

        public int Playerhealth = 1;
        public int Playershield;

        public GameObject BossStuff;

        public Slider BossBar;

        public int bossForm = 3;

        // Start is called before the first frame update
        void Start()
        {
            Playerhealth = 100;
            Playershield = 0;
        }

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            if (Pelaaja == null)
            {
                kokoCanvas.SetActive(false);
                Pelaaja = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                kokoCanvas.SetActive(true);
            }

            if (Playerhealth < 0)
            {
                Playerhealth = 0;
            }

            if (Playershield > 100)
            {
                Playershield = 100;
            }
            if (Playershield < 0)
            {
                Playershield = 0;
            }

            pointsText.text = (points.ToString() + " pts");
            kuorienMääräText.text = ("x " + kuorienMäärä.ToString());

            if (bossKeyObtained == false)
            {
                keyIcon.SetActive(false);
            }
            else
            {
                keyIcon.SetActive(true);
            }
            if (waveCount > 10 && SceneManager.GetActiveScene().name == "CrabLevel")
                popUp2.SetActive(true);

            if (enemiesLeft == 0 && afterWave == true)
            {
                if (waveCount == 10 && afterWave == true)
                {
                    bossKeyObtained = true;
                    popUp2.SetActive(true);
                    afterWave = false;
                }
                else
                { 
                    popUp.SetActive(true);
                    afterWave = false;
                }
            }

            if (waveCount == 10 && afterAllWaves == true && SceneManager.GetActiveScene().name == "CrabHub")
            {
                popUp3.SetActive(true);
                afterAllWaves = false;
            }

            if (YouWin == true && SceneManager.GetActiveScene().name != "CrabWinner")
            {
                SceneManager.LoadScene("CrabWinner");
                YouWin = false;
            }

            if(SceneManager.GetActiveScene().name == "CollectionMenu")
            {
                Destroy(gameObject);
            }

            if (SceneManager.GetActiveScene().name == "CrabBossLevel")
            {
                BossStuff.SetActive(true);
                waves.text = ("Boss");
            }
            else
            {
                BossStuff.SetActive(false);
                waves.text = ("Wave " + waveCount.ToString() + "/10");
            }

            if (points < 0)
                points = 0;
        }
    }
}