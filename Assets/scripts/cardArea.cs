using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardArea : MonoBehaviour {
    public int entitiesPerRow;
    public float margins;
    public GameObject refChild;
    private int lastChildCount;
    // Use this for initialization
    void Start() {
        positionEntities();
    }

    public void addEntity(Transform newChild)
    {
        newChild.transform.parent = refChild.transform;
        positionEntities();
    }

    public void positionEntities()
    {
        int count = refChild.transform.childCount;
        float regionLength = transform.localScale.x - margins;
        Debug.Log(regionLength / count);
        if(count == 1)
        {
            refChild.transform.GetChild(0).transform.position = transform.position + new Vector3(0, 0, -1);
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Transform child = refChild.transform.GetChild(i);
                child.position = new Vector3((regionLength / 2f - i * (regionLength / (count - 1))) / transform.localScale.x, 0, -2)  + transform.position;
                                                                                                                                          Debug.Log(new Vector3((regionLength / 2f - i * (regionLength / (count - 1))) / transform.localScale.x, 0, -2).ToString());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = refChild.transform;
        other.transform.localPosition = new Vector3(0, 0, 0);
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
