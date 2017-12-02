using System;
using System.Collections.Generic;
using UnityEngine;

public class ViveController : MonoBehaviour {
	private SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}
}
