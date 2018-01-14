using UnityEngine;

public interface ICombatUnit {
	bool IsDead { get; }

	float Health { get; }
	float MaxHealth { get; }

	bool CanAttack(ICombatUnit other);
	void ApplyDamage(float damage);
	
	void ApplyShield(GameObject shield);
	int ShieldStacks { get; }

	void ApplyEffect(SpellEffect effect);

	void ApplySlow(float percentage); // should refactor this whole code, damn it...
}
