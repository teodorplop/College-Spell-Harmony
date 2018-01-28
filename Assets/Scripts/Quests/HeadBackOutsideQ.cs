using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBackOutsideQ : MonoBehaviour {
	void Update() {
		float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
		if (dist <= 5) {// ugly af... :O indeed
			QuestManager.Instance.HeadBackOutside();
		}
	}
}
