using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDistance : MonoBehaviour {
    public float distance;
    public GameObject c;
	// Use this for initialization
	void Start () {
        Vector3 moveDir = (transform.position - c.transform.position).normalized;

        transform.position = moveDir * distance;
        Debug.Log(Vector3.Distance(c.transform.position, transform.position));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
