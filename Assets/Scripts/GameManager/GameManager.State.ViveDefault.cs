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
        Vector3 dir = player.GetComponentsInChildren<Camera>()[0].transform.forward;
        float vect = Input.GetAxis("TrackpadRVertical");
        Debug.Log("Trackpad " + vect);

        if (Input.GetAxis("TrackpadRVertical") > 0.9f)
             spellLauncher.Fireball(cameraHeadTransform, player, dir);
        else if (Input.GetAxis("GripR") > 0.1f)
            spellLauncher.Shield(cameraHeadTransform, player);
      /*  else if (Input.GetKeyUp(KeyCode.Alpha3))
            spellLauncher.Frostbolt(player.transform, player, dir);
        else if (Input.GetKeyUp(KeyCode.Alpha4))
            spellLauncher.LightingBolt(player.transform, player, dir);*/
    }

}
