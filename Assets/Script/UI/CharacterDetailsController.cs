using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDetailsController : MonoBehaviour
{
	[SerializeField]
	private Button _editButton;
	[SerializeField]
	private CharacterEditController _editController;
	[SerializeField]
	private Text _nameDisplay;
	[SerializeField]
	private Button _closeButton;
	[SerializeField]
	private SoldierPortrait _portrait; 

	private CharacterData _data;
	private SoldierController _soldier;
	
	[NonSerialized]
	public Action<CharacterData> OnClose = delegate {};

	private void Awake()
	{
		_editController.gameObject.SetActive(false);
		_editController.OnDataChanged += OnDataChanged;
		_editController.OnClose += OnEditAreaClosed;
		
		_editButton.onClick.AddListener(OnEditClick);
		_closeButton.onClick.AddListener(OnCloseButtonClick);

		OnDataChanged(_data);
	}

	private void OnCloseButtonClick()
	{
		OnClose(_data);
		DialogManager.PopDialog();
	}

	public void SetData(CharacterData data)
	{
		_data = data;
		OnDataChanged(_data);
	}

	private void OnDataChanged(CharacterData data)
	{
		_data = data;
		_nameDisplay.text = _data.FirstName + " " + _data.LastName;
		_portrait.SetData(_data);

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
