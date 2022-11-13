using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPoolItem : MonoBehaviour
{
    public delegate void OnItemDestroyed(GenericPoolItem obj);
    public OnItemDestroyed _OnItemDestroyed;
    public abstract void DisableObject();
    public abstract void EnableObject();
}
