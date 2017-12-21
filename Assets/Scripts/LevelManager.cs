using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    [SerializeField]
    private GameObject[] SpawnObjects;

    //level
    [SerializeField]
    public int GameRound;
    [SerializeField]
    private int AmountOfSpawnPlaces = 6;
    [SerializeField]
    private GameObject[] SpawnPos;
    private GameObject[] CurrentActive;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    public bool BallsAreActive = false;
    [SerializeField]
    private Text score;

    void Start ()
    {
        NewRound();
        BallsAreActive = false;
        StartCoroutine(CheckingForBalls());
        score = GameObject.Find("Score").GetComponentInChildren<Text>();
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
        score.text = "" + GameRound;
    }
    void AddnewRow()
    {
        for (int i = 0; i < AmountOfSpawnPlaces; i++)
        {
            float Spawn = Random.Range(0f,1f);
            if (Spawn > .5f)
            {
                float RandomValue = Random.Range(0f, 2f);
                float RandomValue2 = Random.Range(0f, 1f);
                if (RandomValue > 1.95f)
                {
                    Instantiate(SpawnObjects[(Random.Range(2, 3))].gameObject, SpawnPos[i].transform.position, Quaternion.identity);
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
            isMoving = false;
        }
    }

    IEnumerator CheckingForBalls()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (GameObject.Find("Ball(Clone)") == null && BallsAreActive)
            {
                NewRound();
                BallsAreActive = false;
            }
        }
    }

    private void NewRound()
    {
            GameRound++;
            AddnewRow();
            GameObject.Find("BallLauncher").GetComponent<RotationObjectScript>().MoveMainObject();
            float randomNeededNumb = UnityEngine.Random.Range(1f,2f);
        if(randomNeededNumb > 1.6f)
        {
            GameObject.Find("SpawnPoint").GetComponent<BallSpawner>().BallSpawnAmount++;
        }
            GameObject.Find("BallLauncher").GetComponent<RotationObjectScript>().isRotating = true;
    }


   public void GameOver()
    {
        Debug.Log("GameOver");
        SceneManager.LoadScene(2);
    }
}
