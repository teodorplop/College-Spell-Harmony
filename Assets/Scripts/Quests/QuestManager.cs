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

	public int QuestIdx { get { return questIdx; } }

	[SerializeField] private int questIdx;
	private List<string> quests;

	public QuestManager() {
		quests = new List<string>() {
			"Head into the main hall \n Press 1-4 to test the spells.",
			"Enter the training room.",
			"Press T to reset training room. When ready, head back outside.",
			"Go find the ice portal and use it! Doh...",
			"Defeat monsters on the stairs down.",
			"Use the portal to get back into Poli.",
			"Great! Now have fun."
		};
	}

	public void ReachedMainHall() {
		// well, kind of ugly but fuck it.
		if (questIdx == 0) {
			EventManager.Raise(new QuestCompleted(0));
			++questIdx;
		}
	}
	public void EnterTrainingRoom() {
		if (questIdx == 1) {
			EventManager.Raise(new QuestCompleted(1));
			++questIdx;
		}
	}

	public void HeadBackOutside() {
		if (questIdx == 2) {
			EventManager.Raise(new QuestCompleted(2));
			++questIdx;
		}
	}

	public void IcePortal() {
		if (questIdx == 3) {
			EventManager.Raise(new QuestCompleted(3));
			++questIdx;
		}
	}

	public void MonstersKilled() {
		if (questIdx == 4) {
			EventManager.Raise(new QuestCompleted(4));
			++questIdx;
		}
	}

	public void BackToPoli() {
		if (questIdx == 5) {
			EventManager.Raise(new QuestCompleted(5));
			++questIdx;
		}
	}

	public string GetQuest(int id) {
		return quests[id];
	}

	public string GetActiveQuest() {
		return quests[questIdx];
	}

	public void Load(SaveGame save) {
		questIdx = save.questIdx;
	}
}
