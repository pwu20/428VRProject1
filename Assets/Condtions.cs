using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System;
using TMPro;
using Vuforia;

public class Condtions : MonoBehaviour
{
	string url = "http://api.openweathermap.org/data/2.5/weather?q=Chicago,USa&APPID=0aacc585f959bd058239a48ea0ee650d&units=imperial";
	public GameObject sun;
	public GameObject clouds;
	public GameObject clouds1;
	public GameObject rain;
	public GameObject mist;
	public GameObject snow;
	public GameObject thunder;
	public GameObject conTextObject;
	public TrackableBehaviour theTrackable;
	
	int toggleNumber;
	
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 2f, 900f);
		toggleNumber = 0;
		sun.SetActive(false);
		clouds.SetActive(false);
		clouds1.SetActive(false);
		rain.SetActive(false);
		mist.SetActive(false);
		snow.SetActive(false);
		thunder.SetActive(false);
		//conTextObject.GetComponent<TextMeshPro>().text = "If you see this then something is broken";


		
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
				int foundCondition = s.IndexOf("description");
	
				//print(s.Substring(foundCondition + 13, 17)); 

				string condtionString = s.Substring(foundCondition + 13, 17);
				print("this is current weather" + condtionString); 
				//string condtionString = "clear sky";
				
				
			
				if ( condtionString.Contains("clear sky")) {
					sun.SetActive(true);
					clouds.SetActive(false);
					clouds1.SetActive(false);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Clear Sky";
				}
				
				if ( condtionString.Contains("few clouds") ) {
					sun.SetActive(true);
					clouds.SetActive(true);
					clouds1.SetActive(false);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Few Clouds";
				}
				if ( condtionString.Contains("scattered clouds") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(false);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Scattered Clouds";
				}
				if ( condtionString.Contains("broken clouds") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(true);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Broken Clouds";
				}
				if ( condtionString.Contains("shower rain") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(true);
					rain.SetActive(true);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Shower Rains";
				}
				if ( condtionString.Contains("rain ") ) {
					sun.SetActive(true);
					clouds.SetActive(true);
					clouds1.SetActive(false);
					rain.SetActive(true);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Rain";
				}
				if ( condtionString.Contains("thunderstorm") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(true);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(false);
					thunder.SetActive(true);
					conTextObject.GetComponent<TextMeshPro>().text = "ThunderStorm";
				}
				if ( condtionString.Contains("snow") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(true);
					rain.SetActive(false);
					mist.SetActive(false);
					snow.SetActive(true);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Snow";
				}
				if ( condtionString.Contains("mist") ) {
					sun.SetActive(false);
					clouds.SetActive(true);
					clouds1.SetActive(false);
					rain.SetActive(false);
					mist.SetActive(true);
					snow.SetActive(false);
					thunder.SetActive(false);
					conTextObject.GetComponent<TextMeshPro>().text = "Mist";
				}
				
			   
            }
        }
		
    }
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			toggleNumber++;
			//clear sky
			if(toggleNumber == 1){
			sun.SetActive(true);
			clouds.SetActive(false);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Clear Sky";
			}
			//few clouds
			if(toggleNumber == 2){
			sun.SetActive(true);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Few Clouds";
			}
			//scattered clouds
			if(toggleNumber == 3){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Scattered Clouds";
			}
			//broken clouds
			if(toggleNumber == 4){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Broken Clouds";
			}
			//shower rains
			if(toggleNumber == 5){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(true);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Shower Rains";
			}
			//rain
			if(toggleNumber == 6){
			sun.SetActive(true);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(true);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Rain";
			}
			//thunderstorm
			if(toggleNumber == 7){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(true);
			conTextObject.GetComponent<TextMeshPro>().text = "ThunderStorm";
			}
			//snow
			if(toggleNumber == 8){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(true);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Snow";
			}
			//mist
			if(toggleNumber == 9){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(true);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Mist";
			}
			

		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)){
			toggleNumber--;
			//clear sky
			if(toggleNumber == 1){
			sun.SetActive(true);
			clouds.SetActive(false);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Clear Sky";
			}
			//few clouds
			if(toggleNumber == 2){
			sun.SetActive(true);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Few Clouds";
			}
			//scattered clouds
			if(toggleNumber == 3){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Scattered Clouds";
			}
			//broken clouds
			if(toggleNumber == 4){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Broken Clouds";
			}
			//shower rains
			if(toggleNumber == 5){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(true);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Shower Rains";
			}
			//rain
			if(toggleNumber == 6){
			sun.SetActive(true);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(true);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Rain";
			}
			//thunderstorm
			if(toggleNumber == 7){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(false);
			thunder.SetActive(true);
			conTextObject.GetComponent<TextMeshPro>().text = "ThunderStorm";
			}
			//snow
			if(toggleNumber == 8){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(true);
			rain.SetActive(false);
			mist.SetActive(false);
			snow.SetActive(true);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Snow";
			}
			//mist
			if(toggleNumber == 9){
			sun.SetActive(false);
			clouds.SetActive(true);
			clouds1.SetActive(false);
			rain.SetActive(false);
			mist.SetActive(true);
			snow.SetActive(false);
			thunder.SetActive(false);
			conTextObject.GetComponent<TextMeshPro>().text = "Mist";
			}
				
				
			}
			

	}
}
