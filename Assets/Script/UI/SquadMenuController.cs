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
	private Text _tempDataDisplay;

	private CharacterData _data;

	private void Awake()
	{
		_editController.gameObject.SetActive(false);
		_editController.OnDataChanged += OnDataChanged;
		_editController.OnClose += OnEditAreaClosed;
		
		_editButton.onClick.AddListener(OnEditClick);

		OnDataChanged(_data);
	}

	private void OnDataChanged(CharacterData data)
	{
		_data = data;
		_tempDataDisplay.text = "Body: \n- " + _data.Body + "\nColor: \n- " + _data.Color + "\nWeapon: \n- " + _data.Weapon;
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
