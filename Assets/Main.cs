using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject RealTimeLightingPrefab;

	// Use this for initialization
	void Start () {
		// Spawn directional light
		Instantiate (RealTimeLightingPrefab);
	}

	void Update() {
		if(Input.GetKeyDown("0")) {
			GameObject rtlp = GameObject.FindGameObjectWithTag("lightsource");
			rtlp.GetComponent<RealTimeLightingScript>().DebugRain = false;
			rtlp.GetComponent<RealTimeLightingScript>().DebugSnow = false;
		}
		if(Input.GetKeyDown("1")) {
			GameObject rtlp = GameObject.FindGameObjectWithTag("lightsource");
			rtlp.GetComponent<RealTimeLightingScript>().DebugRain = true;
			rtlp.GetComponent<RealTimeLightingScript>().DebugSnow = false;
		} else if(Input.GetKeyDown("2")) {
			GameObject rtlp = GameObject.FindGameObjectWithTag("lightsource");
			rtlp.GetComponent<RealTimeLightingScript>().DebugRain = false;
			rtlp.GetComponent<RealTimeLightingScript>().DebugSnow = true;
		}
	}

}
