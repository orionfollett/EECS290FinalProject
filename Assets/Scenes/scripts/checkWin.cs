using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkWin : MonoBehaviour
{
    public Transform player;
        
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;


        if (sceneName.Equals("Level1")) {
            PlayerPrefs.SetString("Level", "Level2");
            SceneManager.LoadScene("Level2");
        }
        if (sceneName.Equals("Level2"))
        {
            PlayerPrefs.SetString("Level", "Level3");
            SceneManager.LoadScene("Level3");
        }
        if (sceneName.Equals("Level3")) {
            Application.Quit();
        }


    }
}
