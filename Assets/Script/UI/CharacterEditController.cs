using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

internal enum CharacterEditMode
{
	Body,
	Color,
	Weapon
}

public class CharacterEditController : MonoBehaviour
{
	[SerializeField]
	private Button _confirmButton;
	[SerializeField]
	private Button _cancelButton;
	[SerializeField]
	private Button _leftButton;
	[SerializeField]
	private Button _rightButton;
	[SerializeField]
	private Button _bodyInactiveTab;
	[SerializeField]
	private GameObject _bodyActiveTab;
	[SerializeField]
	private Button _colorInactiveTab;
	[SerializeField]
	private GameObject _colorActiveTab;
	[SerializeField]
	private Button _weaponInactiveTab;
	[SerializeField]
	private GameObject _weaponActiveTab;
	[SerializeField]
	private Text _dataLabel;
	[SerializeField]
	private InputField _nameInput;

	public event Action<CharacterData> OnDataChanged = delegate { };
	public event Action<CharacterData> OnClose = delegate { };

	private CharacterEditMode _mode = CharacterEditMode.Body;
	private CharacterData _currentData;
	private CharacterData _initialDataCopy;
	private CharacterInstance _characterInstance;

	private void Awake()
	{
		_confirmButton.onClick.AddListener(OnConfirmClick);
		_cancelButton.onClick.AddListener(OnCancelClick);
		_leftButton.onClick.AddListener(OnLeftClick);
		_rightButton.onClick.AddListener(OnRightClick);
		_bodyInactiveTab.onClick.AddListener(OnBodyTabClick);
		_colorInactiveTab.onClick.AddListener(OnColorTabClick);
		_weaponInactiveTab.onClick.AddListener(OnWeaponTabClick);
	}

	public void Initialize(CharacterInstance instance)
	{
		_characterInstance = instance;
		_initialDataCopy = _characterInstance.Data;
		_currentData = _characterInstance.Data;

		_nameInput.text = _currentData.FirstName + " " + _currentData.LastName;

		_mode = CharacterEditMode.Body;
		RefreshEditArea();
	}

	private void OnConfirmClick()
	{
		ConfirmName();
		_characterInstance.Data = _currentData;
		OnDataChanged(_characterInstance.Data);
		OnClose(_characterInstance.Data);
		GameDataManager.Save();
	}

	private void ConfirmName()
	{
		var fullName = _nameInput.text;
		if (fullName == "")
		{
			_currentData.FirstName = _currentData.LastName = "";
		}

		var nameParts = fullName.Split(' ');
		_currentData.FirstName = nameParts[0];
		string[] lastNameParts = nameParts.Skip(1).ToArray();
		_currentData.LastName = nameParts.Length > 1 ? string.Join(" ", lastNameParts) : "";
	}

	private void OnCancelClick()
	{
		_characterInstance.Data = _initialDataCopy;
		OnDataChanged(_characterInstance.Data);
		OnClose(_characterInstance.Data);
	}

	private void OnLeftClick()
	{
		switch (_mode)
		{
			case CharacterEditMode.Body:
			{
				int total = Enum.GetNames(typeof(BodyType)).Length;
				int currentValue = (int)_currentData.Body;
				if (currentValue == 0)
				{
					_currentData.Body = (BodyType)(total - 1);
				}
				else
				{
					_currentData.Body = _currentData.Body - 1;
				}

				break;
			}

			case CharacterEditMode.Color:
			{
				int total = Enum.GetNames(typeof(UniformColor)).Length;
				int currentValue = (int)_currentData.Color;
				if (currentValue == 0)
				{
					_currentData.Color = (UniformColor)(total - 1);
				}
				else
				{
					_currentData.Color = _currentData.Color - 1;
				}

				break;
			}

			case CharacterEditMode.Weapon:
			{
				int total = Enum.GetNames(typeof(Weapon)).Length;
				int currentValue = (int)_currentData.Weapon;
				if (currentValue == 0)
				{
					_currentData.Weapon = (Weapon)(total - 1);
				}
				else
				{
					_currentData.Weapon = _currentData.Weapon - 1;
				}

				break;
			}
		}

		OnDataChanged(_currentData);
		RefreshEditArea();
	}

	private void OnRightClick()
	{
		switch (_mode)
		{
			case CharacterEditMode.Body:
			{
				int total = Enum.GetNames(typeof(BodyType)).Length;
				_currentData.Body = (BodyType)(((int)_currentData.Body + 1) % total);
				break;
			}

			case CharacterEditMode.Color:
			{
				int total = Enum.GetNames(typeof(UniformColor)).Length;
				_currentData.Color = (UniformColor)(((int)_currentData.Color + 1) % total);
				break;
			}

			case CharacterEditMode.Weapon:
			{
				int total = Enum.GetNames(typeof(Weapon)).Length;
				_currentData.Weapon = (Weapon)(((int)_currentData.Weapon + 1) % total);
				break;
			}
		}

		OnDataChanged(_currentData);
		RefreshEditArea();
	}

	private void OnBodyTabClick()
	{
		_mode = CharacterEditMode.Body;
		RefreshEditArea();
	}

	private void OnColorTabClick()
	{
		_mode = CharacterEditMode.Color;
		RefreshEditArea();
	}

	private void OnWeaponTabClick()
	{
		_mode = CharacterEditMode.Weapon;
		RefreshEditArea();
	}

	private void RefreshEditArea()
	{
		switch (_mode)
		{
			case CharacterEditMode.Body:
				_dataLabel.text = _currentData.Body.ToString();
				break;

			case CharacterEditMode.Color:
				_dataLabel.text = _currentData.Color.ToString();
				break;

			case CharacterEditMode.Weapon:
				_dataLabel.text = _currentData.Weapon.ToString();
				break;
		}

		_bodyActiveTab.SetActive(_mode == CharacterEditMode.Body);
		_bodyInactiveTab.gameObject.SetActive(_mode != CharacterEditMode.Body);
		_colorActiveTab.SetActive(_mode == CharacterEditMode.Color);
		_colorInactiveTab.gameObject.SetActive(_mode != CharacterEditMode.Color);
		_weaponActiveTab.SetActive(_mode == CharacterEditMode.Weapon);
		_weaponInactiveTab.gameObject.SetActive(_mode != CharacterEditMode.Weapon);
	}
}
