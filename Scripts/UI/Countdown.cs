using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Countdown : MonoBehaviour
{
    private float timeleft;
	private float previousTimeLeft;
    public Text countdownUI;
    public GameObject blueZone;
    public GameObject yellowZone;
    public GameObject greenZone;
    public GameObject whiteZone;
    public GameObject startZone;
	
	void Update ()
	{
		previousTimeLeft = timeleft;
		timeleft = gameObject.GetComponent<GameManager>().readyTimer;
		if (timeleft > 0)
		{
			if (previousTimeLeft == timeleft)
			{
				countdownUI.text = "Ready?";
			}
			else
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(timeleft);
				countdownUI.text = String.Format("{0:00}:{1:00}", timeSpan.Seconds, Mathf.Floor(timeSpan.Milliseconds/10f));
			}
		}
		else
		{
			if (timeleft != previousTimeLeft)
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
}
