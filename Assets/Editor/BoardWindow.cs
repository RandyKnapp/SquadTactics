using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoardWindow : EditorWindow
{
	[MenuItem("Tools/Board")]
	public static void ShowWindow()
	{
		GetWindow<BoardWindow>(false, "Board", true);
	}

	private GameObject _board;
	private GameObject _cellPrefab;

	private void OnGUI()
	{
		_board = (GameObject)EditorGUILayout.ObjectField("Board", _board, typeof(GameObject), true);
		_cellPrefab = (GameObject)EditorGUILayout.ObjectField("Cell Prefab", _cellPrefab, typeof(GameObject), true);

		if (GUILayout.Button("Generate Cells"))
		{
			GenerateCells();
		}
	}

	private void GenerateCells()
	{
		foreach (Transform t in _board.transform)
		{
			GameObject gameObject = t.gameObject;
			if (gameObject.GetComponent<BoardCell>())
			{
				//Destroy(gameObject);
				Debug.Log("Destroyed a cell at (" + t.localPosition.x + ", " +  t.localPosition.z + ")");
			}
		}
	}
}
