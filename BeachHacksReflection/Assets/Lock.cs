using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Doors
{
    public class Lock : MonoBehaviour
    {
        private bool locked=true;
        public bool Locked
        {
            get
            {
                return locked;
            }
            set
            {
                locked = value;
                if (!locked)
                {
                    UnlockLock();
                    UnlockDoor();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Scr_Item ItemScript = collision.collider.gameObject.GetComponent<Scr_Item>();
            if (ItemScript != null)
            {
                if (ItemScript.ItemID == Scr_Item.ItemList.Key)
                {
                    UnlockLock();

                    Destroy(ItemScript.gameObject);

                    TimerManager.main.AddTask(UnlockDoor, 1);
                }
            }
        }
        public void UnlockLock()
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().velocity = transform.forward * 5;

            locked = false;
        }
        public void UnlockDoor()
        {
            transform.parent.GetComponentInChildren<Door>().Locked = false;
        }
    }


}