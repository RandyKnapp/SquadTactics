using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoldierPortrait : MonoBehaviour
{
	[SerializeField]
	private SoldierPortraitData _soldierPortraitData;
	
	public void SetData(CharacterData data)
	{
		var portrait = _soldierPortraitData.GetPortrait(data);
		GetComponent<Image>().overrideSprite = portrait;
	}
}
