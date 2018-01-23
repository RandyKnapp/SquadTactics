using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
internal struct ContentNavigatorData
{
	public GameObject ContentPrefab;
	public GameObject NavigationPrefab;
}

public class ContentNavigator : MonoBehaviour
{
	[SerializeField]
	private GameObject ContentContainer;
	[SerializeField]
	private GameObject NavigationContainer;
	[SerializeField]
	private List<ContentNavigatorData> Data;

	private int _current;
	
	public void Start()
	{
		for (var index = 0; index < Data.Count; index++)
		{
			var entry = Data[index];
			var navButton = Instantiate(entry.NavigationPrefab);
			navButton.transform.SetParent(NavigationContainer.transform, false);

			navButton.GetComponent<Button>().onClick.AddListener(() => OnNavButtonClicked(entry, index));
		}

		if (Data.Count > 0)
		{
			_current = 0;
			SetContents(Data[0]);
		}
	}

	private void OnNavButtonClicked(ContentNavigatorData entry, int index)
	{
		if (index == _current)
		{
			return;
		}

		_current = index;
		RemoveContents();
		SetContents(entry);
	}

	private void SetContents(ContentNavigatorData entry)
	{
		if (entry.ContentPrefab == null)
		{
			return;
		}
		
		var content = Instantiate(entry.ContentPrefab);
		content.transform.SetParent(ContentContainer.transform, false);
	}

	private void RemoveContents()
	{
		foreach (Transform child in ContentContainer.transform)
		{
			Destroy(child.gameObject);
		}
	}
}
