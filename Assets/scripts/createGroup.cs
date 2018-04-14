using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createGroup : MonoBehaviour {
    public GameObject group;
    public GameObject c;
    public void createNewGroupAtForward()
    {
        Instantiate(group, c.transform.forward.normalized * 300, new Quaternion(0, 0, 0, 0));
    }
}
