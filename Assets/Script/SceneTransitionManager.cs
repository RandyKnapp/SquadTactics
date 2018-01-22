using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
	[SerializeField]
	private GameObject _loadingScreenPrefab;
	[SerializeField]
	private Canvas _rootCanvas;

	private GameObject _loadingScreen;
	
	private void Awake ()
	{
		DontDestroyOnLoad(gameObject);

		var sceneManagers = GameObject.FindGameObjectsWithTag("SceneManager");
		if (sceneManagers.Length > 1)
		{
			Destroy(gameObject);
		}
	}

	public void ChangeScene(string scene)
	{
		_loadingScreen = Instantiate(_loadingScreenPrefab);
		_loadingScreen.transform.SetParent(_rootCanvas.transform, false);

		StartCoroutine(LoadSceneCoroutine(scene));
	}

	private IEnumerator LoadSceneCoroutine(string scene)
	{
		yield return new WaitForSeconds(0.5f);
		
		var loadSceneOp = SceneManager.LoadSceneAsync(scene);

		while (!loadSceneOp.isDone)
		{
			yield return null;
		}

		Destroy(_loadingScreen);
		_loadingScreen = null;
	}
}
