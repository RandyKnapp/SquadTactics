using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadMenuController : MonoBehaviour
{
	[SerializeField]
	private Button _editButton;
	[SerializeField]
	private CharacterEditController _editController;
	[SerializeField]
	private Text _nameDisplay;

	private CharacterData _data;
	private SoldierController _soldier;

	private void Awake()
	{
		_data.FirstName = "Guy";
		_data.LastName = "McAwesome";
		
		_editController.gameObject.SetActive(false);
		_editController.OnDataChanged += OnDataChanged;
		_editController.OnClose += OnEditAreaClosed;
		
		_editButton.onClick.AddListener(OnEditClick);

		OnDataChanged(_data);
	}

	private void OnDataChanged(CharacterData data)
	{
		_data = data;
		_nameDisplay.text = _data.FirstName + " " + _data.LastName;

		if (_soldier == null)
		{
			GameObject soldierObject = GameObject.FindGameObjectWithTag("SoldierDummy");
			_soldier = soldierObject.GetComponent<SoldierController>();
		}
		
		_soldier.SetData(_data);
	}

	private void OnEditAreaClosed(CharacterData data)
	{
		OnDataChanged(data);
		
		_editButton.gameObject.SetActive(true);
		_editController.gameObject.SetActive(false);
	}

	private void OnEditClick()
	{
		_editButton.gameObject.SetActive(false);
		
		_editController.Initialize(_data);
		_editController.gameObject.SetActive(true);
	}
}
