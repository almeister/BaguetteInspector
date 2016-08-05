using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	protected float health;


	public virtual void Awake() {
		health = 100.0f;
	}

	// Use this for initialization
	public virtual void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

	public void decrementHealth(float health) {
		this.health -= health;
			
		HealthMeter healthMeter = (HealthMeter)GetComponent<HealthMeter> ();
		healthMeter.setHealth (health);
	}

	public virtual void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Projectile") {
			// Flash and rumble
		}
	}
}
