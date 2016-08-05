using UnityEngine;
using System.Collections;

public class SeedsFactory : MonoBehaviour {

	public static Object prefab = Resources.Load ("Prefabs/Seeds");


	public static GameObject createSeeds (Vector3 position) {
		GameObject seeds = (GameObject)Instantiate(prefab) as GameObject;

		if (seeds) {
			seeds.transform.position = new Vector3 (position.x, position.y, position.z);
		}

		return seeds;
	}
}
