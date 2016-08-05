using UnityEngine;
using System.Collections;

public class PlayerTank : Tank {

	private GameObject enemy;
	Growable growable = null;
	GameObject upperTank = null;


	public override void Awake() {
		base.Awake ();
		enemy = GameObject.Find("/EnemyTank/UpperTank");
		Transform upperTankTransform = transform.FindChild ("UpperTank");
		upperTank = upperTankTransform.gameObject;

		if (!enemy) {
			Debug.LogError ("PlayerTank.Awake() : " + name + " enemy tank not found.");
		}
		if (!upperTank) {
			Debug.LogError ("PlayerTank.Awake() : " + name + " UpperTank not found.");
		}
	}

	// Update is called once per frame
	public override void Update () {
//		if (growable) {
//			if (growable.isHeld == false && upperTank.GetComponent<Collider>().bounds.Contains(growable.transform.position)) {
//				Destroy (growable.gameObject);
//				growable = null;
//
//				ProjectileLauncher.fireProjectile (transform, enemy.transform, 45, 50, 25);
//			}
//		}
	}

	public override void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Growable") {
//			growable = collider.gameObject.GetComponent<Growable> ();
			ProjectileLauncher.fireProjectile (transform, enemy.transform, 45, 50, 25);
			Destroy (collider.gameObject);
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.tag == "Growable") {
			growable = null;
		}
	}
}
