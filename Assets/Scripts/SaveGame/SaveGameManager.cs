using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour {
	private const float saveTimer = 5.0f;

	private static string saveFolder;
	private static string savePath;
	static SaveGameManager() {
		saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		saveFolder = Path.Combine(saveFolder, "My Games");
		saveFolder = Path.Combine(saveFolder, "Spell Harmony");

		savePath = Path.Combine(saveFolder, "save.gd");
	}

	private static SaveGameManager instance;
	public static SaveGameManager Instance {
		get {
			if (instance == null) {
				instance = new GameObject("SaveGameManager").AddComponent<SaveGameManager>();
				DontDestroyOnLoad(instance.gameObject);
			}
			return instance;
		}
	}
	public static string SaveFolder { get { return saveFolder; } }
	public static string SavePath { get { return savePath; } }

	private SaveGame saveGame;
	private float timer = 0.0f;

	void Awake() {
		if (!Directory.Exists(saveFolder))
			Directory.CreateDirectory(saveFolder);

		if (File.Exists(savePath)) {
			string text = File.ReadAllText(savePath);
			saveGame = JsonUtility.FromJson<SaveGame>(text);
		}
	}
	
	void Update() {
		timer += Time.deltaTime;

		if (timer >= saveTimer) {
			Save();
			timer = 0.0f;
		}
	}

	void Save() {
		if (saveGame == null) saveGame = new SaveGame();

		saveGame.questIdx = QuestManager.Instance.QuestIdx;
		if (SceneManager.GetActiveScene().name == "UPB") {
			saveGame.upbPlayerPos = Player.Instance.transform.position;
			saveGame.upbPlayerRot = Player.Instance.transform.rotation;
		}

		File.WriteAllText(savePath, JsonUtility.ToJson(saveGame, true));
	}

    private bool firstLoad = false;

	public void Load() {
		if (saveGame == null) return;

        if (firstLoad) return;

        firstLoad = true;

		QuestManager.Instance.Load(saveGame);
		if (SceneManager.GetActiveScene().name == "UPB") {
			Player.Instance.transform.position = saveGame.upbPlayerPos;
			Player.Instance.transform.rotation = saveGame.upbPlayerRot;
		}
	}
}
