using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TrashType { Green, Yellow, Blue, White, Unicorn }

public class TrashInfo
{
	public TrashType trashType;

	public TrashInfo(TrashType trashType)
	{
		this.trashType = trashType;
	}

	public TrashInfo(TrashInfo trashInfo)
	{
		this.trashType = trashInfo.trashType;
	}

	public Color GetColor()
	{
		switch (trashType)
		{
			case TrashType.Unicorn:
				return new Color(1f, 0.1f, 1f, 1f);
			case TrashType.Green:
				return new Color(0f, 1f, 0, 1f);
			case TrashType.Blue:
				return new Color(0f, 0f, 1f, 1f);
			case TrashType.Yellow:
				return new Color(1f, 1f, 0f, 1f);
			case TrashType.White:
			default:
				return new Color(1f, 1f, 1f, 1f);
		}
	}
}
