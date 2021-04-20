using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class Spawner : MonoBehaviour
    {
        public GameObject Keltane;
        public GameObject Sinine;
        public GameObject Tähte;
        public GameObject Buff;
        public GameObject Buff2;
        public GameObject Tähte2;

        public Transform Spawnpoint1;
        public Transform Spawnpoint2;
        public Transform Spawnpoint3;

        public bool SendWave1;
        public bool SendWave2;
        public bool SendWave3;
        public bool SendWave4;
        public bool SendWave5;
        public bool SendWave6;
        public bool SendWave7;
        public bool SendWave8;
        public bool SendWave9;
        public bool SendWave10;

        public GameObject mestari;
        public Master mestariKoodi;

        // Start is called before the first frame update
        void Start()
        {
            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();
            SendNextWave();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (SendWave1 == true)
            {
                Wave1();
                SendWave1 = false;
            }
            if (SendWave2 == true)
            {
                Wave2();
                SendWave2 = false;
            }
            if (SendWave3 == true)
            {
                Wave3();
                SendWave3 = false;
            }
            if (SendWave4 == true)
            {
                Wave4();
                SendWave4 = false;
            }
            if (SendWave5 == true)
            {
                Wave5();
                SendWave5 = false;
            }
            if (SendWave6 == true)
            {
                Wave6();
                SendWave6 = false;
            }
            if (SendWave7 == true)
            {
                Wave7();
                SendWave7 = false;
            }
            if (SendWave8 == true)
            {
                Wave8();
                SendWave8 = false;
            }
            if (SendWave9 == true)
            {
                Wave9();
                SendWave9 = false;
            }
            if (SendWave10 == true)
            {
                Wave10();
                SendWave10 = false;
            }
        }

        public void SendNextWave()
        {
            if (mestariKoodi.waveCount == 0)
            {
                SendWave1 = true;
            }
            if (mestariKoodi.waveCount == 1)
            {
                SendWave2 = true;
            }
            if (mestariKoodi.waveCount == 2)
            {
                SendWave3 = true;
            }
            if (mestariKoodi.waveCount == 3)
            {
                SendWave4 = true;
            }
            if (mestariKoodi.waveCount == 4)
            {
                SendWave5 = true;
            }
            if (mestariKoodi.waveCount == 5)
            {
                SendWave6 = true;
            }
            if (mestariKoodi.waveCount == 6)
            {
                SendWave7 = true;
            }
            if (mestariKoodi.waveCount == 7)
            {
                SendWave8 = true;
            }
            if (mestariKoodi.waveCount == 8)
            {
                SendWave9 = true;
            }
            if (mestariKoodi.waveCount == 9)
            {
                SendWave10 = true;
            }
        }

        void Wave1()
        {
            StartCoroutine(Wave1Num());
            mestariKoodi.enemiesLeft = 9;
        }
        void Wave2()
        {
            StartCoroutine(Wave2Num());
            mestariKoodi.enemiesLeft = 12;
        }
        void Wave3()
        {
            StartCoroutine(Wave3Num());
            mestariKoodi.enemiesLeft = 14;
        }
        void Wave4()
        {
            StartCoroutine(Wave4Num());
            mestariKoodi.enemiesLeft = 5;
        }
        void Wave5()
        {
            StartCoroutine(Wave5Num());
            mestariKoodi.enemiesLeft = 14;
        }
        void Wave6()
        {
            StartCoroutine(Wave6Num());
            mestariKoodi.enemiesLeft = 27;
        }
        void Wave7()
        {
            StartCoroutine(Wave7Num());
            mestariKoodi.enemiesLeft = 12;
        }
        void Wave8()
        {
            StartCoroutine(Wave8Num());
            mestariKoodi.enemiesLeft = 36;
        }
        void Wave9()
        {
            StartCoroutine(Wave9Num());
            mestariKoodi.enemiesLeft = 15;
        }
        void Wave10()
        {
            StartCoroutine(Wave10Num());
            mestariKoodi.enemiesLeft = 30;
        }

        IEnumerator Wave1Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
        }

        IEnumerator Wave2Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
        }

        IEnumerator Wave3Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Buff, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(3F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(5F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
        }

        IEnumerator Wave4Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Buff, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(7F);
            Instantiate(Tähte, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Tähte, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte, Spawnpoint1.position, Quaternion.identity);
        }

        IEnumerator Wave5Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Buff, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Tähte, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Tähte, Spawnpoint1.position, Quaternion.identity);
            yield return new WaitForSeconds(7F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
        }

        IEnumerator Wave6Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Buff, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(3F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(5F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            yield return new WaitForSeconds(5F);
            Instantiate(Buff2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint2.position, Quaternion.identity);
            yield return new WaitForSeconds(7F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            yield return new WaitForSeconds(5F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
        }

        IEnumerator Wave7Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(3F);
            Instantiate(Buff2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
        }

        IEnumerator Wave8Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);

        }


        IEnumerator Wave9Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Keltane, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Keltane, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Buff, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
        }

        IEnumerator Wave10Num()
        {
            mestariKoodi.waveCount += 1;
            mestariKoodi.afterWave = true;
            mestariKoodi.afterAllWaves = true;
            yield return new WaitForSeconds(0.1F);
            Instantiate(Buff2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Buff2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(1F);
            Instantiate(Sinine, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Sinine, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Buff2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Buff2, Spawnpoint3.position, Quaternion.identity);
            yield return new WaitForSeconds(2F);
            Instantiate(Tähte2, Spawnpoint1.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint2.position, Quaternion.identity);
            Instantiate(Tähte2, Spawnpoint3.position, Quaternion.identity);
        }

    }
}