using UnityEngine;
using System.Collections;

public class SeedPack : MonoBehaviour {

	public bool isHeld = false;

	private Vector3 screenPosition;
	private Vector3 movementOffset;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		isHeld = true;
		screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		movementOffset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
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
