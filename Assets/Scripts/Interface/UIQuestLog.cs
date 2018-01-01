using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIQuestLog : MonoBehaviour {
	[SerializeField] private TextMeshProUGUI questLogLabel;

	void Update() {
		questLogLabel.text = "* " + QuestManager.Instance.GetActiveQuest();
	}
}
