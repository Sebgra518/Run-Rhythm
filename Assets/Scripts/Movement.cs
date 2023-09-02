using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Movement : MonoBehaviour
{
    public int location = 1;
    public int maxPos = 11;//Note: counts 0 | Only lane matters when itterating though array

    private Vector2[] locations= new [] {new Vector2(-3f,1.1f), new Vector2(0,1.1f), new Vector2(3f,1.1f),
                                         new Vector2(3.9f,1.5f), new Vector2(3.9f, 4.5f), new Vector2(3.9f, 7.5f),
                                         new Vector2(3f,8.9f), new Vector2(0,8.9f), new Vector2(-3f,8.9f),
                                         new Vector2(-3.9f,7.5f), new Vector2(-3.9f,5f), new Vector2(-3.9f,1.5f) };
    private Rigidbody rb;
    private Transform vcamT;
    public GameObject vcam;
    public bool enableCameraSwitch = true;

    [Header("Display")]
    public float speed;

    void setLoc(int i)
    {
        gameObject.transform.position = new Vector3(locations[i].x, locations[i].y, gameObject.transform.position.z);
    }


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        vcamT = vcam.transform;
    }
    void Update()
    {

        speed = rb.velocity.z;

        //Rotation Controls
        if (Input.GetKeyDown(KeyCode.A))
        {
            location -= 3;
            if (location < 0)
            {
                location = location + (maxPos + 1);
            }
            setLoc(location);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            location += 3;
            if (location > maxPos)
            {
                location = location - (maxPos+1);
            }
            
            setLoc(location);
        }

        //Lane Controls
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (location <= 0)
            {
                location = maxPos;
            }
            else
            {
                location--;
            }
            setLoc(location);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (location >= maxPos)
            {
                location = 0;
            }
            else
            {
                location++;
            }
            setLoc(location);
        }

        if (enableCameraSwitch)
        {
            if (location >= 0 && location <= 2)
            {
                vcamT.eulerAngles = new Vector3(0, 0, 0);
            }
            if (location >= 3 && location <= 5)
            {
                vcamT.eulerAngles = new Vector3(0, 0, 90f);
            }
            if (location >= 6 && location <= 8)
            {
                vcamT.eulerAngles = new Vector3(0, 0, 180f);
            }
            if (location >= 9 && location <= 11)
            {
                vcamT.eulerAngles = new Vector3(0, 0, 270f);
            }
        }
    }
}