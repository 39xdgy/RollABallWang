using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPacer : MonoBehaviour {
    public float speed = 5.0f;
    private float xMax = 9f;
    private float xMin = -9f;
    private int direction = 1;


    private void Update(){
        float xNew = transform.position.x + direction * speed * Time.deltaTime;


        if(xNew >= xMax)
        {
            xNew = xMax;
            direction *= -1;
        }
        else if(xNew <= xMin)
        {
            xNew = xMin;
            direction *= -1;
        }

        transform.position = new Vector3(xNew, transform.position.y, transform.position.z);

    }
}
