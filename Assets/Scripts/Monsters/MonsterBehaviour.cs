using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour : StateMachineBase, ICombatUnit {
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
	private float slowPercentage = 1.0f;

	private float TurnSpeed { get { return turnSpeed * slowPercentage; } }
	private float MoveSpeed { get { return moveSpeed * slowPercentage; } }

	void Start() {
		health = maxHealth;
		activeEffects = new List<SpellEffect>();

		animator = transform.Find("Mesh").GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		SetState(MonsterState.Idle);
	}

	protected override void Update() {
		base.Update();
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
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * TurnSpeed);
		controller.Move(transform.forward * Time.deltaTime * MoveSpeed);

		controller.Move(new Vector3(0, -1, 0));

		float distance = (planarMoveTarget - planarPosition).magnitude;
		return distance < 0.01f;
	}

	public void OnAnimationEvent(string evt) {
		if (evt == "Attack") OnAttack();
	}
}
