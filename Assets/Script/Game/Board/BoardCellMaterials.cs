using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardCellMaterials : ScriptableObject
{
	[MenuItem("Assets/Create/Scriptable Objects/BoardCellMaterials")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<BoardCellMaterials>();
	}
	
	public Material Idle;
	public Material Move1;
	public Material Move1Highlight;
	public Material Move2;
	public Material Move2Highlight;
}
