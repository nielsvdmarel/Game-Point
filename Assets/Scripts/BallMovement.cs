﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField]
    private float BallSpeed = 30;
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject player;
    void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.one.normalized * BallSpeed;

    }

    void FixedUpdate()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.transform.gameObject.tag == "Under")
        {
            Debug.Log("hit");
            player.transform.position = this.transform.position;
        }
    }
}
