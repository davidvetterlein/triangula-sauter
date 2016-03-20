using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skillsystem : MonoBehaviour {
	public float[] SpeedLevel;
	public int Levelspeed;

	public int[] JumpLevel;
	public int Jumplength;

    public Slider Xpslider;
    public int Xp;
    public int Punkte;
    public Text Punktetxt;

    public GameObject skillsystem;
    public GameObject IngameButtons;

    public Text JumpLv;
    public Text SpeedLv;


    // Use this for initialization
    void Start () {
		Levelspeed = PlayerPrefs.GetInt ("Levelspeed");
		Jumplength = PlayerPrefs.GetInt ("JumpLength");
        Punkte = PlayerPrefs.GetInt("Punkte");
	}
	
	// Update is called once per frame
	void Update () {
        Punktetxt.text = Punkte.ToString();
        Xp = gameObject.GetComponent<steuerung>().Xp;
        Xpslider.value = Xp;
        if(Xp >= 100)
        {
            Punkte += 1;
            gameObject.GetComponent<steuerung>().Xp = 0;
        }

		gameObject.GetComponent<steuerung> ().newjump = JumpLevel [Jumplength];
        gameObject.GetComponent<steuerung>().speed = SpeedLevel[Levelspeed];

        JumpLv.text = JumpLevel[Jumplength].ToString();
        SpeedLv.text = SpeedLevel[Levelspeed].ToString();

        PlayerPrefs.SetInt("JumpLength", Jumplength);
        PlayerPrefs.SetInt("Levelspeed", Levelspeed);
        PlayerPrefs.SetInt("Punkte", Punkte);

        if (Input.GetKeyDown("i")){
            if(skillsystem.activeSelf == true)
            {
                skillsystem.SetActive(false);
                IngameButtons.SetActive(true);
            }
            else{
                skillsystem.SetActive(true);
                IngameButtons.SetActive(false);
            }
        }
    }

    public void UpJumpLv()
    {
        if(Punkte >= 1 && Jumplength < JumpLevel.Length -1)
        {
            Punkte -= 1;
            Jumplength += 1;
        }
    }
    public void UpSpeedLv()
    {
        if (Punkte >= 1 && Levelspeed < SpeedLevel.Length -1)
        {
            Punkte -= 1;
            Levelspeed += 1;
        }
    }

    public void MobilOpen()
    {
        if (skillsystem.activeSelf == true)
        {
            skillsystem.SetActive(false);
            IngameButtons.SetActive(true);
        }
        else {
            skillsystem.SetActive(true);
            IngameButtons.SetActive(false);
        }
    }
}
