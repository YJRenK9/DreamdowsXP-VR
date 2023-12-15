using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEntity : MonoBehaviour
{
    float yPos;  // need this to update y position
    bool hoverState;  // need this for the object to hover up and down
    
    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
        hoverState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 4.9 && transform.position.y <= 7 && !hoverState) 
        {
            yPos += 0.1f * Time.deltaTime;
            
            // need to use initial x and z positions, if use 0, then it'll look like it moved somewhere else
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        } 
        else 
        {
            hoverState = true;

            // update the y position
            yPos = transform.position.y;
        }

        if ((transform.position.y >= 5 && transform.position.y <= 7.1) && hoverState) 
        {
            yPos -= 0.1f * Time.deltaTime;

            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        else 
        {
            hoverState = false;

            // update the y position
            yPos = transform.position.y;
        }
        // if ((transform.position.y > 2 && transform.position.y < 4) && hoverState) {
        //     yPos = transform.position.y;
        //     yPos += 0.5f;
        //     transform.position = new Vector3(0, yPos, 0);
        // }
        // if (transform.position.y > 4) {
        //     yPos = transform.position.y;
        //     yPos -= 0.5f;
        //     transform.position = new Vector3(0, yPos, 0);
        //     hoverState = false;
        // }
        // if (transform.position.y < 2 && hoverState == false) {
        //     hoverState = true;
        //     yPos = transform.position.y;
        //     yPos += 0.5f;
        //     transform.position = new Vector3(0, yPos, 0);
        // }
    }
}
