using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float BallSpeed = 30;
    private Rigidbody2D rb;
    private GameObject BallLauncher;

    [SerializeField]
    private Transform ball;
    [SerializeField]
    private Sprite SmileTex;
    [SerializeField]
    private Sprite NormalTex;
    void Start ()
    {
        BallLauncher = GameObject.FindGameObjectWithTag("BallLauncher");
        rb = this.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(8, 8);
        this.gameObject.transform.Rotate(0, 0, BallLauncher.transform.rotation.eulerAngles.z);
        StartCoroutine(_wait());
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetRotationAndFireBalls();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

       if(collision.transform.gameObject.tag == "Under")
        {
            Destroy(this.gameObject);
        }

        if (collision.transform.gameObject.tag == "Obstacle")
        {
            this.GetComponent<SpriteRenderer>().sprite = SmileTex;
            collision.transform.gameObject.GetComponent<BlockManager>().DecreaseLife();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
            this.GetComponent<SpriteRenderer>().sprite = NormalTex;
    }

    public void SetRotationAndFireBalls()
    {
        rb.AddRelativeForce(Vector2.up * BallSpeed);
    }

    IEnumerator _wait()
    {
        yield return new WaitForSeconds(.1f);
        SetRotationAndFireBalls();
    }


}

