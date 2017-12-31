using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	IEnumerator Engaging_EnterState() {
		animator.SetBool("Walking", true);
		yield return null;
	}

	IEnumerator Engaging_ExitState() {
		animator.SetBool("Walking", false);	
		yield return null;
	}

	void Engaging_Update() {
		Transform playerTr = Player.Instance.transform;

		float distance = Vector3.Distance(transform.position, playerTr.position);
		if (distance < attackRange)
			SetState(MonsterState.Attacking);
		else
			MoveTowards(playerTr.position);
	}
}
