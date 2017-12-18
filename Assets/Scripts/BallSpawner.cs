using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private float BallSpawnAmount;
    

	void Start ()
    {
      
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Instantiate(Ball, this.transform.position, Quaternion.identity);
    }
}
