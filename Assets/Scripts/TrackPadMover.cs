using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPadMover : MonoBehaviour
{
    public float speed;
    private Rigidbody ballRigidBody;
    SteamVR_TrackedObject controller;

    private void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigidBody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)controller.index);

        // if touching the touchpad, we'll move the ball
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            // store the tranform of the child of the this object?
            var model = this.transform.Find("Model");
            // location of trackPad in world space
            Transform trackPad = model.Find("trackpad").Find("attach");
            // location of where trackpad is being touched
            Transform touch = model.Find("trackpad_touch").Find("attach");

            // compute the difference in positions to
            Vector3 movement = (touch.position) - (trackPad.position);
            // modify the vector to ignore the y (up/down) axis
            movement = new Vector3(movement.x, 0, movement.z);
            // normalize vector to giveit a magnitude of 1
            // to control the velocity through the speed variable.
            movement.Normalize();

            // Add force to the ball
            this.ballRigidBody.AddForce(movement * speed);


        }
    }
}