using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textFix : MonoBehaviour {

	
	void Start ()
    {
       MeshRenderer rend = GetComponent<MeshRenderer>();
        rend.sortingOrder = 4;
    }
	
	
}
