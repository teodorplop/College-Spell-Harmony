using UnityEngine;

public class SpellCollision : MonoBehaviour {
    public SpellEffect explosion;
    public GameObject brokenCrate;
	public float damage;
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

        if (other.tag.Equals("Crate") && !tag.Equals("Spark"))
        {
            Destroy(other);
            Instantiate(brokenCrate, other.transform.position, other.transform.rotation);
            Destroy(transform.parent.gameObject);

        }
        else if (other.tag.Equals("Training"))
        {
            Instantiate(explosion, other.transform);
            Destroy(transform.parent.gameObject);
        }


        ICombatUnit combatUnit = other.GetComponent<ICombatUnit>();

		if (combatUnit == null || combatUnit == caster) return;

		if (caster.CanAttack(combatUnit) && !combatUnit.IsDead) {
			combatUnit.ApplyDamage(damage);
			combatUnit.ApplyEffect(explosion);
		}

        Destroy(transform.parent.gameObject); // not the best, but works for these effects
    }


}
