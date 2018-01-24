using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTileController : MonoBehaviour
{
	[SerializeField]
	private Text _nameDisplay;
	[SerializeField]
	private SoldierPortrait _portrait;
	[SerializeField]
	private Button _button;
	[SerializeField]
	private GameObject _dialogPrefab;

	private CharacterData _data;

	private void Awake()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		CharacterDetailsController dialog = Instantiate(_dialogPrefab).GetComponent<CharacterDetailsController>();
		dialog.SetData(_data);
		dialog.OnClose += SetData;
		
		DialogManager.PushDialog(dialog.gameObject);
	}

	public void SetData(CharacterData data)
	{
		_data = data;
		
		_nameDisplay.text = _data.FirstName + " " + _data.LastName;
		_portrait.SetData(_data);
	}
}
