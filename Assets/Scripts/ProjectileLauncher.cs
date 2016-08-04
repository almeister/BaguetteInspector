using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour
{
	public static Object projectilePrefab = Resources.Load ("Prefabs/Projectile");

	void Awake()
	{
	}

	void Start()
	{   
	}

	// Update is called once per frame
	void Update () {
	}

	public static Projectile fireProjectile(Transform start, Transform target, float firingAngle, float gravity, float damage) {
		GameObject projectileGameObject = (GameObject)Instantiate(projectilePrefab) as GameObject;
		Projectile projectile = projectileGameObject.GetComponent<Projectile> ();
		projectile.start = start;
		projectile.target = target;
		projectile.firingAngle = firingAngle;
		projectile.gravity = gravity;
		projectile.damage = damage;

		return projectile;
	}
}