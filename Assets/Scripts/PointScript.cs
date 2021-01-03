using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    private float _rotationspeed = 20f;
    private Vector3 _horizentalmovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizentalmovement = new Vector3(0f,0f,-Input.GetAxis("Horizontal"));
        transform.Rotate(_horizentalmovement * _rotationspeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 10f);
            if (hit)
            {
                Debug.Log("THE NAME OF " + hit.collider.name);
            }
        }
    }
}
