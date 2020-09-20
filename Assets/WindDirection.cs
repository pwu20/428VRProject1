using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using TMPro;

public class WindDirection : MonoBehaviour
{
	 public GameObject windTextObject;
	 public GameObject windDirection;
       string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,USa&APPID=0aacc585f959bd058239a48ea0ee650d&units=imperial";
    // Start is called before the first frame update
    void Start()
    {
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
                //Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
				
				//parse the temp from the url
				string s = webRequest.downloadHandler.text;
				int foundWindSpeed = s.IndexOf("speed");
				int foundWindDirection = s.IndexOf("deg");
				//print(s.Substring(foundWindSpeed + 6, 2)); 
				//print(s.Substring(foundWindDirection + 5, 3)); 
				int directionNum = Int32.Parse(s.Substring(foundWindDirection + 5, 3));
				
				if((directionNum >= 0 && directionNum <= 23) || (directionNum >= 337 && directionNum <= 360)){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH N";
					windDirection.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
				}	
				else if (directionNum >= 24 && directionNum <= 68){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH NE";
					windDirection.transform.Rotate(0.0f, 145.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 69 && directionNum <= 113){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH E";
					windDirection.transform.Rotate(0.0f, 175.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 114 && directionNum <= 158){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH SE";
					windDirection.transform.Rotate(0.0f, 235.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 159 && directionNum <= 203){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH S";
					windDirection.transform.Rotate(0.0f, 275.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 204 && directionNum <= 248){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH SW";
					windDirection.transform.Rotate(0.0f, 315.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 249 && directionNum <= 293){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH W";
					windDirection.transform.Rotate(0.0f, 360.0f, 0.0f, Space.Self);
				}
				else if (directionNum >= 294 && directionNum <= 336){
					windTextObject.GetComponent<TextMeshPro>().text = s.Substring(foundWindSpeed  + 7, 1) + " MPH NW";
					windDirection.transform.Rotate(0.0f, 60.0f, 0.0f, Space.Self);
				}
				
            }
        }
		

		
		
    }
}
