using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class WeatherAPIScript : MonoBehaviour
{
    public GameObject weatherTextObject;
       string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,USa&APPID=0aacc585f959bd058239a48ea0ee650d&units=imperial";

   
    void Start()
    {

    // wait a couple seconds to start and then refresh every 900 seconds

       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
				
				//parse the temp from the url
				string s = webRequest.downloadHandler.text;
				int foundTemp = s.IndexOf("temp");
				int foundHum = s.IndexOf("humidity");
				//print(s.Substring(foundTemp + 6, 2)); 
				//print(s.Substring(foundHum + 10, 2)); 
				weatherTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundTemp + 6, 2) + " F\n\n" + s.Substring(foundHum + 10, 2) + " %";
            }
        }
		

		
		
    }
}