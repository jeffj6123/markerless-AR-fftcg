using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardArea : MonoBehaviour {
    public int entitiesPerRow;
    public float margins;

    private int lastChildCount;
    // Use this for initialization
    void Start() {
        positionEntities();
    }

    public void addEntity(Transform newChild)
    {
        newChild.transform.parent = transform;
        positionEntities();
    }

    public void positionEntities()
    {
        int count = transform.childCount;
        float regionLength = transform.localScale.x - margins;
        //Debug.Log(regionLength / count);
        if(count == 1)
        {
            transform.GetChild(0).transform.localPosition = transform.position + new Vector3(0, 0, -1);
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Transform child = transform.GetChild(i);
                child.localPosition = new Vector3((regionLength / 2f - i * (regionLength / (count - 1))) / transform.localScale.x, 0, -2);// + transform.position;
                                                                                                                                          //Debug.Log(child.gameObject.transform.localPosition);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = this.transform;
        other.transform.localPosition = new Vector3(0, 0, 0);
        Debug.Log(other.transform.localPosition);
        positionEntities();

    }

    // Update is called once per frame
    void Update () {
        if (lastChildCount != transform.childCount)
        {
           positionEntities();
        }
        positionEntities();

        lastChildCount = transform.childCount;
	}
}
