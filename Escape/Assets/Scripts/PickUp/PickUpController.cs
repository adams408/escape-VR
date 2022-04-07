using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, container, playerCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool holding;
    public static bool holdingFull;

    private void Start()
    {
        // setup
        if (!holding)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (holding)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            holdingFull = true;
        }
    }

    private void Update()
    {
        // check if player is looking at item and "E" is pressed
        // Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        
        // if (!holding && Physics.Raycast(ray, out hit, pickUpRange) && Input.GetKeyDown(KeyCode.E) && !holdingFull) PickUp();

        Vector3 distanceToPlayer = player.position - transform.position;
        if (!holding && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !holdingFull) PickUp();

        // drop if holding and "Q" is pressed
        if (holding && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        holding = true;
        holdingFull = true;

        // make item a child of the camera and move it to the default position
        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        // transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        // make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        holding = false;
        holdingFull = false;

        // set parent to null
        transform.SetParent(null);

        // make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
    }
}
