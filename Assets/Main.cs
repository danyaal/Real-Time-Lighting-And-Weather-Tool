using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	public GameObject RealTimeLightingPrefab;

	// Use this for initialization
	void Start () {
		// Spawn directional light
		Instantiate (RealTimeLightingPrefab);
	}

}
