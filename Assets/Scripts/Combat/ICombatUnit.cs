public interface ICombatUnit {
	bool IsDead { get; }
	float Health { get; }
	float MaxHealth { get; }

	void ApplyDamage(float damage);
	void ApplyEffect(string effect);
}
