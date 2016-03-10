using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Editorscript : MonoBehaviour {
    //public Vector3 poss;
    public float y;
    public float x;
    void Update () {
        //transform.position = poss;
        x = transform.position.x;
        y = transform.position.y;

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        gameObject.transform.position = new Vector3(x, y, transform.position.z);
    }
}
