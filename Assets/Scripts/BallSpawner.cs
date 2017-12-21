using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject Ball;
    public float BallSpawnAmount = 1;
	
    void SpawnBall()
    {
            Instantiate(Ball, this.transform.position, Quaternion.identity);  
    }

   public IEnumerator BallSpawnerTimer()
    {
        
        for (int i = 0; i < BallSpawnAmount; i++)
        {
            yield return new WaitForSeconds(.15f);
            Instantiate(Ball, this.transform.position, Quaternion.identity);
        }
    }
    
}
