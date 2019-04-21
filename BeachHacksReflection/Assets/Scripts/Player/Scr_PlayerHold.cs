using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerHold : MonoBehaviour
{
    Camera PlayerCamera;
    public GameObject HeldObject = null;

    public bool ObjectHeld = false;

    public float HoldDistance = 1f;

    private void Start()
    {
        PlayerCamera = transform.GetComponentInChildren<Camera>();

        
    }
    void Update()
    {
        if (HeldObject == null)
        {
            ObjectHeld = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICKED!");
            if (!ObjectHeld)
            {
                GrabObject();
                Debug.Log("FindingObject");
            }
            else
            {
                Release();
            }
        }

        if (ObjectHeld)
        {
            HeldObject.transform.position = PlayerCamera.transform.position+(PlayerCamera.transform.forward*HoldDistance);
            HeldObject.transform.rotation = PlayerCamera.transform.rotation;
            HeldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            HeldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else
        {
            ObjectHeld = false;
        }
    }

    void GrabObject()
    {
        Debug.Log("Grabbing");
        Ray CameraDirection = new Ray(PlayerCamera.transform.position,PlayerCamera.transform.position + PlayerCamera.transform.forward*5f);
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(CameraDirection, out hitInfo);
        if (hit)
        {
            Debug.Log(hitInfo.transform.gameObject.name);
            if (hitInfo.transform.gameObject.GetComponent<Scr_Item>() != null)
            {
                HeldObject = hitInfo.transform.gameObject.GetComponent<Scr_Item>().gameObject;
                ObjectHeld = true;
            }
            else
            {
                Debug.Log("Object hit but no item");
            }
        }
        else
        {
            Debug.Log("FoundNothing");
        }
    }
    void Release()
    {
        ObjectHeld = false;
        HeldObject = null;
        Debug.Log("releasing");
    }

    private void OnMouseDown()
    {

    }
}
