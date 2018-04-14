using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class importDeck : MonoBehaviour {
    public InputField inputField;
    public GameObject cardArea;
    GameObject c;
	// Use this for initialization
	void Start () {
        c = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
    public void importDeckFromInputField()
    {

        GameObject g = Instantiate(cardArea, c.transform.forward.normalized * 300, new Quaternion(0, 0, 0, 0));
        if(inputField.text.Substring(25).Length == 16)
        g.GetComponentInChildren<cardArea>().importDeck(inputField.text.Substring(25));
    }
}
