using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour {
    public int BlockLife;
    [SerializeField]
    private TextMesh CurrentLives;
   //Triangle Control
    [SerializeField]
    private Sprite[] Colors;
    [SerializeField]
    private bool istriangle;
    [SerializeField]
    private bool isGolded;
    [SerializeField]
    private float[] RotateDegrees;
    
    void Start()
    {
        BlockLife = GameObject.Find("GameLeader").GetComponent<LevelManager>().GameRound;
        this.GetComponentInChildren<TextMesh>().text = "" + BlockLife;
        this.GetComponent<SpriteRenderer>().sprite = Colors[Random.Range(0, 3)];
    }
	
	void Update ()
    {
		if(BlockLife < 1)
        {
            Death();
        }

        if(this.gameObject.transform.position.y < -4.669)
        {
            GameObject.Find("GameLeader").GetComponent<LevelManager>().GameOver();
        }
	}

   public void DecreaseLife()
    {
        BlockLife -= 1;
        this.gameObject.GetComponentInChildren<TextMesh>().text = "" + BlockLife;
    }

    void Death()
    {
        if (isGolded)
        {
            GameObject.Find("GoldenAmount").GetComponent<Text>().text = "" + 1;
        }
        Destroy(this.gameObject);
    }

    
}
