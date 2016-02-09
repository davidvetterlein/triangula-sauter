using UnityEngine;
using System.Collections;

public class GegnerKi : MonoBehaviour {
	public int wahrscheinlichkeit = 0;
	public float speed = 0f;
	public bool rechts = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (rechts == true) {
			gameObject.transform.position += new Vector3 (speed, 0, 0);
		} else {
			gameObject.transform.position -= new Vector3 (speed, 0, 0);
		}
		wahrscheinlichkeit = Random.Range (0, 1000);
		if (wahrscheinlichkeit >= 994) {
			if (rechts == true) {
				rechts = false;
			} else {
				rechts = true;
			}
		}
	}
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "wand"){
			if(rechts == true){
				rechts = false;
			} else {
				rechts = true;
			}
		}
	}
}
