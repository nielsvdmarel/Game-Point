using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float BallSpeed = 30;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Sprite SmileTex;
    [SerializeField]
    private Sprite NormalTex;
    void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.one.normalized * BallSpeed;
        rb.velocity = Vector2.positiveInfinity;

    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.transform.gameObject.tag == "Under")
        {
           // Destroy(this.gameObject);
        }

        if (collision.transform.gameObject.tag == "Obstacle")
        {
            this.GetComponent<SpriteRenderer>().sprite = SmileTex;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
            this.GetComponent<SpriteRenderer>().sprite = NormalTex;
    }
}

