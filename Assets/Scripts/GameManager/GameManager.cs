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
	[SerializeField] private SpellLauncher spellLauncher;

	private UIManager uiManager;
    private Canvas canvas;

	protected override void Awake() {
		base.Awake();
		ManageVR();
	}
	IEnumerator Start() {
		ManageSave();

		uiManager = FindObjectOfType<UIManager>();
        canvas = FindObjectOfType<Canvas>();

		if (uiManager == null) {
			AsyncOperation loadUI = SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
			while (!loadUI.isDone) yield return null;
			uiManager = FindObjectOfType<UIManager>();
            canvas = FindObjectOfType<Canvas>();
        }

        //no time to implement it properly :(
    /*    if (vrEnabled)
        {
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.transform.position = new Vector3(vivePlayer.transform.position.x, vivePlayer.transform.position.y, vivePlayer.transform.position.z);
            RectTransform rt = canvas.GetComponentInChildren<RectTransform>();
            rt.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
        */

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
