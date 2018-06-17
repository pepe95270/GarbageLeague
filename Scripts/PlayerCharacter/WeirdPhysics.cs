using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdPhysics : MonoBehaviour {

    private float massInit;

	// Use this for initialization
	void Start () {
        massInit = gameObject.GetComponent<Rigidbody>().mass;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y > 0)
        {
            Vector3 reductor;
            if(gameObject.GetComponent<Rigidbody>().velocity.y > 0)
            {
                reductor = new Vector3(0.5f * gameObject.GetComponent<Rigidbody>().velocity.x, 0.3f*gameObject.GetComponent<Rigidbody>().velocity.y, 0.5f * gameObject.GetComponent<Rigidbody>().velocity.z);
            }
            else
            {
                reductor = new Vector3(0.5f * gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, 0.5f * gameObject.GetComponent<Rigidbody>().velocity.z);
            }
            gameObject.GetComponent<Rigidbody>().velocity = reductor;
        }
	}
}
