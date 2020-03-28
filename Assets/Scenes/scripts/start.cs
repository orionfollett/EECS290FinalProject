using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Vehicle", "normal");
        PlayerPrefs.SetString("Level", "Level1");
    }

    // Update is called once per frame
    void Update()
    {
        PressStart();
    }

    void PressStart() {
        if (Input.GetKey(KeyCode.Space)) {
            SceneManager.LoadScene("Level1");
        }
    }
}
