using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyTerrain {
	public static float GetHeight(float x, float z) {
		Terrain terrain = Object.FindObjectOfType<Terrain>();
		return terrain == null ? 0 : terrain.SampleHeight(new Vector3(x, 0, z));
	}
}
