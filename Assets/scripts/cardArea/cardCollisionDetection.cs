using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCollisionDetection : MonoBehaviour {

    public cardArea parent;
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            parent.addEntity(other.gameObject.transform);
            Debug.Log("hit something");

        }
    }
}
