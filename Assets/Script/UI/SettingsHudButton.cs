using UnityEngine;
using UnityEngine.UI;

public class SettingsHudButton : MonoBehaviour
{
	[SerializeField]
	private GameObject _dialogPrefab;
	
	private void Start()
	{
		var button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		DialogManager.CreateDialog(_dialogPrefab);
	}
}
