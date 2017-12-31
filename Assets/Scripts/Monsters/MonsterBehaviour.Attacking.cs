using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	IEnumerator Attacking_EnterState() {
		animator.SetBool("Attacking", true);
		yield return null;
	}

	IEnumerator Attacking_ExitState() {
		animator.SetBool("Attacking", false);
		yield return null;
	}

	void Attacking_Update() {
		float distance = Vector3.Distance(transform.position, Player.Instance.transform.position);
		if (distance >= attackRange)
			SetState(MonsterState.Engaging);
			return;
	}

	protected virtual void OnAttack() {
		Player.Instance.ApplyDamage(damage);
	}
}
