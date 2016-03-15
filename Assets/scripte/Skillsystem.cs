using UnityEngine;
using System.Collections;

public class Skillsystem : MonoBehaviour {
	public float[] SpeedLevel;
	public int Levelspeed;

	public int[] JumpLevel;
	public int Jumplength;

	// Use this for initialization
	void Start () {
		Levelspeed = PlayerPrefs.GetInt ("LevelSpeed");
		Jumplength = PlayerPrefs.GetInt ("JumpLength");
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<steuerung> ().newjump = JumpLevel [Jumplength];
	}
}
