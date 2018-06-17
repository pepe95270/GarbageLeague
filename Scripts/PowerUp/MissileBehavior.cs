using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class MissileBehavior : MonoBehaviour {

    public GameObject sender;
    public int speed;

    private bool launched = false;
    private bool explodedAlready = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (launched)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
	}

    public void Launch()
    {
        transform.position = sender.transform.position;
        transform.rotation = sender.transform.rotation;
        launched = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.parent.gameObject != sender && !explodedAlready)
        {
            explodedAlready = true;
            if (other.gameObject.GetComponentInParent<CarController>())
            {
                other.gameObject.GetComponentInParent<CarController>().ReactToMissileExplosion();
            }
            Destroy(gameObject);
        }
    }
}
