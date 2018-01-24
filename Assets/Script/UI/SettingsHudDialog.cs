using UnityEngine;
using UnityEngine.UI;

public class SettingsHudDialog : MonoBehaviour
{
	[SerializeField]
	private Button _scrim;
	[SerializeField]
	private Button _closeButton;
	[SerializeField]
	private Button _quitButton;

	private void Awake()
	{
		_scrim.onClick.AddListener(OnCloseClick);
		_closeButton.onClick.AddListener(OnCloseClick);
		_quitButton.onClick.AddListener(OnQuitClick);
	}

	private void OnCloseClick()
	{
		DialogManager.PopDialog();
	}
	
	private void OnQuitClick()
	{
		var sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneTransitionManager>();
		sceneManager.ChangeScene("Menu");
	}
}
