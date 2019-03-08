using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float speed = 8;
    [HideInInspector]
    public List<CubeController> gameControllerCubeListReference;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed; 

        if (transform.position.z < -5)
        {
            Destroy(this.gameObject);
            gameControllerCubeListReference.Remove(this);
        }
    }
}
