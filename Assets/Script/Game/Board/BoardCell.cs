using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
	[SerializeField]
	private BoardCellMaterials _materials;

	private bool _mouseOver = false;
	private bool _mouseDown = false;

	private void Awake()
	{
		Refresh();
	}

	private void OnMouseEnter()
	{
		_mouseOver = true;
		Refresh();
	}

	private void OnMouseExit()
	{
		_mouseOver = false;
		Refresh();
	}

	private void OnMouseDown()
	{
		_mouseDown = true;
		Refresh();
	}

	private void OnMouseUp()
	{
		_mouseDown = false;
		Refresh();
	}

	private void Refresh()
	{
		var mesh = GetComponent<MeshRenderer>();

		if (_mouseOver && _mouseDown)
		{
			mesh.material = _materials.Move1Highlight;
		}
		else if (_mouseOver && !_mouseDown)
		{
			mesh.material = _materials.Move1;
		}
		else
		{
			mesh.material = _materials.Idle;
		}
	}
}
