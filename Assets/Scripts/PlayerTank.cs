using UnityEngine;
using System.Collections;

public class PlayerTank : Tank {

	private GameObject enemy;

	public override void Awake() {
		base.Awake ();
		enemy = GameObject.Find("/EnemyTank/UpperTank");
	}

	// Update is called once per frame
	public override void Update () {
		if (Input.GetMouseButtonDown(0)) {
			ProjectileLauncher.fireProjectile (transform, enemy.transform, 45, 50, 25);
		}
	}
}
