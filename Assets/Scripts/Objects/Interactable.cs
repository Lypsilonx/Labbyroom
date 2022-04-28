using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }
    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFcous();

//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.yellow;
//        Gizmos.DrawWireCube(transform.position, transform.localScale);
//    }
}
