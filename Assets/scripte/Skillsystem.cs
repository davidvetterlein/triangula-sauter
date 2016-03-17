using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skillsystem : MonoBehaviour {
	public float[] SpeedLevel;
	public int Levelspeed;

	public int[] JumpLevel;
	public int Jumplength;

    public Text Xptext;
    public int Xp;
    public int[] Xppreise;

    public GameObject skillsystem;
    public Text CJL;
    public Text NJL;
    public Text JS;


    // Use this for initialization
    void Start () {
		Levelspeed = PlayerPrefs.GetInt ("LevelSpeed");
		Jumplength = PlayerPrefs.GetInt ("JumpLength");
	}
	
	// Update is called once per frame
	void Update () {
        Xp = gameObject.GetComponent<steuerung>().Xp;
        Xptext.text = Xp.ToString();
		gameObject.GetComponent<steuerung> ().newjump = JumpLevel [Jumplength];
        gameObject.GetComponent<steuerung>().speed = SpeedLevel[Levelspeed];
        NJL.text = Xppreise[Jumplength].ToString();
        JS.text = JumpLevel[Jumplength].ToString();
        int cjl = Jumplength +1;
        CJL.text = cjl.ToString();
        PlayerPrefs.SetInt("JumpLength", Jumplength);

        if (Input.GetKeyDown("i")){
            if(skillsystem.activeSelf == true)
            {
                skillsystem.SetActive(false);
            }else{
                skillsystem.SetActive(true);
            }
        }
    }

    public void UpJumpLv()
    {
        if(Xp >= Xppreise[Jumplength])
        {
            gameObject.GetComponent<steuerung>().Xp -= Xppreise[Jumplength];
            Jumplength += 1;
            skillsystem.SetActive(false);
        }
    }

    public void MobilOpen()
    {
        if (skillsystem.activeSelf == true)
        {
            skillsystem.SetActive(false);
        }
        else {
            skillsystem.SetActive(true);
        }
    }
}
