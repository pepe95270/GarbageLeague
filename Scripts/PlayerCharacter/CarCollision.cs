using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {

    private GameObject target;
    public int dropRate = 3;
    public GameObject physicsBallSimulationPrefab;
    public GameObject trashPrefab;
	public GameObject unicornPrefab;
    public GameObject trashContainer;

    private void Awake()
    {
        trashContainer = GameObject.Find("Map");
    }

    private void DropTrash()
    {
        List<TrashInfo> items = target.GetComponent<TrashInventory>().trashInfoList;

        foreach (TrashInfo itemTrash in items)
        {
            GameObject simulation = Instantiate(physicsBallSimulationPrefab, trashContainer.transform);
            simulation.transform.position = target.transform.position + 8*Vector3.up;
			GameObject newTrash = null;
			if (itemTrash.trashType == TrashType.Unicorn)
			{
				newTrash = Instantiate(unicornPrefab, trashContainer.transform, true);
			}
			else
			{
				newTrash = Instantiate(trashPrefab, trashContainer.transform, true);
			}
            newTrash.transform.Translate(target.transform.position + 8*Vector3.up);
            newTrash.transform.parent = simulation.transform;
            simulation.GetComponent<SimPhysicsThenDie>().child = newTrash;
            newTrash.GetComponent<TrashObject>().Initialize(new TrashInfo(itemTrash));
        }
        target.GetComponent<TrashInventory>().ResetInventory();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && collision.collider.name != "FrontCollider")
        {
            target = collision.collider.transform.root.gameObject;
            Vector3 dir = new Vector3();
            dir = collision.contacts[0].point - target.transform.position;
            dir = dir / Vector3.Magnitude(dir);
            float sc = Vector3.Dot(dir,target.GetComponent<Rigidbody>().velocity);
            if (sc < 0)
            {
                if (target.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    if (Vector3.Magnitude(target.GetComponent<Rigidbody>().velocity) > 20)
                    {
                        target.GetComponent<TrashInventory>().Stun();
                        DropTrash();
                    }
                }
            }
        }
    }

}
