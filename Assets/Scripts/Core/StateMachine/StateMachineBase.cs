using System;
using UnityEngine;
using System.Reflection;

/// <summary>
/// Inherit this to have a state machine like behaviour.
/// </summary>
public abstract class StateMachineBase : MonoBehaviour {
	protected StateMachineHandler stateMachineHandler;
	protected virtual void Awake() {
		stateMachineHandler = gameObject.AddComponent<StateMachineHandler>();
	}
	
	private Enum _currentState;
	public Enum currentState {
		get { return _currentState; }
		set {
			_currentState = value;
			if (_currentState == null) {
				ConfigureEmptyState();
			} else {
				ConfigureCurrentState();
			}
		}
	}

	#region actions
	private static void DoNothing() {}
	private static void DoNothing(Vector3 mi) {}
	private static void DoNothingCollider(Collider other) {}
	private static void DoNothingCollision(Collision other) {}

	private Action DoUpdate = DoNothing;
	private Action DoLateUpdate = DoNothing;
	private Action DoFixedUpdate = DoNothing;
	/*private Action<Collider> DoOnTriggerEnter = DoNothingCollider;
	private Action<Collider> DoOnTriggerStay = DoNothingCollider;
	private Action<Collider> DoOnTriggerExit = DoNothingCollider;
	private Action<Collision> DoOnCollisionEnter = DoNothingCollision;
	private Action<Collision> DoOnCollisionStay = DoNothingCollision;
	private Action<Collision> DoOnCollisionExit = DoNothingCollision;
	private Action DoOnMouseEnter = DoNothing;
	private Action DoOnMouseUp = DoNothing;
	private Action DoOnMouseDown = DoNothing;
	private Action DoOnMouseOver = DoNothing;
	private Action DoOnMouseExit = DoNothing;
	private Action DoOnMouseDrag = DoNothing;
	private Action DoOnDrawGizmos = DoNothing;*/
	#endregion

	#region configuration
	private void ConfigureEmptyState() {
		DoUpdate = DoNothing;
		DoLateUpdate = DoNothing;
		DoFixedUpdate = DoNothing;
		/*DoOnTriggerEnter = DoNothingCollider;
		DoOnTriggerStay = DoNothingCollider;
		DoOnTriggerExit = DoNothingCollider;
		DoOnCollisionEnter = DoNothingCollision;
		DoOnCollisionStay = DoNothingCollision;
		DoOnCollisionExit = DoNothingCollision;
		DoOnMouseEnter = DoNothing;
		DoOnMouseUp = DoNothing;
		DoOnMouseDown = DoNothing;
		DoOnMouseOver = DoNothing;
		DoOnMouseDrag = DoNothing;
		DoOnMouseExit = DoNothing;
		DoOnDrawGizmos = DoNothing;*/

		useGUILayout = false;
	}
	private void ConfigureCurrentState() {
		DoUpdate = ConfigureDelegate<Action>(_currentState, "Update", DoNothing);
		DoLateUpdate = ConfigureDelegate<Action>(_currentState, "LateUpdate", DoNothing);
		DoFixedUpdate = ConfigureDelegate<Action>(_currentState, "FixedUpdate", DoNothing);
		/*DoOnTriggerEnter = ConfigureDelegate<Action<Collider>>(_currentState, "OnTriggerEnter", DoNothingCollider);
		DoOnTriggerStay = ConfigureDelegate<Action<Collider>>(_currentState, "OnTriggerStay", DoNothingCollider);
		DoOnTriggerExit = ConfigureDelegate<Action<Collider>>(_currentState, "OnTriggerExit", DoNothingCollider);
		DoOnCollisionEnter = ConfigureDelegate<Action<Collision>>(_currentState, "OnCollisionEnter", DoNothingCollision);
		DoOnCollisionStay = ConfigureDelegate<Action<Collision>>(_currentState, "OnCollisionStay", DoNothingCollision);
		DoOnCollisionExit = ConfigureDelegate<Action<Collision>>(_currentState, "OnCollisionExit", DoNothingCollision);
		DoOnMouseEnter = ConfigureDelegate<Action>(_currentState, "OnMouseEnter", DoNothing);
		DoOnMouseUp = ConfigureDelegate<Action>(_currentState, "OnMouseUp", DoNothing);
		DoOnMouseDown = ConfigureDelegate<Action>(_currentState, "OnMouseDown", DoNothing);
		DoOnMouseOver = ConfigureDelegate<Action>(_currentState, "OnMouseOver", DoNothing);
		DoOnMouseDrag = ConfigureDelegate<Action>(_currentState, "OnMouseDrag", DoNothing);
		DoOnMouseExit = ConfigureDelegate<Action>(_currentState, "OnMouseExit", DoNothing);
		DoOnDrawGizmos = ConfigureDelegate<Action>(_currentState, "OnDrawGizmos", DoNothing);*/

	    useGUILayout = false;
	}
	
	public T ConfigureField<T>(Enum state, string fieldRoot, T Default) {
		FieldInfo field = GetType().GetField(state.ToString() + "_" + fieldRoot, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		if (field != null) {
			return (T)field.GetValue(this);
		}
		return Default;
	}

	public T ConfigureDelegate<T>(Enum state, string methodRoot, T Default) where T : class {
		MethodInfo method = GetType().GetMethod(state.ToString() + "_" + methodRoot, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod);

		if (method != null) {
			return Delegate.CreateDelegate(typeof(T), this, method) as T;
		}

		return Default;
	}
	#endregion

	#region functions
	protected virtual void Update() {
		DoUpdate();
	}
	protected virtual void LateUpdate() {
		DoLateUpdate();
	}
	protected virtual void FixedUpdate() {
		DoFixedUpdate();
	}
	/*void OnTriggerEnter(Collider other) {
		DoOnTriggerEnter(other);
	}
	void OnTriggerStay(Collider other) {
		DoOnTriggerStay(other);
	}
	void OnTriggerExit(Collider other) {
		DoOnTriggerExit(other);
	}
	void OnCollisionEnter(Collision other) {
		DoOnCollisionEnter(other);
	}
	void OnCollisionStay(Collision other) {
		DoOnCollisionStay(other);
	}
	void OnCollisionExit(Collision other) {
		DoOnCollisionExit(other);
	}
	void OnMouseEnter() {
		DoOnMouseEnter();
	}
	void OnMouseUp() {
		DoOnMouseUp();
	}
	void OnMouseDown() {
		DoOnMouseDown();
	}
	void OnMouseOver() {
		DoOnMouseOver();
	}
	void OnMouseDrag() {
		DoOnMouseDrag();
	}
	void OnMouseExit() {
		DoOnMouseExit();
	}
	void OnDrawGizmos() {
		DoOnDrawGizmos();
	}*/
	#endregion
}
