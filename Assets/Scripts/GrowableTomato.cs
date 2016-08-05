using UnityEngine;
using System.Collections;

public class GrowableTomato : Growable {

	public override void Awake() {
		maxGrowthTimeSeconds = 1.5f;
		minGrowthTimeSeconds = 1f;
		growthPhases = 4;
	}

//	// Use this for initialization
//	public override void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	public override void Update () {
//	
//	}
}
