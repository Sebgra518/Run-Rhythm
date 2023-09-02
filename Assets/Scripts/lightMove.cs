using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMove : MonoBehaviour
{
    public Rigidbody sphere;
    
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, sphere.velocity.z);
    }
}
