using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;

    private CharacterController _charController;
    private Animator _animator;
    public GameObject smokePuff;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rotateAmount = Vector3.zero;
            rotateAmount.y = 50;
            this.gameObject.transform.Rotate(rotateAmount);  
            _animator.Play("Two Hand Spell Casting");
            //rotateAmount.y *= -1;
            //this.gameObject.transform.Rotate(rotateAmount);
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.green, 2f);
        Ray shot = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(shot, out hitInfo, 100))
        {
            GameObject hitObject = hitInfo.transform.gameObject;
            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            if (target != null)
            {
                target.ReactToHit();
                Messenger.Broadcast(GameEvent.ENEMY_HIT);
            }
            else
            {
                if (hitObject.tag != "UITrigger")
                    StartCoroutine(SphereIndicator(hitInfo.point));
            }
            
        }
        //this.gameObject.transform.Rotate(0,-45,0);
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        Destroy(Instantiate(smokePuff, pos, Quaternion.identity) as GameObject, 2);


        yield return new WaitForSeconds(1);
    }
}
