using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour : StateMachineBase {
	private enum MonsterState { Idle, Engaging, Attacking, Dead };

	[SerializeField] private float engageRadius;
	[SerializeField] private float attackRange;

	[SerializeField] private float turnSpeed;
	[SerializeField] private float moveSpeed;

	[Header("Combat Stats")]
	[SerializeField] private float damage;
	
	private Animator animator;
	private CharacterController controller;
	private float gravity;

	void Start() {
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		SetState(MonsterState.Idle);
	}

	private void SetState(MonsterState state) {
		if (currentState == null || (MonsterState)currentState != state)
			stateMachineHandler.SetState(state, this);
	}

	private bool MoveTowards(Vector3 position) {
		Vector3 planarMoveTarget = position;
		Vector3 planarPosition = transform.position;
		planarMoveTarget.y = planarPosition.y = 0;

		Quaternion targetRotation = Quaternion.LookRotation(planarMoveTarget - planarPosition);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
		controller.Move(transform.forward * Time.deltaTime * moveSpeed);

		controller.Move(new Vector3(0, -1, 0));

		float distance = (planarMoveTarget - planarPosition).magnitude;
		return distance < 0.01f;
	}
}
