using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingAura : MonoBehaviour {

    public TrashObject trashObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles += new Vector3(0f, 0.3f, 0f);
    }

    public void Initialize()
    {
		//didn't use trashinfo.GetColor because of shader properties that needs 255 notation colors
        if (trashObject.trashInfo.trashType == TrashType.Green)
        {
            GetComponent<Renderer>().material.SetColor("_MKGlowColor", new Color(0, 255, 0, 255));
        }
        else if (trashObject.trashInfo.trashType == TrashType.Blue)
        {
            GetComponent<Renderer>().material.SetColor("_MKGlowColor", new Color(0, 0, 255, 255));
        }
        else if (trashObject.trashInfo.trashType == TrashType.Yellow)
        {
            GetComponent<Renderer>().material.SetColor("_MKGlowColor", new Color(255, 255, 0, 255));
		}
		else if (trashObject.trashInfo.trashType == TrashType.Unicorn)
		{
			GetComponent<Renderer>().material.SetColor("_MKGlowColor", new Color(1f, 0.1f, 1f, 1f));
		}
		else if (trashObject.trashInfo.trashType == TrashType.White)
        {
            GetComponent<Renderer>().material.SetColor("_MKGlowColor", new Color(255, 255, 255, 255));
        }
    }
}
