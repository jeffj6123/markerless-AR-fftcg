using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
//using System.Json;
public class httphandler : MonoBehaviour {
    public Camera c;
    public GameObject testCube;
    public Texture[] cardImages = new Texture[50];
    public string deckId;
    void Start()
    {
        transform.LookAt(c.transform);
        string url = "https://ffdecks.com/api/deck?deck_id=" + deckId;
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            JsonData d = JsonMapper.ToObject(www.text);
            var cards = d["cards"];

            int index = 0;
            for(int i = 0; i < cards.Count; i++)
            {
                for(int j = 0; j < (int)cards[i]["quantity"]; j++)
                {
                    Debug.Log(cards[i]["card"]["image"].ToString());
                    WWW cardImageR = new WWW(cards[i]["card"]["image"].ToString());
                    StartCoroutine(getCard(cardImageR, index));

                    index++;
                }
            }
            //var o = JsonUtility.FromJson<Generic>(www.text)
            //cards = www.text
            Debug.Log(www.text);
            Debug.Log(d["cards"]);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    IEnumerator getCard(WWW www, int index)
    {
        
        yield return www;
        int horizontalOffset = ( index % 5 ) ;
        int verticalOffset = ( index / 5 );
        Debug.Log(index);
        // check for errors
        if (www.error == null)
        {
            cardImages[index] = www.texture;
            GameObject g = Instantiate(testCube, transform.position +  new Vector3(horizontalOffset * 30, verticalOffset * 30, 0), transform.rotation) as GameObject;
            g.GetComponent<Renderer>().material.mainTexture = www.texture;
            g.transform.Rotate(0, 90, 0);
            g.transform.parent = transform;
            g.transform.localPosition = new Vector3(horizontalOffset * 32, verticalOffset * 35, verticalOffset * 6);
            g.name = index.ToString();
            g.transform.LookAt(c.transform);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
