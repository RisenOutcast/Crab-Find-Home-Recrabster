using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Vector2 speed;
    public float comeBackSpeed;

    Rigidbody2D rb2d;

    public GameObject player;

    public bool changeCourse = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = speed;
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Comeback());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,+5);

        if (changeCourse == false)
        {
            rb2d.velocity = speed;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            float dist = Vector3.Distance(player.transform.position, transform.position);
            float step = comeBackSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    IEnumerator Comeback()
    {
        yield return new WaitForSeconds(5F);
        changeCourse = true;

    }
}
