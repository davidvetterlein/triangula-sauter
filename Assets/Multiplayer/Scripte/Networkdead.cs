using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Networkdead : NetworkBehaviour {

    [SyncVar]
    public bool dead = false;

    public Vector3 Spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(dead == true)
        {
            gameObject.transform.position = Spawn;
            Cmdtot(false);
        }
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "tot" && isLocalPlayer)
        {
            Cmdtot(true);
        }
    }

    [Command]
    private void Cmdtot(bool tdead)
    {
        dead = tdead;
    }

}
