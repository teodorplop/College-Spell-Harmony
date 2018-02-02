using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPoliFirst : MonoBehaviour {

    void Awake()
    {
        GetComponent<Portal>().OnInteractEvent += UsedWaterPortal_OnInteractEvent;
    }
    void OnDestroy()
    {
        GetComponent<Portal>().OnInteractEvent -= UsedWaterPortal_OnInteractEvent;
    }

    private void UsedWaterPortal_OnInteractEvent()
    {
        QuestManager.Instance.BackToPoliF();
    }
}
