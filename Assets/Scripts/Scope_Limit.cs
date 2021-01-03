using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope_Limit : MonoBehaviour
{
    public float panSpeed = 200000f ;
    public Joystick Joystick;
    public float  horizentalMove=0;
    public float  verticalMove=0;
    public SpriteRenderer spriterender;
    public bool starttouch;
    public GameObject zoom;
    public Camera camera;
    private int mapx;
    private int mapy;
    private Vector2 cameraScreenPosition;
    public GameObject playersprite;
    public SpriteRenderer playerssprite;
    private Camera_Limit cameraLimit;
    private void Start()
    {
        cameraLimit = camera.GetComponent<Camera_Limit>();
        Joystick.OnDragStart.AddListener(JoyStickDragStart);
        Joystick.OnDragEnd.AddListener(JoyStickDragEnd);
        playersprite.GetComponent<SpriteRenderer>();
        playerssprite = playersprite.GetComponent<SpriteRenderer>();
  
    }

    
    private void Update()
    {
        Vector3 viewpos;
        cameraScreenPosition = camera.ScreenToWorldPoint(new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z));
        if (starttouch == true)
        {
            
            camera.orthographicSize = 2;
            zoom.SetActive(true);
            spriterender.maskInteraction = (SpriteMaskInteraction) 1;
            MoveScope();
            playerssprite.sortingOrder = 4;


        }
        else
        {
            camera.orthographicSize = 5;
            zoom.SetActive(false);
            spriterender.maskInteraction = (SpriteMaskInteraction) 0;
           transform.localPosition = Vector3.zero;
           playerssprite.sortingOrder = 3;


        }
        viewpos = transform.localPosition;
        viewpos.x = Mathf.Clamp(viewpos.x,  -camera.orthographicSize*camera.aspect   , camera.orthographicSize*camera.aspect  );
        viewpos.y = Mathf.Clamp(viewpos.y, -camera.orthographicSize , camera.orthographicSize ) ;
        transform.localPosition = viewpos;
        



    }
    void JoyStickDragStart()
    {
        starttouch= true;
        cameraLimit._zoom = true;
    }
    

    void JoyStickDragEnd()
    {
        starttouch = false;
        cameraLimit._zoom = false;

    }

    private void MoveScope()
    {
        if (cameraLimit.lastPosition == Vector3.zero)
            cameraLimit.lastPosition = camera.transform.position;
        
        camera.transform.position = camera.transform.position + transform.localPosition;
        horizentalMove = Joystick.Horizontal * panSpeed;
        verticalMove = Joystick.Vertical * panSpeed;
        transform.position += new Vector3(horizentalMove*Time.deltaTime,verticalMove*Time.deltaTime,0);
    }
}
