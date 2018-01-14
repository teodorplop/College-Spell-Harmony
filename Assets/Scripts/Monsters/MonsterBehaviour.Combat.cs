using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	[SerializeField] private float maxHealth;
	private float health;
	private List<SpellEffect> activeEffects;

	public bool IsDead { get { return health <= 0.0f; } }
	public float Health { get { return health; } }
	public float MaxHealth { get { return maxHealth; } }
	public int ShieldStacks { get { return 0; } }

	public bool CanAttack(ICombatUnit other) {
		return other is Player;
	}

	public void ApplyDamage(float damage) {
		health = Mathf.Max(0.0f, health - damage);

		if (health == 0.0f)
			Die();
		else if (currentState != null && (MonsterState)currentState == MonsterState.Idle)
			SetState(MonsterState.Engaging);
	}

	public void ApplyShield(GameObject shieldObject) {
		// no shield for monsters, hehe
	}

	public void ApplySlow(float percentage) {
		animator.speed = slowPercentage = percentage;
	}

	public void ApplyEffect(SpellEffect effect) {
		SpellEffect active = GetActiveEffect(effect.EffectName);
		if (active == null) {
			active = Instantiate(effect, transform);
			active.SetTarget(this);
		}

		active.ResetDuration();
	}

	private SpellEffect GetActiveEffect(string effect) {
		return activeEffects.Find(obj => obj && obj.EffectName == effect);
	}

	private void Die() {
		SetState(MonsterState.Dead);
	}
}
