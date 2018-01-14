using UnityEngine;

public class SlowEffect : SpellEffect {
	[SerializeField] private float slowPercentage = .6f;

	protected override void OnEffectStart() {
		if (target != null)
			target.ApplySlow(slowPercentage);
	}
	protected override void OnEffectEnd() {
		if (target != null)
			target.ApplySlow(1.0f);
	}
}
