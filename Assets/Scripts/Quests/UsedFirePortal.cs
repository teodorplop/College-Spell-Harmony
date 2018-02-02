using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedFirePortal : MonoBehaviour {

    void Awake()
    {
        GetComponent<Portal>().OnInteractEvent += UsedFirePortal_OnInteractEvent;
    }
    void OnDestroy()
    {
        GetComponent<Portal>().OnInteractEvent -= UsedFirePortal_OnInteractEvent;
    }

    private void UsedFirePortal_OnInteractEvent()
    {
        QuestManager.Instance.FirePortal();
    }
}
