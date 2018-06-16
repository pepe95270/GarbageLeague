using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashInfo
{
	public enum TrashType { Green, Yellow, Blue, White }
	public TrashType trashType;

	public TrashInfo(TrashType trashType)
	{
		this.trashType = trashType;
	}

	public TrashInfo(TrashInfo trashInfo)
	{
		this.trashType = trashInfo.trashType;
	}
}
