using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalConnector : MonoBehaviour
{
    static float x = 0;

    protected void InsertPortal(Vector3 pos, Quaternion rot, Room roomType, PortalComponent portalType)
    {

        PortalComponent p1 = Instantiate(portalType, pos, rot);
        x += 100;
        Room room = Instantiate(roomType, Vector3.forward * x, new Quaternion());
        Transform coords = room.AddAccessDoor();
        PortalComponent p2 = Instantiate(portalType, coords);

        p1.linkedPortal = p2;
        p2.linkedPortal = p1;
        p1.GetComponentInChildren<DoorInteractable>().UpdateConnection();
        p2.GetComponentInChildren<DoorInteractable>().UpdateConnection();
    }
}