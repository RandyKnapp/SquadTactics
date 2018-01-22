using UnityEngine;
using UnityEngine.UI;

public class MissionStartButton : MonoBehaviour
{
	private void Start()
	{
		var button = GetComponent<Button>();
		button.onClick.AddListener(onClick);
	}

	private void onClick()
	{
		var sceneManagerObject = GameObject.FindGameObjectWithTag("SceneManager");
		var sceneManager = sceneManagerObject.GetComponent<SceneTransitionManager>();
		
		sceneManager.ChangeScene("Mission");
	}
}
