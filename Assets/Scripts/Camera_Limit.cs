using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Limit : MonoBehaviour
{
    public float panSpeed = 20f ;
    public Joystick Joystick;
    public float  horizentalMove=0;
    public float  verticalMove=0;
    public bool StartTouch;
    public GameObject map;
    private int mapx;
    private int mapy;
    public bool _zoom;
    [HideInInspector]
    public Vector3 lastPosition = Vector3.zero;
    public void Start()
    {
        Joystick.OnDragStart.AddListener(JoyStickDrag);
        mapx = (int) map.GetComponent<SpriteRenderer>().size.x;
        mapy = (int) map.GetComponent<SpriteRenderer>().size.y;

    }

    private void Update()
    {


//       // if (_zoom)
//        {
//            transform.position = zoom.transform.localPosition;
//        }
//        else
//        {
//            
//        }
        
//        
//        horizentalMove = Input.acceleration.x;
//        verticalMove = Input.acceleration.y;                        
//        Vector3 movement = new Vector3 (horizentalMove, 0.0f, verticalMove);
//        rb.AddForce (movement * panSpeed * 2);
        
        
        
        
        
        if (StartTouch != true) return;
        MoveCamera();
        LimitedCameraPosition();

    }
    


    void JoyStickDrag()
    {

        

        StartTouch = true;
        Debug.Log("2");

    }

    private void LimitedCameraPosition()
    {
       
        var viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x,  -mapx  , mapx  );
        viewpos.y = Mathf.Clamp(viewpos.y, -mapy , mapy ) ;
        transform.position = viewpos;
    }

    private void MoveCamera()
    {
        if (lastPosition != Vector3.zero)
        {
            transform.position = lastPosition;
            lastPosition = Vector3.zero;
        }
        
        horizentalMove = Joystick.Horizontal * panSpeed;
        verticalMove = Joystick.Vertical * panSpeed;
        transform.position += new Vector3(horizentalMove*Time.deltaTime,verticalMove*Time.deltaTime,0);
    }
}
