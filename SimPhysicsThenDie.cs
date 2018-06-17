using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimPhysicsThenDie : MonoBehaviour {

    private float lifeLeft = 3.0f;
    public GameObject child;
    private bool destroyed = false;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.transform.gameObject.name == "Map" && !destroyed)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            child.transform.parent = null;
            destroyed = true;
            Destroy(gameObject);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.transform.gameObject.name == "Map" && !destroyed)
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            child.transform.parent = null;
            destroyed = true;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!destroyed)
        {
            lifeLeft -= Time.deltaTime;
            if (lifeLeft <= 0)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                child.transform.parent = null;
                destroyed = true;
                Destroy(gameObject);
            }
            if (gameObject.transform.position.y > 0 && !destroyed)
            {
                Vector3 reductor;
                if (gameObject.GetComponent<Rigidbody>().velocity.y > 0)
                {
                    reductor = new Vector3(0.5f * gameObject.GetComponent<Rigidbody>().velocity.x, 0.3f * gameObject.GetComponent<Rigidbody>().velocity.y, 0.5f * gameObject.GetComponent<Rigidbody>().velocity.z);
                }
                else
                {
                    reductor = new Vector3(0.5f * gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, 0.5f * gameObject.GetComponent<Rigidbody>().velocity.z);
                }
                gameObject.GetComponent<Rigidbody>().velocity = reductor;
            }
        }
    }
}
