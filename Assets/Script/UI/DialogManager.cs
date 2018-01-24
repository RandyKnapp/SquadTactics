using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogManager
{
	private static readonly Stack<GameObject> _dialogStack = new Stack<GameObject>();
	
	private static Transform GetRootCanvas()
	{
		return GameObject.FindObjectOfType<Canvas>().rootCanvas.transform;
	}

	public static void CreateDialog(GameObject dialogPrefab)
	{
		PushDialog(GameObject.Instantiate(dialogPrefab));
	}

	public static void PushDialog(GameObject dialog)
	{
		_dialogStack.Push(dialog);
		dialog.transform.SetParent(GetRootCanvas(), false);
	}

	public static void PopDialog()
	{
		var dialog = _dialogStack.Pop();
		GameObject.Destroy(dialog);
	}
}
