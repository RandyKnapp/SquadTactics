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

	private CharacterInstance _instance;
	private SoldierController _soldier;
	
	[NonSerialized]
	public Action<CharacterInstance> OnClose = delegate {};

	private void Awake()
	{
		_editController.gameObject.SetActive(false);
		_editController.OnDataChanged += OnDataChanged;
		_editController.OnClose += OnEditAreaClosed;
		
		_editButton.onClick.AddListener(OnEditClick);
		_closeButton.onClick.AddListener(OnCloseButtonClick);
	}

	private void OnCloseButtonClick()
	{
		OnClose(_instance);
		DialogManager.PopDialog();
	}

	public void SetCharacter(CharacterInstance instance)
	{
		_instance = instance;
		if (_instance != null)
		{
			OnDataChanged(_instance.Data);
		}
	}

	private void OnDataChanged(CharacterData data)
	{
		_nameDisplay.text = data.FirstName + " " + data.LastName;

		_portrait.SetData(data);

		if (_soldier == null)
		{
			GameObject soldierObject = GameObject.FindGameObjectWithTag("SoldierDummy");
			_soldier = soldierObject.GetComponent<SoldierController>();
		}
		
		_soldier.SetData(data);
	}

	private void OnEditAreaClosed(CharacterData data)
	{
		OnDataChanged(data);
		
		_editButton.gameObject.SetActive(true);
		_closeButton.gameObject.SetActive(true);
		_editController.gameObject.SetActive(false);
	}

	private void OnEditClick()
	{
		_editButton.gameObject.SetActive(false);
		_closeButton.gameObject.SetActive(false);
		
		_editController.Initialize(_instance);
		_editController.gameObject.SetActive(true);
	}
}
