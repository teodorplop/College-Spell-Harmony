using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterBehaviour {
	private IEnumerator Dead_EnterState() {
		animator.SetTrigger("Dead");
		yield return null;
	}
}
