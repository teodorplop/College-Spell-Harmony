using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	void Idle_Update() {
		Transform playerTr = Player.Instance.transform;
		
		float distance = Vector3.Distance(transform.position, playerTr.position);
		if (distance < engageRadius)
			SetState(MonsterState.Engaging);
		else
			Roam();
	}

	private void Roam() {

	}
}
