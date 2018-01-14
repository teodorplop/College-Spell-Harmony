using UnityEngine;

public class SpellEffect : MonoBehaviour {
	[SerializeField] private string effectName;
	[SerializeField] protected float effectDuration;

	protected ICombatUnit target;
	protected float timer;

	public string EffectName { get { return effectName; } }

	public void SetTarget(ICombatUnit unit) {
		target = unit;
		OnEffectStart();
	}

	public void ResetDuration() {
		timer = 0.0f;
	}

	protected virtual void Update() {
		timer += Time.deltaTime;
		if (timer >= effectDuration) {
			OnEffectEnd();
			Destroy(gameObject);
		}
	}

	protected virtual void OnEffectStart() { }
	protected virtual void OnEffectEnd() { }
}
