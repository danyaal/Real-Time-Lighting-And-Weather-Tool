using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.WorldToViewportPoint(this.transform.position).y<0f) {
			Destroy(this.gameObject);
		}
	}
}
