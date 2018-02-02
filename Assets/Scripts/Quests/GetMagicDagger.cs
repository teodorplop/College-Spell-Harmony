using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMagicDagger : MonoBehaviour {
    void Update()
    {
        float dist = Vector3.Distance(transform.position, Player.Instance.transform.position);
        if (dist <= 1)
        {
            Destroy(this);
            QuestManager.Instance.MagicDagger();
        }
    }
}
