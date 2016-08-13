using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyTank : Tank {

	public override void Awake() {
		base.Awake ();

        setupHealthMeter("/EnemyHealthBar");
	}

	public override void Update() {
		if (health <= 0) {
			SceneManager.LoadScene ("ResultsWinner");
		}

        healthMeter.setHealth(health);
    }
}
