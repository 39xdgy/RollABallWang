using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour {

    private Transform ballTransform;
    private Rigidbody ballRigidbody;
    public Camera cameraHead;
    private Transform cameraHeadTransform;
    private SteamVR_TrackedObject controller;

    void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballTransform = GameObject.Find("Ball").GetComponent<Transform>();
        this.ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
        this.cameraHeadTransform = cameraHead.GetComponent<Transform>();
    }
    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)controller.index);

        if ((!device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) && device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            ballTransform.position = new Vector3(cameraHeadTransform.position.x, 1, cameraHeadTransform.position.z);
            ballRigidbody.velocity = new Vector3(0, 0, 0);
            ballRigidbody.angularVelocity = new Vector3(0,0,0);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
