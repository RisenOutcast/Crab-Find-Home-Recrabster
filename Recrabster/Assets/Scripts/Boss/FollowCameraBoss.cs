using UnityEngine;
using System.Collections;

namespace RO.Crab
{
    public class FollowCameraBoss : MonoBehaviour
    {

        public float interpVelocity;
        public float minDistance;
        public float followDistance;
        public GameObject Pelaaja;
        public GameObject Boss;
        public Vector3 offset;
        Vector3 targetPos;

        public GameObject Music;
        BossMusic bossuMusa;

        public bool followPrefab;

        // Use this for initialization
        IEnumerator Start()
        {
            yield return new WaitForSeconds(1F);
            bossuMusa = Music.GetComponent<BossMusic>();
            targetPos = transform.position;
            if (followPrefab == true)
            {
                Pelaaja = GameObject.FindWithTag("Player");
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (bossuMusa.formBegins)
            {
                if (Pelaaja)
                {
                    Vector3 posNoZ = transform.position;
                    posNoZ.z = Pelaaja.transform.position.z;

                    Vector3 targetDirection = (Pelaaja.transform.position - posNoZ);

                    interpVelocity = targetDirection.magnitude * 15f;

                    targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                    transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.30f);

                }
            }
            else
            {
                Vector3 posNoZ = transform.position;
                posNoZ.z = Boss.transform.position.z;

                Vector3 targetDirection = (Boss.transform.position - posNoZ);

                interpVelocity = targetDirection.magnitude * 15f;

                targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

                transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.30f);
            }
        }
    }
}
