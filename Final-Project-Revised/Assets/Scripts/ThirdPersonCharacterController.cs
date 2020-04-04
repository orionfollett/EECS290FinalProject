using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    float _vertSpeed;
    public float minFall = -1.5f;
    public Transform Player;
    public float jumpSpeed = 15f;
    public float gravity = -9.8f;
    public float terminalVelocity = -35f;
    private CharacterController _charController;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
        Speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    public void movePlayer()
    {
        Vector3 forward = Player.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        horizontalInput *= Speed;
        verticalInput *= Speed;
        Vector3 playerMovement = (horizontalInput * right) + (verticalInput * forward);


        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0)
        {
            Physics.Raycast(transform.position, Vector3.down, out hit);
            float check = (_charController.height + _charController.radius) / 1.9f;
            hitGround = hit.distance <= check;  // to be sure check slightly beyond bottom of capsule
            
        }


        if (hitGround) //we are on solid ground
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("whee");
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }

        }
        playerMovement.y = _vertSpeed;
        _charController.Move(playerMovement * Time.deltaTime);

    }

}
