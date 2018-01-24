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
	private GameObject _contentContainer;
	[SerializeField]
	private GameObject _navigationContainer;
	[SerializeField]
	private int _initialContent = 0;
	[SerializeField]
	private List<ContentNavigatorData> Data;

	private int _current;
	
	public void Start()
	{
		for (var index = 0; index < Data.Count; index++)
		{
			var entry = Data[index];
			var navButton = Instantiate(entry.NavigationPrefab);
			navButton.transform.SetParent(_navigationContainer.transform, false);

			var indexCopy = index;
			navButton.GetComponent<Button>().onClick.AddListener(() => OnNavButtonClicked(entry, indexCopy));
		}

		if (Data.Count > 0)
		{
			_current = _initialContent;
			RemoveContents();
			SetContents(Data[_initialContent]);
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
		content.transform.SetParent(_contentContainer.transform, false);
	}

	private void RemoveContents()
	{
		foreach (Transform child in _contentContainer.transform)
		{
			Destroy(child.gameObject);
		}
	}
}
