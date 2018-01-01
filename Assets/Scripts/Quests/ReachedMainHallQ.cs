using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedMainHallQ : MonoBehaviour {
	void Update() {
		float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
		if (dist <= 10) // ugly af
			QuestManager.Instance.ReachedMainHall();
	}
}
