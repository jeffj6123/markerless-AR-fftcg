using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GPS : MonoBehaviour {

    public Text coordinates;

    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
	// Use this for initialization
	void Start () {
        Instance = this;
        StartCoroutine(StartLocationService());
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        coordinates.text = "lat:" + latitude.ToString() + " longitude: " + longitude.ToString();
	}

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Use has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if ( maxWait <= 0)
        {
            Debug.Log("TImed out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

    }
}
