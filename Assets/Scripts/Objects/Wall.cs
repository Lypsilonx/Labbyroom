using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Interactable
{
    public WallManager manager;
    //To be reworked (Temporary)
    [SerializeField] Room roomType;

    override public void OnInteract(Vector3 pos)
    {
        manager.AddDoor(pos, 2, roomType);
    }

    override public void OnFocus(Vector3 pos)
    {
        return;
    }

    override public void OnLoseFcous()
    {
        return;
    }
}
