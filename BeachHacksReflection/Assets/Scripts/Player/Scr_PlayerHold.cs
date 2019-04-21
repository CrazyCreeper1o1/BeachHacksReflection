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

        Cursor.visible = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
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
            //HeldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //HeldObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else
        {
            ObjectHeld = false;
        }
    }

    void GrabObject()
    {
        Debug.Log("Grabbing");
        Ray CameraDirection = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
        RaycastHit[] hitInfo;
        hitInfo = Physics.RaycastAll(CameraDirection);
        if (hitInfo.Length>0)
        {
            Debug.DrawLine(PlayerCamera.transform.position, PlayerCamera.transform.position + PlayerCamera.transform.forward * 5f, Color.red, 1f);
            foreach (var hit in hitInfo)
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.GetComponent<Scr_Item>() != null)
                {
                    HeldObject = hit.transform.gameObject.GetComponent<Scr_Item>().gameObject;
                    ObjectHeld = true;

                    var rb = HeldObject.GetComponent<Rigidbody>();
                    if(rb)
                    {
                        rb.isKinematic = true;
                    }
                }
                else
                {
                    Debug.Log("Object hit but no item: " + hit.transform.gameObject.name);
                }
            }

        }
        else
        {
            Debug.Log("FoundNothing");
        }
    }
    void Release()
    {
        var rb = HeldObject.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.isKinematic = false;
        }
        ObjectHeld = false;
        HeldObject = null;
        Debug.Log("releasing");
    }

    private void OnMouseDown()
    {

    }
}
