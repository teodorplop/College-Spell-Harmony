using UnityEngine;
using System.Collections;

public class AnimationHandlerScript : MonoBehaviour {
	
	private Animator DoorAnimator = null;
	private bool ButtonPressed = false;

    void Start () 
	{
        DoorAnimator = GetComponent<Animator>();
		DoorAnimator.SetBool("isOpen", false);
		ButtonPressed = false;
	}
	
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			ButtonPressed = true;
		}
		
	}
	
	void OnTriggerEnter(Collider collider)
    {
        ButtonPressed = false;
				
    }
	

    void OnTriggerStay(Collider collider)
    {
        if (ButtonPressed && !DoorAnimator.GetBool("isOpen"))
		{
			DoorAnimator.SetBool("isOpen", true);
			ButtonPressed = false;
        }
		
		if (ButtonPressed && DoorAnimator.GetBool("isOpen"))
		{
			DoorAnimator.SetBool("isOpen", false);
			ButtonPressed = false;
        }
		
				
    }

    void OnTriggerExit(Collider collider)
    {
		//closing automatically the door 
		//DoorAnimator.SetBool("isOpen", false);
		//ButtonPressed = false;
    }
}﻿

