using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RO.Crab
{
    public class Boss : MonoBehaviour
    {
        public GameObject Music;
        BossMusic bossuMusa;

        public GameObject Pelaaja;
        public Player2D playerScript;

        public float speed;

        public bool entrance = false;
        public Transform startPos;

        public bool formOneDied;

        public int currentHealth;
        public int startingHealth;

        public GameObject hurtSprite;
        public GameObject kuori;

        public Transform Shootpos;
        public Transform Spikepos1;
        public Transform Spikepos2;
        public Transform Spikepos3;
        public GameObject melee;
        public GameObject spike;

        public bool Death = false;

        public Transform spwnPt1;
        public Transform spwnPt2;

        public GameObject projectile;

        public bool canHit = true;
        public bool canHitground = true;
        private bool canShoot = true;
        bool canDie;
        Animator anim;

        public bool wait;
        public GameObject henchemen;
        public GameObject henchemen2;
        private Collider2D collideri;

        public int worth;

        // Start is called before the first frame update
        void Start()
        {
            Death = false;
            anim = GetComponent<Animator>();
            StartCoroutine(WalkToStart());
            bossuMusa = Music.GetComponent<BossMusic>();
            collideri = GetComponent<Collider2D>();
            Pelaaja = GameObject.FindWithTag("Player");
            Master.instance.BossBar.maxValue = startingHealth;
            wait = true;
            canHit = true;
            canHitground = true;
            canShoot = true;
            canDie = false;
    }

        // Update is called once per frame
        void Update()
        {
            if (!Pelaaja)
                Pelaaja = GameObject.FindWithTag("Player");

            if (Master.instance.BossBar.value < currentHealth)
                Master.instance.BossBar.value += 0.5F;

            if (Master.instance.BossBar.value > currentHealth)
                Master.instance.BossBar.value -= 0.5F;

            if (currentHealth == 0 && !formOneDied)
            {
                bossuMusa.PlayForm2Now();
                StartCoroutine(Form1Died());
                formOneDied = true;
                wait = true;
                anim.SetBool("form2", true);
                StartCoroutine(stopWalk2());
                StartCoroutine(spawnHenchmen());
            }

            if (currentHealth < 0)
                currentHealth = 0;

            if (currentHealth < 50 && formOneDied)
                Ranged();

            float step = speed * Time.deltaTime;

            if (entrance)
            {
                float dist = Vector3.Distance(startPos.position, transform.position);
                transform.position = Vector3.MoveTowards(transform.position, startPos.position, step);
                if (dist == 0)
                    StartCoroutine(stopWalk());
            }

            Melee();

            if (currentHealth < 1 && Death == false && canDie)
            {
                Instantiate(kuori, transform.position, Quaternion.identity);
                anim.SetBool("isDead", true);
                Master.instance.points += worth;
                Death = true;
                collideri.enabled = !collideri.enabled;
            }

            if (Death == true)
            {
                Destroy(gameObject, 0.5f);
            }
        }

        private void FixedUpdate()
        {
            Flip();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "PlayerAttack")
            {
                currentHealth -= 1;
                StartCoroutine(ShowHurt());
            }

            if (collision.tag == "bumerang")
            {
                currentHealth -= 2;
                StartCoroutine(ShowHurt());
            }
        }

        IEnumerator WalkToStart()
        {
            yield return new WaitForSeconds(4F);
            entrance = true;
        }

        IEnumerator Form1Died()
        {
            wait = true;
            Master.instance.points += 100;
            yield return new WaitForSeconds(3F);
            Master.instance.BossBar.maxValue = 150;
            currentHealth = 150;
            speed = 2;
            canDie = true;
        }

        IEnumerator ShowHurt()
        {
            hurtSprite.SetActive(true);
            yield return new WaitForSeconds(0.1F);
            hurtSprite.SetActive(false);
        }

        void Flip()
        {
            if (Pelaaja.transform.position.x > transform.position.x)
            {
                //face right
                transform.localScale = new Vector3(-0.4286604F, 0.4286604F, 0.4286604F);
            }
            else if (Pelaaja.transform.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(0.4286604F, 0.4286604F, 0.4286604F);
            }
        }

        private void Melee()
        {
            if (!entrance && !wait)
            {
                if (Pelaaja)
                {
                    float dist = Vector3.Distance(Pelaaja.transform.position, transform.position);
                    float step = speed * Time.deltaTime;


                    if (dist < 50 && dist > 2)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, Pelaaja.transform.position, step);
                    }

                    if (dist < 5.5F && canHit == true)
                    {
                        StartCoroutine(HitPlayer());
                    }

                    if(dist < 6 && canHitground)
                    {
                        StartCoroutine(hitGround());
                    }
                }
            }
        }

        private void Ranged()
        {
            if (Pelaaja)
            {
                float dist = Vector3.Distance(Pelaaja.transform.position, transform.position);
                float step = 1 * speed * Time.deltaTime;

                if (canShoot == true)
                {
                    StartCoroutine(ShootPlayer());
                }
            }
        }

        IEnumerator hitGround()
        {
            canHitground = false;
            anim.SetBool("Attack2", true);
            Instantiate(spike, Spikepos1.position, Quaternion.identity);
            if (formOneDied)
            {
                Instantiate(spike, Spikepos2.position, Quaternion.identity);
                Instantiate(spike, Spikepos3.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.3F);
            anim.SetBool("Attack2", false);
            yield return new WaitForSeconds(7F);
            canHitground = true;
        }

        IEnumerator HitPlayer()
        {
            canHit = false;
            anim.SetBool("Attack1", true);
            Instantiate(melee, Shootpos.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3F);
            anim.SetBool("Attack1", false);
            yield return new WaitForSeconds(2F);
            canHit = true;
        }

        IEnumerator stopWalk()
        {
            yield return new WaitForSeconds(1F);
            entrance = false;
            wait = false;
        }

        IEnumerator stopWalk2()
        {
            yield return new WaitForSeconds(10F);
            anim.SetBool("form2", false);
            anim.SetBool("perkele", true);
            yield return new WaitForSeconds(5F);
            anim.SetBool("perkele", false);
            wait = false;
        }

        IEnumerator spawnHenchmen()
        {
            yield return new WaitForSeconds(32F);
            Instantiate(henchemen, spwnPt1.position, Quaternion.identity);
            Instantiate(henchemen, spwnPt2.position, Quaternion.identity);
            yield return new WaitForSeconds(46F);
            Instantiate(henchemen2, spwnPt1.position, Quaternion.identity);
            Instantiate(henchemen2, spwnPt2.position, Quaternion.identity);
            yield return new WaitForSeconds(12F);
            Instantiate(henchemen2, spwnPt1.position, Quaternion.identity);
            Instantiate(henchemen2, spwnPt2.position, Quaternion.identity);
        }

        IEnumerator ShootPlayer()
        {
            Instantiate(projectile, Shootpos.position, Quaternion.identity);
            canShoot = false;
            yield return new WaitForSeconds(4F);
            canShoot = true;
        }
    }
}