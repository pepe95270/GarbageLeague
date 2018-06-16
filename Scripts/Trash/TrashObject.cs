using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
	public TrashInfo trashInfo;

	public void Start()
	{
		trashInfo = new TrashInfo(TrashInfo.TrashType.Green);
	}

	public void Initialize(TrashInfo trashInfo)
	{
		this.trashInfo = trashInfo;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			TrashInventory otherTrashInventory = other.GetComponentInParent<TrashInventory>();
			otherTrashInventory.AddTrashObject(this);
		}
	}
}
