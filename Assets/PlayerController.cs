using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sideSpeed = 6;
    private float rotation = 0;
    public float rotationSpeed = 3;
    public float maxRotation = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float desiredRotation = 0; 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime * sideSpeed;
            desiredRotation += 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime * sideSpeed;
            desiredRotation -= 1;
        }

        rotation = Mathf.Lerp(rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * maxRotation));

    }
}
