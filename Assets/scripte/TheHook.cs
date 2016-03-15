using UnityEngine;
using System.Collections;

public class TheHook : MonoBehaviour {
    public bool called = false;
	public float distance;
	public Vector3 grabpos;
	public int lengthOfLineRenderer = 2;
	public bool callable = true;
    public GameObject nuller;
    public bool abbruch = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.GetComponent<DistanceJoint2D>().distance = distance;
		if(called == false){
			GetComponent<LineRenderer>().enabled = true;
			Vector3[] points = new Vector3[lengthOfLineRenderer];	
			points[1] = gameObject.transform.position;
			points[0] = grabpos;
			GetComponent<LineRenderer>().SetPositions(points);
		}else if(called == true){
			GetComponent<LineRenderer>().enabled = false;
		}
		
		if(Input.GetKey("up") && abbruch == false && distance >= 1)
        {
			distance -= 0.05f;
		}

        if (Input.GetKey("down") && abbruch == false){
			distance += 0.05f;
		}
        /*if (Input.GetKeyDown("down"))
        {
            transform.position -= new Vector3(0, 0.1f, 0);
        }
        */
        if (Input.GetKeyDown("m"))
        {
            {
                CallHook();
            }
        }
        if (Input.GetKeyDown("n")){
            {
                UndoCall();
            }
        }
    }

    public void CallHook()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.6f), Vector2.up);
        distance = Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(hit.transform.position.x, 0));
        if (hit.collider != null && hit.collider.tag == "callable")
        {
            grabpos = hit.transform.position;
            distance = Vector3.Distance(transform.position, grabpos);
			if (distance >= 1) {
				distance -= 0.2f;           
				gameObject.GetComponent<DistanceJoint2D>().connectedAnchor = hit.transform.position;
				called = false;
				gameObject.GetComponent<DistanceJoint2D>().enabled = true;
			}
        }
    }

    public void UndoCall()
    {
        called = true;
        gameObject.GetComponent<DistanceJoint2D>().enabled = false;
    }
	
	void OnCollisionEnter2D(Collision2D col){
        abbruch = true;
	}
    void OnCollisionExit2D(Collision2D col)
    {
        abbruch = false;
    }
}
