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
    

	void Start() {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCOuntText();
        win.text = "";

        musicSource.clip = pickupClip;
        musicSource2.clip = winClip;
    }

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
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
