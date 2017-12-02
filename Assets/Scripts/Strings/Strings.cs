using System.Collections;
using UnityEngine;

public class Strings {
    public static void Initialize(string file) {
        instance = new Strings(file);
    }

    private static Strings instance;
    private static Strings Instance {
        get { return instance ?? (instance = new Strings("Strings_PC")); }
    }

    private Hashtable idToText;
    private Strings(string file) {
        TextAsset stringsAsset = Resources.Load<TextAsset>(file);
        if (stringsAsset == null) {
            Debug.LogError("Strings: " + file + " not found.");
            return;
        }

        idToText = JSON.JsonDecode(stringsAsset.text) as Hashtable;
        Resources.UnloadAsset(stringsAsset);
    }

    public static string GetText(string id) {
        object obj = Instance.idToText[id];
        return obj == null ? id : obj as string;
    }
}
