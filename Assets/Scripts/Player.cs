using System;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour, ICombatUnit {
	private static Player instance;
	public static Player Instance { get { return instance; } } // careful not to abuse of this public member

	private float health;
	[SerializeField] private float maxHealth;

	private int shield = 0;
	private GameObject shieldObject;

	private Dictionary<string, SpellEffect> activeEffects;

	void Awake() {
		activeEffects = new Dictionary<string, SpellEffect>();
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
	public bool IsDead { get { return health <= 0.0f; } }
    public int ShieldStacks {  get { return shield; } }

	public bool CanAttack(ICombatUnit other) {
		return other is MonsterBehaviour;
	}

	public void ApplyDamage(float damage) {
		if (shield == 0) {
			health = Mathf.Max(0.0f, health - damage);
			if (health == 0.0f) Die();
		} else {
			--shield;
			if (shield == 0 && shieldObject) {
				Destroy(shieldObject);
				shieldObject = null;
			}
		}
	}

	public void ApplyShield(GameObject shieldObject) {
		shield = 3;
		this.shieldObject = shieldObject;
	}

	public void ApplySlow(float percentage) {
		// no slow for player, for now!
	}

	public void ApplyEffect(SpellEffect effect) {
		SpellEffect active = GetActiveEffect(effect.EffectName);
		if (active == null)
			active = Instantiate(effect, Vector3.zero, Quaternion.identity, transform);

		active.ResetDuration();
	}

	private SpellEffect GetActiveEffect(string effect) {
		SpellEffect e;
		activeEffects.TryGetValue(effect, out e);
		return e;
	}

	private void Die() {
		// fuck me, this is not good.
		FindObjectOfType<GameManager>().Defeated();
	}
}
