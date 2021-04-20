using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author M.J.Metsola @RisenOutcast
namespace RO.Crab
{
    public class Vihu : MonoBehaviour
    {
        public int Health = 100;
        public int Attack = 45;
        public float Speed = 50f;
        public int worth;

        public bool isRanged = false;
        public bool isMelee = false;
        public bool isCreep = false;

        public GameObject player;
        public GameObject melee;
        public GameObject projectile;
        public Transform Shootpos;

        public GameObject kuori;
        public GameObject hurtSprite;

        public GameObject mestari;
        public Master mestariKoodi;

        Animator anim;

        public bool isShooting;

        private bool canShoot = true;
        private bool canHit = true;
        private bool stopMoving = false;

        private bool Death;
        private Collider2D collideri;

        // Start is called before the first frame update
        void Start()
        {
            Shootpos = transform.Find("Shootpos");
            anim = GetComponent<Animator>();
            collideri = GetComponent<Collider2D>();
            player = GameObject.FindWithTag("Player");

            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Health < 1 && Death == false)
            {
                Instantiate(kuori, transform.position, Quaternion.identity);
                anim.SetBool("isDead", true);
                mestariKoodi.points += worth;
                mestariKoodi.enemiesLeft -= 1;
                Death = true;
                collideri.enabled = !collideri.enabled;
            }

            if (Death == true)
            {
                Destroy(gameObject, 0.5f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "PlayerAttack")
            {
                Health -= 1;
                StartCoroutine(ShowHurt());
            }

            if (collision.tag == "bumerang")
            {
                Health -= 10;
                StartCoroutine(ShowHurt());
            }
        }

        void FixedUpdate()
        {
            if (isRanged == true)
            {
                Ranged();
            }
            if (isCreep == true)
            {
                Creep();
            }
            if (isMelee == true)
            {
                Melee();
            }

            Flip();
        }

        private void Creep()
        {
            if (Death == false)
            {
                if (player)
                {
                    float dist = Vector3.Distance(player.transform.position, transform.position);
                    float step = Speed * Time.deltaTime;


                    if (dist < 50)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                        anim.SetBool("isRunning", true);
                    }
                }
            }
        }

        private void Ranged()
        {
            if (player)
            {
                float dist = Vector3.Distance(player.transform.position, transform.position);
                float step = 1 * Speed * Time.deltaTime;
                float antistep = -1 * Speed * Time.deltaTime;

                if(canShoot == true)
                {
                    StartCoroutine(ShootPlayer());
                }

                if (isShooting == false)
                {
                    if (dist < 25)
                    {
                        if (dist < 12)
                        {
                            if (stopMoving == false)
                            {
                                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, antistep);
                            }
                        }
                        else
                        {
                            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                        }
                    }
                }
            }
        }

        private void Melee()
        {
            if (player)
            {
                float dist = Vector3.Distance(player.transform.position, transform.position);
                float step = Speed * Time.deltaTime;


                if (dist < 50 && dist > 2)
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                }

                if (dist < 3 && canHit == true)
                {
                    StartCoroutine(HitPlayer());
                }
            }
        }

        IEnumerator ShootPlayer()
        {
            Instantiate(projectile, Shootpos.position, Quaternion.identity);
            canShoot = false;
            anim.SetBool("isShooting", true);
            yield return new WaitForSeconds(0.3F);
            anim.SetBool("isShooting", false);
            yield return new WaitForSeconds(2F);
            canShoot = true;
        }

        IEnumerator HitPlayer()
        {
            canHit = false;
            anim.SetBool("isAttacking", true);
            yield return new WaitForSeconds(0.3F);
            anim.SetBool("isAttacking", false);
            yield return new WaitForSeconds(2F);
            canHit = true;
        }

        IEnumerator ShowHurt()
        {
            if (!Death)
            {
                hurtSprite.SetActive(true);
                yield return new WaitForSeconds(0.1F);
                hurtSprite.SetActive(false);
            }
        }

        public void Hit()
        {
            Instantiate(melee, Shootpos.position, Quaternion.identity);
        }

        void Flip()
        {
            if (player.transform.position.x > transform.position.x)
            {
                //face right
                transform.localScale = new Vector3(-0.2892611F, 0.2892611F, 0.2892611F);
            }
            else if (player.transform.position.x < transform.position.x)
            {
                //face left
                transform.localScale = new Vector3(0.2892611F, 0.2892611F, 0.2892611F);
            }
        }
    }
}