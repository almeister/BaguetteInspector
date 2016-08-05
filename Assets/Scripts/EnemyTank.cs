using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyTank : Tank {

//	private GameObject player;

	public override void Awake() {
		base.Awake ();
//		player = GameObject.Find("/PlayerTank/UpperTank");
	}

	public override void Update() {
		if (health <= 0) {
			SceneManager.LoadScene ("ResultsWinner");
		}

//		if (Input.GetMouseButtonDown(0)) {
//			ProjectileLauncher.fireProjectile (transform, player.transform, 45, 50, 25);
//		}
	}
}
