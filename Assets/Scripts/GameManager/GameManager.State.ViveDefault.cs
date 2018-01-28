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
        Vector3 dir = leftController.transform.forward;

        //fuck this shit, only way that worked...
        //up
        if (Input.GetAxis("TrackpadLHorizontal") > 0.9f && Input.GetAxis("TrackpadLVertical") < -0.9f && Input.GetButton("TrackpadLPress"))
            spellLauncher.Fireball(leftController.transform, player, dir);
        else
           //right
           if (Input.GetAxis("TrackpadLVertical") > 0.9f && Input.GetAxis("TrackpadLHorizontal") > 0.9f && Input.GetButton("TrackpadLPress"))
               spellLauncher.Frostbolt(leftController.transform, player, dir);
        else 
            //left
           if (Input.GetAxis("TrackpadLHorizontal") < -0.9f && Input.GetAxis("TrackpadLVertical") > 0.9f && Input.GetButton("TrackpadLPress"))
                spellLauncher.LightingBolt(leftController.transform, player, dir);
        else
            //grip
           if (Input.GetAxis("GripL") > 0.1f)
                spellLauncher.Shield(player.GetComponentsInChildren<Camera>()[0].transform, player);




    }

}
