using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    [SerializeField]
    private int BlockLife;
   //Triangle Control
    [SerializeField]
    private Sprite[] Colors;
    [SerializeField]
    private bool istriangle;
    [SerializeField]
    private float[] RotateDegrees;
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = Colors[Random.Range(0, 3)];
        if (istriangle)
        {

        }
    }
	
	void Update ()
    {
		if(BlockLife < 1)
        {
            Death();
        }
	}

    void DecreaseLife()
    {
        BlockLife -= 1;
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
