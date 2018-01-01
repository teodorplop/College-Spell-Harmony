using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	private float idleTimer;

	IEnumerator Idle_EnterState() {
		idleTimer = 0.5f;
		yield return null;
	}

	void Idle_Update() {
		idleTimer = Mathf.Max(0.0f, idleTimer - Time.deltaTime);
		if (idleTimer > 0.0f) return;
		if (Player.Instance.IsDead) return;

		Transform playerTr = Player.Instance.transform;
		
		float distance = Vector3.Distance(transform.position, playerTr.position);
		if (distance < engageRadius)
			SetState(MonsterState.Engaging);
	}
}
