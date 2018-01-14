using UnityEngine;

public class DOTEffect : SpellEffect {
	[SerializeField] private int ticks = 1;
	[SerializeField] private float damagePerTick = 2;

	private float tickTimer, tickDuration;

	protected override void OnEffectStart() {
		tickDuration = effectDuration / ticks;
	}

	protected override void Update() {
		base.Update();
		if (target == null) return;

		tickTimer += Time.deltaTime;
		while (tickTimer >= tickDuration) {
			tickTimer -= tickDuration;
			target.ApplyDamage(damagePerTick);
		}
	}
}
