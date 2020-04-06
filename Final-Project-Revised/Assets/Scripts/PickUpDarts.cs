using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDarts : MonoBehaviour
{
    private GameObject player;
    private DartShooting gun;
    private Vector3 human;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            gun = player.GetComponent<DartShooting>();
            gun.ammoCount = 100;
        }
        else {
            Debug.Log("Need to have a player in the scene, pick up darts cant find a player!");
        }

        

        //player
        //player.ammoCount++;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 10) {

        }
    }
}
