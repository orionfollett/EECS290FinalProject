using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class movement : MonoBehaviour
{

    public float vel;
    public float jVel;
    //public float gravity;

    private Rigidbody2D rb;
    private bool jump;
    private bool dead;

    public SpriteRenderer deathCaption;
    public SpriteRenderer floatSprite;
    public SpriteRenderer playerSprite;

   // public GameObject playerHolder;

    private bool beSureOfDeath;

    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;



        jump = false;
        //vel = 5f;
        //jVel = 7.5f;
        rb = GetComponent<Rigidbody2D>();

        
        beSureOfDeath = false ;


        //make death caption invisible
        deathCaption.enabled = false;
        floatSprite.enabled = false;
        playerSprite.enabled = true;
        PlayerPrefs.SetString("Vehicle", "normal");

        dead = false;
        //rb.velocity = new Vector2(vel, rb.velocity.y);
        rb.velocity = new Vector2(vel, 0);
        //rb.isKinematic = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dead == false)
        {
            //is dead must be before move because it uses velocity and move sets velocity
            dead = isDead();
            Move();

            //Debug.Log(PlayerPrefs.GetString("Vehicle"));

            if (PlayerPrefs.GetString("Vehicle").Equals("normal"))
            {
                playerSprite.enabled = true;
                floatSprite.enabled = false;

                Jump();
            }
            else {
                floatSprite.enabled = true;
                playerSprite.enabled = false;
                FloatJump();
            }            
        }

        Quit();
    }

    void Quit() {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    void Move()
    {
        

        if (!dead) {
            rb.velocity = new Vector2(vel, rb.velocity.y);
        }
    }


    void Jump()
    {
        if (IsGrounded() && jump)
        {
            jump = false;
        }
        if (Input.GetKey(KeyCode.Space) && !jump)
        {
            rb.velocity = new Vector2(vel, jVel);
            jump = true;
        }
    }

    void FloatJump()
    {
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(vel, jVel);
            // jump = true;
        }
    }

    bool RayCastGroundCheck()
    {
        // Cast a ray straight down.

        Vector2 origin = new Vector2(transform.position.x, transform.position.y - .51f);

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down);
        
        // If it hits something...
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - origin.y);

            /*
            //public static void DrawLine(Vector3 start, Vector3 end, Color color = Color.white, float duration = 0.0f, bool depthTest = true);
            Vector3 s, e;
            s = new Vector3(origin.x, origin.y, 0);
            e = new Vector3(origin.x, origin.y + distance, 0);
            Debug.DrawRay(s, Vector2.down, Color.green);
            */


            if (distance > 0.015f)
            {
                return false;
            }
            else {

                return true;
            }
        }
        
        return false;
    }

    //uses combination of ray cast and y velocity check in order to avoid double jump glitch
    bool IsGrounded()
    {
        if (rb.velocity.y == 0)
        {
            if (RayCastGroundCheck()) {

                return true;
            }

        }

        return false;
    }

    bool isDead()
    {
        /*
        Vector2 origin = new Vector2(transform.position.x + 0.51f, transform.position.y - .4f);

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right);

        // If it hits something...
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - origin.y);
            //
        */
        //if (distance < .02f && rb.velocity.x < vel)

        if (rb.velocity.x != 0 && beSureOfDeath) {
            beSureOfDeath = false;
        }

        if (rb.velocity.x == 0)
        {
            
            if (beSureOfDeath) {
                
                    rb.isKinematic = true;
                    rb.velocity = new Vector2(0, 0);

                    //show death caption
                    deathCaption.enabled = true;

                    StartCoroutine(Die());

                    return true;
             }

            beSureOfDeath = true;
            

        }
           return false;
            
       
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1f);
        /*
        transform.position = new Vector2(-1f, 0.8f);

        rb.isKinematic = false;
        dead = false;
        rb.velocity = new Vector2(vel, 0);
        deathCaption.enabled = false;
        */
        /*
        rb.isKinematic = false;
        dead = false;
        rb.velocity = new Vector2(vel, 0);
        deathCaption.enabled = false;
        */
        SceneManager.LoadScene(sceneName);

        /*

        GameObject floatPlayer;
        floatPlayer = playerHolder.transform.Find("floatPlayer").gameObject;
        floatPlayer.transform.position = new Vector2(-1f, 0.8f);
        */
        /*
        //reenable all triggers
        GameObject[] triggers;
        triggers = GameObject.FindGameObjectsWithTag("Respawn");


        for (int counter = 0; counter < triggers.Length; counter++)
        {

            Debug.Log(triggers[counter].ToString());
            triggers[counter].SetActive(true);
        }
        */

        yield break;
    }

}
