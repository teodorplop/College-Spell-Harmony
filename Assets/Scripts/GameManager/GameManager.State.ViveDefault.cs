using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager {

    //ugly af, but used for testing for now
    public Transform cameraHeadTransform;

    IEnumerator ViveDefault_EnterState()
    {
        yield break;
    }

    void ViveDefault_Update()
    {
        CastSpellsVive();
    }

    void CastSpellsVive()
    {
        Player player = Player.Instance;
        //Vector3 dir = player.GetComponentsInChildren<Camera>()[0].transform.forward;
        Vector3 dir = leftController.transform.forward;

        if (Input.GetAxis("TrackpadLVertical") > 0.9f && Input.GetAxis("TrackpadLPress") != 0)
             spellLauncher.Fireball(cameraHeadTransform, player, dir);
        else if (Input.GetAxis("TrackpadLHorizontal") > 0.9f && Input.GetAxis("TrackpadLPress") != 0)
            spellLauncher.Frostbolt(player.transform, player, dir);
        else if (Input.GetAxis("TrackpadLHorizontal") < - 0.9f && Input.GetAxis("TrackpadLPress") != 0)
            spellLauncher.LightingBolt(player.transform, player, dir);
        else if (Input.GetAxis("GripL") > 0.1f)
            spellLauncher.Shield(cameraHeadTransform, player);

    }

}
