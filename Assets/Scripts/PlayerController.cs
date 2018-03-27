using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text win;
    public AudioClip pickupClip;
    public AudioSource musicSource;
    public AudioClip winClip;
    public AudioSource musicSource2;

    private Rigidbody rb;
    private int count;
    private Rigidbody ballRigibBody;
    SteamVR_TrackedObject controller;

    private void Awake()
    {
        this.controller = GetComponent<SteamVR_TrackedObject>();
        this.ballRigibBody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    void Start() {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCOuntText();
        win.text = "";

        musicSource.clip = pickupClip;
        musicSource2.clip = winClip;
    }

	void FixedUpdate() {
        var device = SteamVR_Controller.Input((int)controller.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var model = this.transform.Find("Model");
            Transform trackpad = model.Find("trackpad").Find("attach");
            Transform touch = model.Find("trackpad_touch").Find("attach");
            Vector3 movement = (touch.position) - (trackpad.position);
            movement = new Vector3(movement.x, 0, movement.z);
            movement.Normalize();
            this.ballRigibBody.AddForce(movement * speed);
        }
	}

    void OnTriggerEnter(Collider other){
        //       Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count++;
            SetCOuntText();
            musicSource.Play();
        }

    }

    void SetCOuntText(){
        countText.text = "Count: " + count.ToString();
        if (count == 13)
        {
            win.text = "You Win";
            musicSource2.Play();
        }
    }


}
