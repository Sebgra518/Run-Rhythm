using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public float boostAmount;//How much speed is going to be added

    private bool spaceKeyState;
    private bool boostCheckThreshold = false; //Threshold to make the space inuts more fair

    private Text PowerPercent;
    private GameManager gm;

    private GameObject boostParticles;

    private BoostLensDistortion boostLensDistortion;

    public float boostTimeLOc;
   
    // Start is called before the first frame update
    void Start()
    {
        boostLensDistortion = GameObject.Find("Boosts").GetComponent<BoostLensDistortion>();
        PowerPercent = GameObject.Find("PowerPercent").GetComponent<Text>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        boostParticles = GameObject.Find("BoostParticles");

        Invoke("startBoostEffect", 0.001f);
    }
 
    // Update is called once per frame
    void Update()
    {
        spaceKeyState = Input.GetKeyDown(KeyCode.Space);

        if (spaceKeyState && !boostCheckThreshold)
        {
            boostCheckThreshold = true;
            Invoke("disableThreshhold", 0.05f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (boostCheckThreshold && other.gameObject.tag == "Player")
        {
            boostLensDistortion.p = true;
            boostLensDistortion.q = true;
            boostLensDistortion.lensDistortion.intensity.Override(50f);
            boostLensDistortion.boostGlow.intensity.Override(5f);
            gm.currentBoostNumber++;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, other.gameObject.GetComponent<Rigidbody>().velocity.z + boostAmount);//Increase speed

            gm.warpGame(other.gameObject.GetComponent<Rigidbody>().velocity.z, gameObject);


            PowerPercent.text = (((double)gm.currentBoostNumber / gm.totalNumOfBoosts) * 100).ToString() + "%";
            
            boostParticles.SetActive(true);
            boostParticles.GetComponent<ParticleSystem>().Play();
            gameObject.SetActive(false);
        }
    }

    public void startBoostEffect()
    {
        boostParticles.SetActive(false);
    }
    private void disableThreshhold()
    {
        boostCheckThreshold = false;
    }
}
