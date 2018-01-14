using UnityEngine;

public class SpellCollision : MonoBehaviour {
    public SpellEffect explosion;
	[SerializeField] private float aliveTime = 10.0f;

	private ICombatUnit caster;
	private float timer;

	void Update () {
		timer += Time.deltaTime;
		if (timer >= aliveTime)
			Destroy(transform.parent.gameObject); // not the best, but works for these effects
	}

	public void SetCaster(ICombatUnit caster) {
		this.caster = caster;
	}

    public void OnParticleCollision(GameObject other) {
		ICombatUnit combatUnit = other.GetComponent<ICombatUnit>();
		if (combatUnit == null || combatUnit == caster) return;

		if (caster.CanAttack(combatUnit))
			combatUnit.ApplyEffect(explosion);
		
		Destroy(transform.parent.gameObject); // not the best, but works for these effects
	}
}
