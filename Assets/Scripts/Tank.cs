using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	protected float health;
//	protected ProjectileLauncher launcher;

	public virtual void Awake() {
//		launcher = GetComponentInParent<ProjectileLauncher> ();
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
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Projectile") {
			// Flash and rumble
		}
	}
}
