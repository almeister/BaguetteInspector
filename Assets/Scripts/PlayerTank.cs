using UnityEngine;
using System.Collections;

public class PlayerTank : Tank {

	private GameObject enemy;
    private float cannonAngle = 0;
    private float mortarAngle = 0;
    private float tubeAngle = 0;

    public override void Awake() {
		base.Awake ();

		enemy = GameObject.Find("/EnemyTank");
        if (!enemy)
        {
            Debug.LogError("PlayerTank.Awake() : " + name + " enemy tank not found.");
        }

        setupHealthMeter("/PlayerHealthBar");
        cannonAngle = Mathf.Abs(90 - cannon.transform.rotation.eulerAngles.z);
        mortarAngle = 80f;
        tubeAngle = 0f;
    }

	public override void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ProjectileLauncher.fireProjectile(cannon.transform, enemy.transform, cannonAngle, 50, 25);
            ProjectileLauncher.fireProjectile(mortar.transform, enemy.transform, mortarAngle, 50, 25);
            ProjectileLauncher.fireProjectile(tube.transform, enemy.transform, tubeAngle, 50, 25);
        }

        healthMeter.setHealth(health);
    }

	public override void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Growable") {
			ProjectileLauncher.fireProjectile (transform, enemy.transform, 45, 50, 50);
			Destroy (collider.gameObject);
		}
	}

	void OnTriggerExit(Collider collider) {
		//if (collider.tag == "Growable") {
		//	growable = null;
		//}
	}
}
