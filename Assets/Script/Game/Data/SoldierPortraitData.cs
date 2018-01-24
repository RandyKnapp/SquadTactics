using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
internal struct PortraitList
{
	public List<Sprite> Portraits;
}

public class SoldierPortraitData : ScriptableObject
{
	[SerializeField]
	private List<PortraitList> _portraits= new List<PortraitList>();

	[MenuItem("Assets/Create/SoldierPortraitData")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<SoldierPortraitData>();
	}

	public Sprite GetPortrait(BodyType body, UniformColor color)
	{
		var bodyIndex = (int) body;
		var colorIndex = (int)color;

		if (bodyIndex < _portraits.Count)
		{
			PortraitList list = _portraits[bodyIndex];
			if (colorIndex < list.Portraits.Count)
			{
				return list.Portraits[colorIndex];
			}
		}

		return new Sprite();
	}

	public Sprite GetPortrait(CharacterData data)
	{
		return GetPortrait(data.Body, data.Color);
	}
}
