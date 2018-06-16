using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBehavior : MonoBehaviour {

    public TrashType trashType;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            TrashInventory otherTrashInventory = other.GetComponentInParent<TrashInventory>();
            for(int i=0; i < otherTrashInventory.trashInfoList.Count; i++)
            {
                if(otherTrashInventory.trashInfoList[i].trashType == trashType)
                {
                    Debug.Log("un joueur a déposé un déchet " + otherTrashInventory.trashInfoList[i].trashType);
                    otherTrashInventory.trashInfoList.Remove(otherTrashInventory.trashInfoList[i]);
                    i--;
					other.GetComponentInParent<Score>().score++;
                }
            }
        }
    }
}
