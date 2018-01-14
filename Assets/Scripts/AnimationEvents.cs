using UnityEngine;
using UnityEngine.Events;
using System;

public class AnimationEvents : MonoBehaviour {
	[Serializable] private class StringEvent : UnityEvent<string> { }
	[SerializeField] private StringEvent onAnimationEvent;

	public void OnEvent(string evt) {
		onAnimationEvent.Invoke(evt);
	}
}
