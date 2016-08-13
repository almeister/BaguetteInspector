using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {

	protected float health;
    protected HealthMeter healthMeter;
    protected GameObject cannon;
    protected GameObject mortar;
    protected GameObject tube;

    public virtual void Awake() {
		health = 100.0f;

        cannon = transform.FindChild("Cannon").gameObject;
        mortar = transform.FindChild("Mortar").gameObject;
        tube = transform.FindChild("Tube").gameObject;
    }

	public virtual void Update () {
		
	}

	public void decrementHealth(float health) {
		this.health -= health;
	}

	public virtual void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Projectile") {
			// Flash and rumble
		}
	}

    protected void setupHealthMeter(string healthMeterName)
    {
        GameObject healthMeterGameObject = GameObject.Find(healthMeterName);
        if (!healthMeterGameObject)
        {
            Debug.LogError("Tank.Awake() : " + name + " HealthMeter not found.");
        }

        healthMeter = healthMeterGameObject.GetComponent<HealthMeter>();
    }
}
