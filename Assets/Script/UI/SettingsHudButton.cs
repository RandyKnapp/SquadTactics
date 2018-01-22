using UnityEngine;
using UnityEngine.UI;

public class SettingsHudButton : MonoBehaviour
{
	[SerializeField]
	private GameObject _dialogPrefab;
	[SerializeField]
	private Canvas _rootCanvas;
	
	private void Start()
	{
		var button = GetComponent<Button>();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		var dialog = Instantiate(_dialogPrefab);
		dialog.transform.SetParent(_rootCanvas.transform, false);
	}
}
