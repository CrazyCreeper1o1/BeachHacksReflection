using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scr_ReflectionTest : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;

    void FixedUpdate()
    {
        Vector3 Object1Position = Object1.transform.position;
        Object1Position.x *= -1f;
        Object2.transform.position = Object1Position;

        Quaternion Object1Rotation = Object1.transform.rotation;
        Object1Rotation.x *= -1;
        Object1Rotation.w *= -1;
        Object2.transform.rotation = Object1Rotation;
    }
}
