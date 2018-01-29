using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKilledQ : MonoBehaviour {
	MonsterBehaviour[] monsters;
	bool triggeredQuest;

	void Awake() {
		monsters = GetComponentsInChildren<MonsterBehaviour>();
	}

	void Update() {
		foreach (MonsterBehaviour mb in monsters)
			if (!mb.IsDead) return;

		if (!triggeredQuest)
			QuestManager.Instance.MonstersKilled();
	}
}
