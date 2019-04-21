using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scr_ReflectionTest : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;

    public Vector3 Euler = new Vector3(180, 0, 0);

    void FixedUpdate()
    {
        if (Object1 == null || Object2 == null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            Vector3 Object1Position = Object1.transform.position;
            Object1Position.z *= -1f;
            Object2.transform.position = Object1Position;

            Quaternion Object1Rotation = Object1.transform.rotation;
            Object1Rotation.z *= -1;
            Object1Rotation.w *= -1;
            Object2.transform.rotation = Object1Rotation * Quaternion.Euler(Euler);
        }
    }
}
