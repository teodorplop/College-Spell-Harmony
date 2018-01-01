using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager {
	IEnumerator Defeated_EnterState() {
		uiManager.Defeated();
		yield return null;
	}
}
