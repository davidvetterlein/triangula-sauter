using UnityEngine;
using System.Collections;

public class steuerung : MonoBehaviour {
	public bool rechts=false;
	public bool links=false;
	public float speed=0f;
	public bool jumping = false;
	public int jump = 50;
	public int newjump = 50;
	public float up;

	public void clickupL (){
		links = false;
		
	}
	public void clickdownL (){
		links = true;
		
	}
	public void clickupR (){
		rechts = false;

	}
	public void clickdownR (){
		rechts = true;
		
	}
	
	public void Jump () {
		if(jump == 0){
			jumping = true;
			jump = newjump;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (jumping == true && jump >= 1){
			jump -= 1;
			gameObject.GetComponent<Rigidbody>().Sleep();
			gameObject.transform.position += new Vector3 (0, up, 0);
		} else if (jumping == true && jump <= 0){
			gameObject.GetComponent<Rigidbody>().WakeUp();
			jumping = false;
		}
		if (rechts == true) {
			gameObject.transform.position += new Vector3 (speed, 0, 0);
		}
		if (links == true) {
			gameObject.transform.position -= new Vector3 (speed, 0, 0);
		}
	
	}
}
