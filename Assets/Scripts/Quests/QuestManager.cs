using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager {
	private static QuestManager instance;
	public static QuestManager Instance {
		get {
			if (instance == null) instance = new QuestManager();
			return instance;
		}
	}

	[SerializeField] private int questIdx;
	private List<string> quests;

	public QuestManager() {
		quests = new List<string>() { "Find the great wizard" };
	}

	public string GetActiveQuest() {
		return quests[questIdx];
	}
}
