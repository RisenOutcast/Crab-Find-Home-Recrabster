using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class BossMusic : MonoBehaviour
    {

        public AudioClip BossEntrance;
        public AudioClip Form1;
        public AudioClip Form2Entrance;
        public AudioClip Form2;

        public AudioSource Musa;

        public bool formBegins = false;
        public bool form1hasdied;

        public GameObject Pelaaja;
        public Player2D playerScript;

        void Start()
        {
            Musa = GetComponent<AudioSource>();
            Musa.loop = false;
            StartCoroutine(playForm1());
            Pelaaja = Master.instance.Pelaaja;
            playerScript = Master.instance.Pelaaja.GetComponent<Player2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Pelaaja)
            {
                Pelaaja = Master.instance.Pelaaja;
                playerScript = Master.instance.Pelaaja.GetComponent<Player2D>();
            }
        }

        public void PlayForm2Now()
        {
            StartCoroutine(playForm2());   
        }

        IEnumerator playForm1()
        {
            Musa.clip = BossEntrance;
            Musa.Play();
            yield return new WaitForSeconds(Musa.clip.length);
            Musa.clip = Form1;
            Musa.loop = true;
            Musa.Play();
            formBegins = true;
            playerScript.enabled = true;
        }

        IEnumerator playForm2()
        {
            formBegins = false;
            playerScript.enabled = false;
            Musa.clip = Form2Entrance;
            Musa.Play();
            StartCoroutine(UnfreezePlayer());
            yield return new WaitForSeconds(Musa.clip.length);
            Musa.clip = Form2;
            Musa.loop = true;
            Musa.Play();
        }

        IEnumerator UnfreezePlayer()
        {
            yield return new WaitForSeconds(13.5F);
            playerScript.enabled = true;
            formBegins = true;
        }
    }
}