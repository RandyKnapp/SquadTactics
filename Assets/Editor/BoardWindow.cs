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
	//private bool _cellPlacementModeActive;

	/*private void OnEnable()
	{
		SceneView.onSceneGUIDelegate += OnSceneGui;
	}

	private void OnSceneGui(SceneView sceneview)
	{
		Event e = Event.current;
		if (_cellPlacementModeActive && e.type == EventType.mouseDown && e.button == 0)
		{
			OnSceneClick(sceneview, e);
			//Debug.Log(e.ToString());
		}
	}*/

	private void OnGUI()
	{
		_board = (GameObject)EditorGUILayout.ObjectField("Board", _board, typeof(GameObject), true);
		_cellPrefab = (GameObject)EditorGUILayout.ObjectField("Cell Prefab", _cellPrefab, typeof(GameObject), true);

		//_cellPlacementModeActive = GUILayout.Toggle(_cellPlacementModeActive, "Cell Placement Mode" + (_cellPlacementModeActive ? " [ON]" : " [OFF]"), "Button");
		if (GUILayout.Button("Generate Cells"))
		{
			GenerateCells();
		}
	}

	/*private void OnSceneClick(SceneView sceneview, Event e)
	{
		Ray ray = HandleUtility.GUIPointToWorldRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 1 << LayerMask.NameToLayer("Default")))
		{
			Debug.Log(hit.transform.gameObject.name);
		}
		
		RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, LayerMask.NameToLayer("Default"));
		Debug.Log(hits.Length);
		foreach (RaycastHit hit in hits)
		{
			//if (hit.transform.gameObject.GetComponent<YuME_tileGizmo>())
			{
				Debug.Log("HIT " + hit.transform.position.x + "," + hit.transform.position.z);
			}
		}
	}*/

	private void GenerateCells()
	{
		foreach (Transform t in _board.transform)
		{
			GameObject gameObject = t.gameObject;
			if (gameObject.GetComponent<BoardCell>())
			{
				//Destroy(gameObject);
				Debug.Log("Destroyed a cell at (" + t.localPosition.x + ", " + t.localPosition.z + ")");
			}
		}
	}
}
