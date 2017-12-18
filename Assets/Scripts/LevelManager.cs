using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] SpawnObjects;

    //level
    [SerializeField]
    private int GameRound;
    [SerializeField]
    private int BallAmount;
    [SerializeField]
    private int AmountOfSpawnPlaces = 6;
    [SerializeField]
    private GameObject[] SpawnPos;
    [SerializeField]
    private GameObject[] CurrentActive;
    [SerializeField]
    private bool isMoving = false;

    void Start ()
    {
	}

    void FixedUpdate()
    {

        if (isMoving)
        {
            foreach (var item in CurrentActive)
            {
                item.transform.Translate(Vector3.down * 1.5f * Time.deltaTime);
            }
        }
       

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddnewRow();
        }
    }
    void AddnewRow()
    {
        for (int i = 0; i < AmountOfSpawnPlaces; i++)
        {
            float Spawn = Random.Range(0f,1f);
            if (Spawn > .3f)
            {
                float RandomValue = Random.Range(0f, 2f);
                float RandomValue2 = Random.Range(0f, 1f);
                if (RandomValue > 1.9f)
                {
                    Instantiate(SpawnObjects[(Random.Range(3, 4))].gameObject, SpawnPos[i].transform.position, Quaternion.identity);
                }
                else
                {
                    if(RandomValue2 < .80f)
                    {
                        Instantiate(SpawnObjects[0].gameObject, SpawnPos[i].transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(SpawnObjects[1].gameObject, SpawnPos[i].transform.position, Quaternion.identity);
                    }
                } 
            }
        }
        MoveAllBlocks();
        StartCoroutine(MoveObjects());
    }

   public void MoveAllBlocks()
    {
      CurrentActive = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    IEnumerator MoveObjects()
    {
        {
            isMoving = true;
            yield return new WaitForSeconds(.46f);
            Debug.Log("wat");
            isMoving = false;
        }
    }
    
}
