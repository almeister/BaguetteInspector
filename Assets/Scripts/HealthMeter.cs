using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour {

	public float maxHealth = 100.0f;
	public float health = 0f;

	private GameObject healthBar;



	void Awake() {
		healthBar = transform.FindChild ("HealthBar/Health").gameObject;

		if (!healthBar) {
			Debug.LogError("HealthMeter.Awake() " + name + " couldn't find a HealthBar.");
			enabled = false;
		}

		health = maxHealth;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void decreaseHealth() {
		health -= 2;
		updateHealthBar ();
	}

	void updateHealthBar() {
		healthBar.transform.localScale = new Vector3 (health / maxHealth, 1, 1);
	}
}
