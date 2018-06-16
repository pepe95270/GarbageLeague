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

	public void Start()
	{
		trashInfo = new TrashInfo(TrashType.Green);
		renderer.material.color = Color.green;
	}

	public void Initialize(TrashInfo trashInfo)
	{
		this.trashInfo = trashInfo;
		switch (trashInfo.trashType)
		{
			case TrashType.Green:
				renderer.material.color = Color.green;
				break;
			case TrashType.Yellow:
				renderer.material.color = Color.yellow;
				break;
			case TrashType.Blue:
				renderer.material.color = Color.blue;
				break;
			case TrashType.White:
				renderer.material.color = Color.white;
				break;
		}
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
