﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    private SteamVR_TrackedObject trackedObj;
    
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;
    
    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
    private bool shouldTeleport;

    public Player vivePlayer;

    private GameObject gameObjectHit;
    private Portal[] portals;

    public SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start() {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;

        portals = FindObjectsOfType<Portal>();
    }

    private void ShowLaser(RaycastHit hit) {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance);
    }

    private void HideLaser() {
        laser.SetActive(false);
        reticle.SetActive(false);

        gameObjectHit = null;
    }

    private void Teleport() {
        shouldTeleport = false;
        reticle.SetActive(false);
        Vector3 difference = cameraRigTransform.position - headTransform.position;
        difference.y = 0;
        //cameraRigTransform.position = hitPoint + difference;
        vivePlayer.transform.position  = hitPoint + difference;
    }

    void Update() {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            RaycastHit hit;
            if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 100, teleportMask)) {
                hitPoint = hit.point;
                ShowLaser(hit);

                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;
                shouldTeleport = true;

                gameObjectHit = hit.collider.gameObject;
            } else {
                HideLaser();
            }
        } else {
            HideLaser();
        }

        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad) && shouldTeleport) {
            Teleport();
        }

        try
        {
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
            {
                AnimationHandlerScript scr = gameObjectHit.GetComponent<AnimationHandlerScript>();
                if (scr != null)
                    scr.Triggered();
            }
        }
        catch (System.Exception e)
        {
            Debug.Log("Oh well");
        }

        try
        {
            float dist;

            for (int i =0; i<portals.Length; i++)
            {
                dist = Vector3.Distance(portals[i].transform.position, Player.Instance.transform.position);

                if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger) && dist < 5)
                {
                    Portal portal = portals[i];
                    if (portal != null)
                        portal.OnInteract();
                }
            }


        }
        catch (System.Exception e)
        {
            Debug.Log("Oh well");
        }
    }
}
