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

	private CharacterInstance _instance;

	private void Awake()
	{
		_button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		CharacterDetailsController dialog = Instantiate(_dialogPrefab).GetComponent<CharacterDetailsController>();
		dialog.SetCharacter(_instance);
		dialog.OnClose += SetCharacter;
		
		DialogManager.PushDialog(dialog.gameObject);
	}

	public void SetCharacter(CharacterInstance instance)
	{
		_instance = instance;

		if (_instance != null)
		{
			_nameDisplay.text = _instance.GetName();
			_portrait.SetData(_instance.Data);
		}
	}
}
