using UnityEngine;
using System.Collections;

public class Grower : MonoBehaviour {

	public GameObject seedsGameObject = null;

	private const float timeToSprout = 0.5f;
	private float timeSinceLastGrowth;


	void Awake()
	{
		timeSinceLastGrowth = 0.0f;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Transform seedsTransform = transform.FindChild ("Seeds");

		if (seedsTransform)
			seedsGameObject = (GameObject)seedsTransform.gameObject;

		if (seedsGameObject) {
			timeSinceLastGrowth += Time.deltaTime;

			if (timeSinceLastGrowth >= timeToSprout) {
				sproutSeeds ();
				timeSinceLastGrowth = 0f;
			}
		}
	}

	private void sproutSeeds()
	{
		Seed[] seedlings = GetComponentsInChildren<Seed> ();

		foreach (Seed seedling in seedlings) {
			if (seedling.growableType != GrowableType.NONE) {
				GrowableFactory.createGrowable (seedling.growableType, seedling.transform);

				Destroy (seedling.gameObject);
			}
		}

		Destroy(seedsGameObject);
	}
}
