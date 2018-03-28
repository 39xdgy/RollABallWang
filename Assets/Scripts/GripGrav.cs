using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripGrav : MonoBehaviour {
    private bool grav = true;
    private Rigidbody gravity;
    private SteamVR_TrackedObject controller;


	// Use this for initialization
	void Awake () {
		this.controller = GetComponent<SteamVR_TrackedObject>();
        this.gravity = GameObject.Find("Ball").GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)controller.index);


        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if(grav)
            {
                gravity.useGravity = false;
                grav = false;
            }
            else
            {
                gravity.useGravity = true;
                grav = true;
            }
        }
	}
}
