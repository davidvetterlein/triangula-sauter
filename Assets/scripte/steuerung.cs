using UnityEngine;
using System.Collections;

public class steuerung : MonoBehaviour {
	public bool rechts=false;
	public bool links=false;
	public float speed=0f;
	public bool jumping = false;
	public int jump = 50;
	public int newjump = 50;
	public bool canjump = true;
	public float up;
	public GameObject cam;
	public int maxy = 0;
	public int miny = 0;
	

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
		if(jump == 0 && canjump == true){
			jumping = true;
			jump = newjump;
			canjump = false;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("up")){
			if(jump == 0 && canjump == true){
			jumping = true;
			jump = newjump;
			canjump = false;
		}
		}
		
		cam.transform.position = new Vector3(gameObject.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		if (jumping == true && jump >= 1 || Input.GetKey("up") && jump >= 1){
			jump -= 1;
			gameObject.GetComponent<Rigidbody>().Sleep();
			gameObject.transform.position += new Vector3 (0, up, 0);
		} else if (jumping == true && jump <= 0){
			gameObject.GetComponent<Rigidbody>().WakeUp();
			jumping = false;
		}
		if (rechts == true || Input.GetKey("right")) {
			gameObject.transform.position += new Vector3 (speed, 0, 0);
		}
		if (links == true || Input.GetKey("left")) {
			gameObject.transform.position -= new Vector3 (speed, 0, 0);
		}
	
	}
	
	void OnCollisionEnter(Collision col){
		if(col.transform.gameObject.position.y >= miny && col.transform.gameObject.position.y >= maxy){
			gameObject.GetComponent<Rigidbody>().WakeUp();
			jump = 0;
			canjump = true;
			jumping = false;
		}
	}
}
