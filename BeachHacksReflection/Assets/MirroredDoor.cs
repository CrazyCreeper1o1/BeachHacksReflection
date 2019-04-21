using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirroredDoor : MonoBehaviour
{

    public Doors.Door ParentDoor;
    public Doors.Door SonDoor;

    public Doors.Lock ParentLock;
    public Doors.Lock SonLock;

    private void Update()
    {
        SonDoor.Locked = ParentDoor.Locked;
        SonLock.Locked = ParentLock.Locked;
    }
}
