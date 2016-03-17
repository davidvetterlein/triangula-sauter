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
	public float maxy = 0;
	public float miny = 0;
	public Vector3 Startpos;
    public float camminus;
    public int Xp;
	

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
        Xp = PlayerPrefs.GetInt("Munzen");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PlayerPrefs.SetInt("Munzen", Xp);
		if(Input.GetKey("up")){
			if(jump == 0 && canjump == true){
			jumping = true;
			jump = newjump;
			canjump = false;
		}
		}
		
		cam.transform.position = new Vector3(gameObject.transform.position.x - camminus, cam.transform.position.y, cam.transform.position.z);
		if (jumping == true && jump >= 1 || Input.GetKey("up") && jump >= 1){
			jump -= 1;
			gameObject.GetComponent<Rigidbody2D>().Sleep();
			gameObject.transform.position += new Vector3 (0, up, 0);
		} else if (jumping == true && jump <= 0){
			gameObject.GetComponent<Rigidbody2D>().WakeUp();
			jumping = false;
		}
		if (rechts == true || Input.GetKey("right")) {
			gameObject.transform.position += new Vector3 (speed, 0, 0);
		}
		if (links == true || Input.GetKey("left")) {
			gameObject.transform.position -= new Vector3 (speed, 0, 0);
		}
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "tot"){
            gameObject.GetComponent<TheHook>().UndoCall();
			gameObject.transform.position = Startpos;
		}
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
        jump = 0;
        jumping = false;
        if (col.gameObject.transform.position.y > gameObject.transform.position.y - miny && col.gameObject.transform.position.y < gameObject.transform.position.y + maxy)
        {
            canjump = true;
        }
    }
	
	
	
	
	
	
}
