using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]


public class Growable : MonoBehaviour {

	public bool isHeld = false;

	protected float maxGrowthTimeSeconds = 5f;
	protected float minGrowthTimeSeconds = 5f;
	protected int growthPhases = 4;
	protected float growingTime = 0f;
	protected int currentGrowthPhase = 1;
	protected bool isReady = false;

	private Vector3 screenPosition;
	private Vector3 movementOffset;


	public virtual void Awake() {
		
	}

	// Use this for initialization
	public virtual void Start () {
	
	}

	// Update is called once per frame
	public virtual void Update () {
		growingTime += Time.deltaTime;

		if (isReady == false) {
			if (growingTime >= maxGrowthTimeSeconds) {
				transform.localScale += new Vector3 (0.3f, 0.3f, 0.3f);
				currentGrowthPhase += 1;
				growingTime = 0f;
			}

			if (currentGrowthPhase >= growthPhases)
				isReady = true;
		}
	}

	void OnMouseDown()
	{
		if (isReady) {
			isHeld = true;
			screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			movementOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
		}
	}

	void OnMouseDrag()
	{
		if (isHeld) {
			Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentScreenPosition) + movementOffset;

			transform.position = worldPosition;
		}
	}

	void OnMouseUp() {
		isHeld = false;
	}
}
