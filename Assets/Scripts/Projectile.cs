using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class Projectile : MonoBehaviour {

	public Transform start;
	public Transform target;
	public float firingAngle;
	public float gravity;
	public float damage;

	public Projectile(Transform start, Transform target, float firingAngle, float gravity, float damage) {
		this.target = target;
		this.start = start;
		this.firingAngle = firingAngle;
		this.gravity = gravity;
		this.damage = damage;
	}

	// Use this for initialization
	void Start () {
		// Explode
		StartCoroutine(fly());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator fly() {
		// Short delay added before Projectile is thrown
//		yield return new WaitForSeconds(1.5f);

		// Move projectile to the position of throwing object + add some offset if needed.
		transform.position = start.position + new Vector3(0, 0.0f, 0);

		// Calculate distance to target
		float target_Distance = Vector3.Distance(transform.position, target.position);

		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

		// Extract the X  Y componenent of the velocity
		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

		// Calculate flight time.
		float flightDuration = target_Distance / Vx;

		// Rotate projectile to face the target.
		transform.rotation = Quaternion.LookRotation(target.position - transform.position);

		float elapse_time = 0;

		while (elapse_time < flightDuration)
		{
			transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "EnemyTank" /* || collider.tag == "PlayerTank" */) {
			// Explode

			Tank tank = (Tank)collider.gameObject.GetComponentInParent<Tank> ();

			if (!tank) {
				Debug.LogError("Projectile.OnTriggerEnter() " + name + " couldn't find a Tank.");
				enabled = false;
			}

			tank.decrementHealth(damage);

			Destroy(gameObject);
		}
	}
}
