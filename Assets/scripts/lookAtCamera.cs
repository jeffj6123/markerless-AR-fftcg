using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
        if(target == null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.parent);
        }
        else
        {
            transform.LookAt(target.transform);

        }

    }
}
