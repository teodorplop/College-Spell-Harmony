using UnityEngine;

public class UIDefeated : MonoBehaviour {
	void Update() {
		if (Input.GetKeyUp(KeyCode.R))
			FindObjectOfType<UIManager>().Revive(); // ugly, but it gets the job done
	}
}
