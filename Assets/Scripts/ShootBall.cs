using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    private Transform ballTransform;
    private Rigidbody ballRigidbody;
    private SteamVR_TrackedObject controller;

    void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballTransform = GameObject.Find("Ball").GetComponent<Transform>();
        this.ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
       
    }
    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)controller.index);
        // if the trigger and the touch pad are pressed then shoot (holding the ball)
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {

        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
