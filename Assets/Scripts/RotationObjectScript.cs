using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationObjectScript : MonoBehaviour {
    [SerializeField]
    private float RotationSpeed;
    [SerializeField]
    private float RotationAngle;
    public bool isRotating = false;
    
    private bool isSelectedThisRound = false;
	
	void Update ()
    {
        Rotate();
        if (Input.GetKeyDown(KeyCode.Space) && isRotating)
        {
            isRotating = false;
            SpawnAllBalls();
            GameObject.Find("GameLeader").GetComponent<LevelManager>().BallsAreActive = true;
        }
    }

    private void SpawnAllBalls()
    {
        StartCoroutine(GameObject.Find("SpawnPoint").GetComponent<BallSpawner>().BallSpawnerTimer());
    }

    void Rotate()
    {
        if (isRotating)
        {
            RotationAngle = Mathf.PingPong(Time.time * RotationSpeed, 140) - 70;
            transform.rotation = Quaternion.Euler(0, 0, RotationAngle);
        }
    }

   public void MoveMainObject()
    {
        float x = Random.Range(-1.6f, 1.45f);
       this.transform.position = new Vector3(x, -5.02f, 0);
    }
}
