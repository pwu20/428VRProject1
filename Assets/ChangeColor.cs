using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class ChangeColor : MonoBehaviour
{
	Renderer rend;
	   string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,USa&APPID=0aacc585f959bd058239a48ea0ee650d&units=imperial";
	   
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
		rend.material.color = new Color(255, 0, 0);;
		InvokeRepeating("GetDataFromWeb", 2f, 900f);
    }
	
	   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }

    // Update is called once per frame
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
				int foundTemp = s.IndexOf("temp");
				int temp = Int32.Parse(s.Substring(foundTemp + 6, 2));
				print("this is temp" + temp); 
				
				
				
				//if between <0 to 30 is blue
				if(temp <= 30){
					rend.material.color = Color.blue;

				}
				//if between 31-50 is light blue
				if(temp >= 31 && temp <= 50){
					rend.material.color = Color.cyan;
				}
				//if 51-70 is green
				if(temp >= 51 && temp <= 70){
					rend.material.color = Color.green;
					
				}
				//if 71-80 is yellow
				if(temp >= 71 && temp <= 80){
					rend.material.color = Color.yellow;
				}
				//if 80  is red
				if(temp >= 81){
					rend.material.color = Color.red;
				}
            }
        }
		

		
		
    }
}