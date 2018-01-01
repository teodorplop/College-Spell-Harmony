using UnityEngine;
using UnityEditor;
using System.IO;

public static class SaveEditor {
	[MenuItem("Utility/Reset Save")]
	private static void ResetSaveFile() {
		if (File.Exists(SaveGameManager.SavePath))
			File.Delete(SaveGameManager.SavePath);
	}
}
