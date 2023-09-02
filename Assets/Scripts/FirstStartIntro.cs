using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStartIntro : MonoBehaviour
{
    public EaseOut[] platforms;
    // Start is called before the first frame update
 
    void enableEase()
    {
        foreach (EaseOut platform in platforms)
        {
            platform.enable = true;
        }
    }
}