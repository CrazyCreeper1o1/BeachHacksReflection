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
        Debug.Log("udpate");
        if ((SonLock.Locked==false) || (ParentLock.Locked==false))
        {
            Debug.Log("Unlock?");
            SonLock.UnlockLock();
            ParentLock.UnlockLock();

            UnlockDoors();
           // TimerManager.main.AddTask(UnlockDoors, 1);
        }
    }
    public void UnlockDoors()
    {
        Debug.Log("UnlockDoors():=");
        ParentDoor.Unlock();
        SonDoor.Unlock();
    }
}
