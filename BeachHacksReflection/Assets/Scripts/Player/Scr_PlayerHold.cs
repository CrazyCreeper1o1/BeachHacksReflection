using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerHold : MonoBehaviour
{
    Camera PlayerCamera;
    public GameObject HeldObject = null;

    public bool ObjectHeld = false;

    public float HoldDistance = 1f;
    public float ScrollScale = 0.25f;
    public float HoldDistanceMin = 1f;
    public float HoldDistanceMax = 3f;

    public float HoldStrength=10f;
    public float HoldElasticity=1f;

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

        HoldDistance = Mathf.Clamp(HoldDistance + (Input.mouseScrollDelta.y * ScrollScale), HoldDistanceMin, HoldDistanceMax);

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
            var rb = HeldObject.GetComponent<Rigidbody>();
            if (rb)
            {
                Vector3 direction = ((PlayerCamera.transform.position + (PlayerCamera.transform.forward * HoldDistance)) - HeldObject.transform.position);
                if (direction.magnitude > HoldElasticity)
                {
                    Release();
                    return;
                }

                rb.velocity = direction*HoldStrength*rb.mass;
                rb.angularVelocity = Vector3.zero;
                //rb.MovePosition(PlayerCamera.transform.position + (PlayerCamera.transform.forward * HoldDistance));
                rb.MoveRotation(PlayerCamera.transform.rotation * Quaternion.Euler(270, 90, 0));
            }

           // HeldObject.transform.position = PlayerCamera.transform.position + (PlayerCamera.transform.forward * HoldDistance));
            //HeldObject.transform.rotation = PlayerCamera.transform.rotation*Quaternion.Euler(270,90,0);
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

                if (hit.transform.gameObject.GetComponent<Scr_Item>() != null)
                {
                    HeldObject = hit.transform.gameObject.GetComponent<Scr_Item>().gameObject;
                    ObjectHeld = true;

                    HoldDistance = Mathf.Clamp((HeldObject.transform.position-PlayerCamera.transform.position).magnitude + (Input.mouseScrollDelta.y * ScrollScale), HoldDistanceMin, HoldDistanceMax);

                    var rb = HeldObject.GetComponent<Rigidbody>();
                    if(rb)
                    {
                        rb.useGravity = false;
                    }
                }
                else
                {

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
            rb.useGravity = true;
        }
        ObjectHeld = false;
        HeldObject = null;
        Debug.Log("releasing");
    }

    private void OnMouseDown()
    {

    }
}
