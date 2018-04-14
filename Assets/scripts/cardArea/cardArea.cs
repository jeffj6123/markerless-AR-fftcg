using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class cardArea : MonoBehaviour {
    public int entitiesPerRow = 5 ;
    public float spacing;
    public GameObject refChild;
    public GameObject background;
    public float backgroundVerticalOffset = 5;
    public float backgroundHorizontalOffset = 38;
    private int lastChildCount;
    public GameObject cardPrefab;
    // Use this for initialization
    void Start() {
        positionEntities();
    }

    public void addEntity(Transform newChild)
    {
        newChild.parent = refChild.transform;
    }

    public void positionEntities()
    {
        int count = refChild.transform.childCount;
        float regionLength = transform.localScale.x; // - margins;
        float verticalCenterOffset = 0;

        for (int i = 0; i < count; i++)
        {
            Transform child = refChild.transform.GetChild(i);
            int horizontalOffset = (i % entitiesPerRow);
            int verticalOffset = (i / entitiesPerRow);
            child.localPosition = new Vector3(child.transform.localScale.x * spacing + horizontalOffset * spacing * child.transform.localScale.x, -verticalOffset * spacing * child.transform.localScale.y, 0);
            //child.rotation = Quaternion.Euler(transform.forward);
            if( i % entitiesPerRow == 0)
            {
                verticalCenterOffset += (spacing * child.transform.localScale.y );
                Debug.Log(verticalCenterOffset);
            }

        }
        Debug.Log(backgroundHorizontalOffset);
        background.transform.localScale = new Vector3(background.transform.localScale.x, verticalCenterOffset + backgroundVerticalOffset / 2, background.transform.localScale.z);
        background.transform.localPosition = new Vector3(backgroundHorizontalOffset, backgroundVerticalOffset  - verticalCenterOffset/2, 0);
         
    }

    public void importDeck(string deckId)
    {
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
            for (int i = 0; i < cards.Count; i++)
            {
                for (int j = 0; j < (int)cards[i]["quantity"]; j++)
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
        int horizontalOffset = (index % 5);
        int verticalOffset = (index / 5);
        Debug.Log(index);
        // check for errors
        if (www.error == null)
        {
            GameObject g = Instantiate(cardPrefab, transform.position + new Vector3(horizontalOffset * 30, verticalOffset * 30, 0), transform.rotation) as GameObject;
            g.GetComponent<Renderer>().material.mainTexture = www.texture;
            g.transform.Rotate(0, 90, 0);
            addEntity(g.transform);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

    // Update is called once per frame
    void Update () {
        positionEntities();
	}
}
