using UnityEngine;
using System.Collections;

public class RealTimeLightingScript : MonoBehaviour {

	public bool isWeatherOn = false;
	public bool DebugRain = false;
	public bool DebugSnow = false;

	public GameObject SnowPrefab;
	public GameObject RainPrefab;
	
	// Update is called once per frame
	void Update () {
		// Get DateTime
		System.DateTime now = System.DateTime.Now;
		int month = now.Month;
		int hour = now.Hour;
		
		// Set season
		if(isWeatherOn) {
			if(month == 12 || month == 1 || month == 2) {
				Snow();
			} else if(month == 3 || month == 4 || month == 5) {
				Rain();
			} else if(month == 6 || month == 7 || month == 8) {
				// summer
			} else {
				// autumn
			}
		}
		
		// Move sun in the sky
		MoveSun(hour);
		
		// Change light depending on scatter ray
		SimulateRayLeighScattering(hour);


		/***********
		 * Debug   *
		 * *********/
		if(DebugRain) {
			Rain ();
		} else if(DebugSnow) {
			Snow();
		}

	}

	void Snow() {
		GameObject snow = Instantiate(SnowPrefab) as GameObject;
		Vector3 snowPos = Vector3.zero;
		snowPos.x = Random.Range(-10, 10);
		snowPos.y = 10f;
		snowPos.z = Random.Range(-10, 10);
		snow.transform.position = snowPos;
	}

	void Rain() {
		GameObject rain = Instantiate(RainPrefab) as GameObject;
		Vector3 rainPos = Vector3.zero;
		rainPos.x = Random.Range(-10, 10);
		rainPos.y = 10f;
		rainPos.z = Random.Range(-10, 10);
		rain.transform.position = rainPos;
	}

	void MoveSun(int hour) {
		GameObject light = GameObject.FindGameObjectWithTag("lightsource");
		if(hour > 7 && hour < 19) {
			float direction = (hour-7f)*15f;
			this.transform.rotation = Quaternion.AngleAxis(direction, Vector3.right);
		} else {
			light.light.enabled = false;
		}
	}

	void SimulateRayLeighScattering(int hour) {
		Camera m = Camera.main.camera;
		float red = 0f;
		float green = 100f;
		float blue = 150f;
		if(hour >= 6 && hour <= 20) {
			red = (150f/7f)*System.Math.Abs(hour-13);
		} else {
			red = 0f;
			green = 50f;
			blue = 100f;
		}
		Color c = new Color(red/255f, green/255f, blue/255f);
		m.camera.backgroundColor = c;
		m.camera.clearFlags = CameraClearFlags.SolidColor;
	}
}
