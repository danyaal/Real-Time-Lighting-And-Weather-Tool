using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Vector3.zero;
		pos.x = Random.Range(-1, 1);
		this.transform.position += pos*Time.deltaTime;

		if(Camera.main.WorldToViewportPoint(this.transform.position).y < 0f) {
			Destroy(this.gameObject);
		}
	}
}
