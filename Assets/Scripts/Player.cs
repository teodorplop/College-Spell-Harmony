using System;
using UnityEngine;

public class Player : MonoBehaviour, ICombatUnit {
	private static Player instance;
	public static Player Instance { get { return instance; } }

	private float health;
    private int shield = 0;
	[SerializeField] private float maxHealth;

	void Awake() {
		health = maxHealth;
	}
	void Start() {
		instance = this;
	}
	void OnDestroy() {
		if (instance == this)
			instance = null;
	}

	public float Health { get { return health; } }
	public float MaxHealth { get { return maxHealth; } }
	public bool IsDead { get { return health <= 0.0f; } }
    public int ShieldStatus {  get { return shield; } }

	public void ApplyDamage(float damage) {
        if (shield == 0)
            health = Mathf.Max(0.0f, health - damage);
        else
            shield -= 1;

		if (health == 0.0f)
			Die();
	}

	public void ApplyEffect(string effect) {
	}

    public void ApplyShield(int level){
        //ugly, probably we won't have levels anyway
        shield = 3 * level;
    }

	private void Die() {
		// fuck me, this is not good.
		FindObjectOfType<GameManager>().Defeated();
	}
}
