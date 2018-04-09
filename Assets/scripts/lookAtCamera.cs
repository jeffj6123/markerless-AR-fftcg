using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour {
    public GameObject target;
	// Use this for initialization
	void Start () {
        transform.LookAt(target.transform);

    }
}
