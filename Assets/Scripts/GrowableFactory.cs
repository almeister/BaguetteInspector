using UnityEngine;
using System.Collections;

public class GrowableFactory : MonoBehaviour {

	public static Object tomatoPrefab = Resources.Load ("Prefabs/GrowableTomato");


	public static GameObject createGrowable (GrowableType growableType, Transform seedTransform) {
		GameObject growable = null;

		switch (growableType) {
		case GrowableType.NONE:
			break;
		case GrowableType.TOMATO:
			growable = (GameObject)Instantiate(tomatoPrefab) as GameObject;
			break;
		}

		if (growable) {
			growable.transform.position = seedTransform.position;
			growable.transform.localRotation = seedTransform.localRotation;
			growable.transform.localScale = seedTransform.localScale;
		}

		return growable;
	}
}
