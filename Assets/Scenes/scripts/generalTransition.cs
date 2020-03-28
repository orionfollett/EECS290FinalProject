using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Vehicle", "normal");
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if (this.gameObject.activeInHierarchy)
        {
            if (PlayerPrefs.GetString("Vehicle").Equals("normal"))
            {

                PlayerPrefs.SetString("Vehicle", "float");

            }
            else {

                PlayerPrefs.SetString("Vehicle", "normal");
            }
        }
    }

    
}
