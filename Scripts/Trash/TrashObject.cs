using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
	public TrashInfo trashInfo;
	private new Renderer renderer;

	private void Awake()
	{
		renderer = GetComponent<Renderer>();
	}

	public void Initialize(TrashInfo trashInfo)
	{
		this.trashInfo = trashInfo;
        GetComponentInChildren<GlowingAura>().Initialize();
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
