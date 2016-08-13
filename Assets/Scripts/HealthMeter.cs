using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour {

	public float maxHealth = 100.0f;
	private float health = 0f;

	private GameObject healthBar;

	void Awake() {
		healthBar = transform.FindChild ("Health").gameObject;

		if (!healthBar) {
			Debug.LogError("HealthMeter.Awake() " + name + " couldn't find a HealthBar.");
			enabled = false;
		}

		health = maxHealth;
	}
	
	void Update () {
	
	}

	public void setHealth(float health) {
		this.health = health;
		updateHealthBar ();
	}

	private void updateHealthBar() {
		healthBar.transform.localScale = new Vector3 (health / maxHealth, 1, 1);
	}
}
