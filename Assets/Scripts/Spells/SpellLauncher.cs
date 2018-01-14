using UnityEngine;

public class SpellLauncher : MonoBehaviour {
    public GameObject fireball;
    public GameObject shield;
    public GameObject electricSpark;
    public GameObject frostbolt;

    public float speed = 10.0f;

	public void Fireball(Transform model, ICombatUnit caster, Vector3 dir) {
		GameObject fire = Instantiate(fireball, model.position, model.rotation);
		fire.GetComponentInChildren<SpellCollision>().SetCaster(caster);
		fire.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
	}

	public void Shield(Transform model, ICombatUnit combatUnit) {
		if (combatUnit.ShieldStacks == 0) {
			GameObject defenseShield = Instantiate(shield, model.position, model.rotation);
			defenseShield.transform.parent = model;
			combatUnit.ApplyShield(defenseShield);
		}
	}

	public void LightingBolt(Transform model, ICombatUnit caster, Vector3 dir) {
		GameObject spark = Instantiate(electricSpark, model.position, model.rotation);
		spark.GetComponentInChildren<SpellCollision>().SetCaster(caster);
		spark.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
	}

	public void Frostbolt(Transform model, ICombatUnit caster, Vector3 dir) {
		GameObject ice = Instantiate(frostbolt, model.position, model.rotation);
		ice.GetComponentInChildren<SpellCollision>().SetCaster(caster);
		ice.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
	}
}
