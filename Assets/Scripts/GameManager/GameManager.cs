using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public partial class GameManager : StateMachineBase {
	private enum GameState {
		Default,
		ViveDefault,
		Defeated
	}

	[SerializeField] private bool vrEnabled;
	[SerializeField] private ViveController leftController;
	[SerializeField] private ViveController rightController;
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject vivePlayer;
	private UIManager uiManager;

	protected override void Awake() {
		base.Awake();
		ManageVR();
	}
	IEnumerator Start() {
		ManageSave();

		uiManager = FindObjectOfType<UIManager>();
		if (uiManager == null) {
			AsyncOperation loadUI = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
			while (!loadUI.isDone) yield return null;
			uiManager = FindObjectOfType<UIManager>();
		}

		SetState(vrEnabled ? GameState.ViveDefault : GameState.Default);
	}

	private void SetState(GameState state) {
		if (currentState == null || (GameState)currentState != state)
			stateMachineHandler.SetState(state, this);
	}
	
	private void ManageVR() {
		if (vrEnabled) {
			DestroyImmediate(player);
			vivePlayer.gameObject.SetActive(true);
			Strings.Initialize("Strings_VR");
		} else {
			DestroyImmediate(vivePlayer);
			player.gameObject.SetActive(true);
			Strings.Initialize("Strings_PC");
		}
	}

	private void ManageSave() {
		SaveGameManager.Instance.Load();
	}

	public void Defeated() {
		SetState(GameState.Defeated);
	}
}
