using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooting : MonoBehaviour
{
    public Rigidbody Dart;
    public Transform FirePoint;
    public float InitialProjectileForce = 15f;
    float mouseX, mouseY;

    private bool fired;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        fired = true;
        Rigidbody dartInstance = Instantiate(Dart, FirePoint.position, FirePoint.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
        float horizontalInput = Input.GetAxis("Horizontal");
        
        Vector3 dartDirection = InitialProjectileForce * FirePoint.forward;
        dartDirection.x += horizontalInput * 6;
        dartInstance.velocity = dartDirection;
        Destroy(dartInstance, 3);
        
    }
}
