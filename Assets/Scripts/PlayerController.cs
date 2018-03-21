using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text win;

    private Rigidbody rb;
    private int count;
    

	void Start() {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCOuntText();
        win.text = "";
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
        }

    }

    void SetCOuntText(){
        countText.text = "Count: " + count.ToString();
        if (count == 13)
        {
            win.text = "You Win";
        }
    }


}
