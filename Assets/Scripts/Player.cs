using System;
using UnityEngine;

public class Player : MonoBehaviour, ICombatUnit {
	private static Player instance;
	public static Player Instance { get { return instance; } }

	private float health;
	[SerializeField] private float maxHealth;

	void Awake() {
		health = maxHealth;
	}
	void Start() {
		instance = this;
	}
	void OnDestroy() {
		if (instance == this)
			instance = null;
	}

	public float Health { get { return health; } }
	public float MaxHealth { get { return maxHealth; } }

	public void ApplyDamage(float damage) {
		health = Mathf.Max(0.0f, health - damage);
		if (health == 0.0f)
			Die();
	}

	public void ApplyEffect(string effect) {
	}

	private void Die() {

	}
}
