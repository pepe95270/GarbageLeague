using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Mathf.Abs(gameObject.transform.rotation.eulerAngles.y) < 2f)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.eulerAngles.x, 0, gameObject.transform.rotation.eulerAngles.z));
            this.enabled = false;
        }
        gameObject.transform.Rotate(Vector3.up*(-0.5f), Space.World);
	}
}
