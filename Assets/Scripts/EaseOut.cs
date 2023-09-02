using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseOut : MonoBehaviour
{

    public Vector3 pointA;
    public Vector3 pointB;
    public float speed;
    private float currentTime = 0f;
    public bool enable = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Lerp(0, 1, currentTime) <= 1f && enable)
        {
            currentTime += speed;
            gameObject.transform.position = new Vector3(easeOutNums(pointA.x, pointB.x, currentTime), easeOutNums(pointA.y, pointB.y, currentTime), easeOutNums(pointA.z, pointB.z, currentTime));
        }
        
        
    }

    public float easeOutSine(float time) {
        return Mathf.Sin((time * Mathf.PI) / 2);
    }

    public float easeOutNums(float a, float b, float time)
    {
        return  (b-a) * easeOutSine(Mathf.Lerp(0, 1, time)) + a;
    }


}