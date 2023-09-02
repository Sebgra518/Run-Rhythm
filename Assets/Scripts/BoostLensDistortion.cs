using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BoostLensDistortion : MonoBehaviour
{
    public bool p = false;
    public bool q = false;
    private float a = 50.0f;
    private float b = 5.0f;
    public LensDistortion lensDistortion;
    public Bloom boostGlow;




    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Main Camera").GetComponent<PostProcessVolume>().profile.TryGetSettings(out lensDistortion);
        GameObject.Find("Main Camera").GetComponent<PostProcessVolume>().profile.TryGetSettings(out boostGlow);
    }

    // Update is called once per frame
    void Update()
    {
        if (p)
        {
            a -= 1f;
            lensDistortion.intensity.Override(a);
            if (lensDistortion.intensity.value == 0.0f)
            {
                p = false;
                a = 50.0f;
            }
        }
        if (q)
        {
            b -= 0.05f;
            boostGlow.intensity.Override(b);
            if (boostGlow.intensity.value <= 1.0f)
            {
                q = false;
                b = 5.0f;
            }
        }
    }
}
