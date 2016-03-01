using UnityEngine;
using System.Collections;

public class jumper : MonoBehaviour {

	public float up;
	float maxy;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.up);
		if (hit.collider.tag == "Player")
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().Sleep();
			if(hit.collider.gameObject.transform.position.y <= maxy){
				hit.collider.gameObject.transform.position += new Vector3(0, up, 0);
			}
        } else{
			hit.collider.gameObject.GetComponent<Rigidbody2D>().WakeUp();
		}
	}
}
