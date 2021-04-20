using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author M.J.Metsola @RisenOutcast

namespace RO.Crab
{
    public class Player2D : MonoBehaviour
    {
        #region Moving

        [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;// How much to smooth out the movement
        [SerializeField] private Collider2D crouchDisableCollider;// A collider that will be disabled when crouching

        const float groundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
        private Rigidbody2D m_Rigidbody2D;
        private Vector3 m_Velocity = Vector3.zero;

        public float speed = 150f;

        public bool facingRight = false;

        float horizontalMove = 0f;
        float verticalMove = 0f;
        Animator anim;
        #endregion

        #region Shooting

        public GameObject ProjectileLeft;
        public GameObject ProjectileRight;
        public GameObject melee;
        public GameObject BoomerangLeft;
        public GameObject BoomerangRight;
        Transform ShootposHori;

        public bool hasAmmo;

        public bool canShoot;
        public bool canShootBoomerang = true;

        public bool hasBoughtFire1 = false;
        public bool hasBoughtFire3 = false;

        AudioSource audioSource;

        public GameObject mestari;
        public Master mestariKoodi;

        public AudioClip MeleeSound;
        public AudioClip ShootSound;
        public AudioClip BumerangiSound;
        #endregion

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            ShootposHori = transform.Find("ShootposHori");
            hasAmmo = true;
            canShoot = true;
            audioSource = GetComponent<AudioSource>();
            if (mestari == null)
                mestari = GameObject.FindWithTag("Mestari");
            mestariKoodi = mestari.GetComponent<Master>();

            if (mestariKoodi.hasBoughtFire1 == true)
            {
                hasBoughtFire1 = true;
            }
            if (mestariKoodi.hasBoughtFire3 == true)
            {
                hasBoughtFire3 = true;
            }
        }

        void Update()
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            verticalMove = Input.GetAxisRaw("Vertical") * speed;

            if (Input.GetMouseButtonDown(0) && hasAmmo && canShoot == true && hasBoughtFire1)
            {
                anim.SetBool("isShooting", true);
            }

            if ((Input.GetMouseButtonUp(0)))
            {
                anim.SetBool("isShooting", false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                anim.SetBool("isMelee", true);
            }

            if (Input.GetMouseButtonUp(1))
            {
                anim.SetBool("isMelee", false);
            }

            if (Input.GetKeyDown("space") && hasBoughtFire3 == true && canShootBoomerang == true)
            {
                anim.SetBool("Boomerang", true);
                StartCoroutine(BoomerangCD());
            }

            if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("w"))
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }

        private void FixedUpdate()
        {
            MoveHorizontal(horizontalMove * Time.fixedDeltaTime);
            MoveVertical(verticalMove * Time.fixedDeltaTime);

            if (mestariKoodi.hasBoughtFire1 == true)
            {
                hasBoughtFire1 = true;
            }
            if (mestariKoodi.hasBoughtFire3 == true)
            {
                hasBoughtFire3 = true;
            }
        }


        public void MoveHorizontal(float move)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
            if (move != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }
        }

        public void MoveVertical(float move)
        {
            Vector3 targetVelocity = new Vector2(m_Rigidbody2D.velocity.x, move * 10f);
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
        }


        private void Flip()
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }

        void Fire()
        {
            //if (facing == "Up")
            //{
            //Instantiate(ProjectileUp, ShootposUp.position, Quaternion.identity);
            //}
            //if (facing == "Down")
            //{
            //Instantiate(ProjectileDown, ShootposDown.position, Quaternion.identity);
            //}
            if (facingRight == false)
            {
                Instantiate(ProjectileLeft, ShootposHori.position, Quaternion.identity);
                anim.SetBool("isShooting", false);
                audioSource.PlayOneShot(ShootSound, 0.7F);
            }
            if (facingRight == true)
            {
                Instantiate(ProjectileRight, ShootposHori.position, Quaternion.identity);
                anim.SetBool("isShooting", false);
                audioSource.PlayOneShot(ShootSound, 0.7F);
            }
            //audioSource.PlayOneShot(Attack, 0.7F);
        }

        void Fire2()
        {
            //if (facing == "Up")
            //{
            //Instantiate(melee, ShootposUp.position, Quaternion.identity);
            //}
            //if (facing == "Down")
            //{
            //Instantiate(melee, ShootposDown.position, Quaternion.identity);
            //}
            if (facingRight == false)
            {
                Instantiate(melee, ShootposHori.position, Quaternion.identity);
                audioSource.PlayOneShot(MeleeSound, 0.7F);
            }
            if (facingRight == true)
            {
                Instantiate(melee, ShootposHori.position, Quaternion.identity);
                audioSource.PlayOneShot(MeleeSound, 0.7F);
            }
            //audioSource.PlayOneShot(SecondAttack, 0.7F);
        }

        void Fire3()
        {
            //if (facing == "Up")
            //{
            //Instantiate(melee, ShootposUp.position, Quaternion.identity);
            //}
            //if (facing == "Down")
            //{
            //Instantiate(melee, ShootposDown.position, Quaternion.identity);
            //}
            if (facingRight == false)
            {
                Instantiate(BoomerangLeft, ShootposHori.position, Quaternion.identity);
                anim.SetBool("Boomerang", false);
                audioSource.PlayOneShot(BumerangiSound, 0.7F);
            }
            if (facingRight == true)
            {
                Instantiate(BoomerangRight, ShootposHori.position, Quaternion.identity);
                anim.SetBool("Boomerang", false);
                audioSource.PlayOneShot(BumerangiSound, 0.7F);
            }
            //audioSource.PlayOneShot(SecondAttack, 0.7F);
        }

        IEnumerator Firerate()
        {
            canShoot = false;
            //anim.SetBool("IsAttacking", true);
            yield return new WaitForSeconds(0.1F);
            //anim.SetBool("IsAttacking", false);
            yield return new WaitForSeconds(0.2F);
            canShoot = true;
        }

        IEnumerator BoomerangCD()
        {
            canShootBoomerang = false;
            yield return new WaitForSeconds(9F);
            canShootBoomerang = true;
        }

        void FixAnimationShoot()
        {
            anim.SetBool("isShooting", true);
        }
        
        void FixAnimationMelee()
        {
            anim.SetBool("isMelee", true);
        }

        void FixAnimationMelee2()
        {
            anim.SetBool("isMelee", false);
        }
    }
}