using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class schaltermultiplayer : NetworkBehaviour {
    public GameObject[] Mauer;
    public int Schalteranz = 1;
    public int Schalter = 0;

    public void Start()
    {
        Mauer = GameObject.FindGameObjectsWithTag("Mauer");
    }
    void Update()
    {
        if (active == false)
        {
            Mauer[CSchalter].SetActive(false);
        }
    }
    [SyncVar(hook = "OnActiveChange")]
    public bool active = true;

    [SyncVar]
    public int CSchalter = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "knopf")
        {
            Schalter = int.Parse(other.gameObject.name);
            CmdDisable();
        }
    }

    [Command]
    private void CmdDisable()
    {
        active = false;
        CSchalter = Schalter;
    }

    private void OnActiveChange(bool updatedActive)
    {
        active = updatedActive;
        Debug.Log("Active changed on client!");
    }
}
