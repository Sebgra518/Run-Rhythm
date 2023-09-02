using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Rigidbody rb;
    public float startSpeed = 5f;

    public int totalNumOfBoosts;
    public int currentBoostNumber = 0;

    private GameObject[] arrOfBoosts;
    private GameObject[] obstacles;

    public GameObject player;


    void Start()
    {
        rb.velocity = new Vector3(0, 0, startSpeed);

        arrOfBoosts = GameObject.FindGameObjectsWithTag("Boost");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        //Set all the inital time locations (without boosts)
        foreach (GameObject boost in arrOfBoosts)
        {
            boost.GetComponent<Boost>().boostTimeLOc = (boost.GetComponent<Boost>().transform.position.z / startSpeed);
        }
        foreach (GameObject obstacles in arrOfBoosts)
        {
            obstacles.GetComponent<Boost>().boostTimeLOc = (obstacles.GetComponent<Boost>().transform.position.z / startSpeed);
        }

    }
    public void warpGame(float newSpeed, GameObject currentBoost)
    {
        float currentBoostLoc = currentBoost.GetComponent<Boost>().boostTimeLOc * newSpeed - player.transform.position.z;
        foreach (GameObject boost in arrOfBoosts)
        {
            boost.transform.position = new Vector3(boost.transform.position.x, 
                                                   boost.transform.position.y,
                                                   (boost.GetComponent<Boost>().boostTimeLOc * newSpeed) - currentBoostLoc);
        }
    }

}
