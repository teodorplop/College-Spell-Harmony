public interface ICombatUnit {
	float Health { get; }
	float MaxHealth { get; }

	void ApplyDamage(float damage);
	void ApplyEffect(string effect);
}
