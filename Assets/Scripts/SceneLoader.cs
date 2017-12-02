using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using System;

public class SceneLoader : MonoBehaviour {
	private static SceneLoader instance;
	private static bool inProgress;

	[SerializeField] private Image overlay;

	public static void Load(string name) {
		if (inProgress) return;
		
		instance.StartCoroutine(instance.LoadScene(name));
	}

	void Awake() {
		if (instance != null)
			Destroy(gameObject);
		else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	void OnDestroy() {
		if (instance == this)
			instance = null;
	}

	IEnumerator LoadScene(string name) {
		inProgress = true;

		overlay.DOFade(1.0f, 1.0f);
		yield return new WaitForSeconds(1.0f);

		AsyncOperation loading = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
		while (!loading.isDone) yield return null;

		overlay.DOFade(0.0f, 1.0f);
		yield return new WaitForSeconds(1.0f);

		inProgress = false;
	}
}
