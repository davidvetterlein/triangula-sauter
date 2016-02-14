using UnityEngine;
using System.Collections;

public class TheHook : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CallHook();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }

    public void CallHook()
    {
        gameObject.GetComponent<DistanceJoint2D>().enabled = true;
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1), Vector2.up);
        if (hit.collider != null)
        {
            gameObject.GetComponent<DistanceJoint2D>().connectedAnchor = hit.collider.transform.position;
            //gameObject.GetComponent<DistanceJoint2D>().distance = gameObject.transform.position.y;
        }
    }

    public void UndoCall()
    {
        gameObject.GetComponent<DistanceJoint2D>().enabled = false;
    }
}
