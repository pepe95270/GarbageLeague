using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Countdown : MonoBehaviour {

    private float timeleft;
    public Text countdownUI;
    public GameObject blueZone;
    public GameObject yellowZone;
    public GameObject greenZone;
    public GameObject whiteZone;
    public GameObject startZone;
	
	void Update ()
	{
		timeleft = gameObject.GetComponent<GameManager>().readyTimer;
		if (timeleft > 0)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(timeleft);
			countdownUI.text = String.Format("{0:D2}:{1:D2}", timeSpan.Seconds, timeSpan.Milliseconds);
		}
		else
		{
			countdownUI.text = "";
			blueZone.SetActive(true);
			yellowZone.SetActive(true);
			greenZone.SetActive(true);
			whiteZone.SetActive(true);
			startZone.GetComponent<Renderer>().material.SetFloat("_MKGlowPower", 0.2f);
			startZone.GetComponent<Renderer>().material.SetColor("_MKGlowTexColor", new Color(0.5f, 0.5f, 0));
			startZone.GetComponent<Renderer>().material.SetFloat("_MKGlowTexStrength", 0.2f);
		}
	}
}
