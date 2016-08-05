using UnityEngine;
using System.Collections;

public class GardenManager : MonoBehaviour {

	public GameObject seedsGameObject = null;

	private const float timeToSprout = 2.5f;
	private float timeSinceLastGrowth;
	private bool isPlotFull = false;


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

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "SeedPack") {
			if (isPlotFull == false) {
//				Vector3 centreOfGarden = gameObject.GetComponentInParent<MeshFilter> ().mesh.bounds.center;
//				Vector3 positionForSeeds = new Vector3 (centreOfGarden.x, centreOfGarden.y, centreOfGarden.z - 1f);
				Vector3 positionForSeeds = new Vector3 (-57f, -2.5f, -5f);

				GameObject seeds = SeedsFactory.createSeeds (positionForSeeds);
				seeds.transform.parent = transform;
				seedsGameObject = seeds;

//				isPlotFull = true;
				Destroy (collider.gameObject);
			}
		}
	}
}
