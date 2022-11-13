using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : GenericPoolItem
{
    public MeshRenderer meshRenderer;
    public Rigidbody rg;
    public float force = 50;
    public float lifeTime = 2f;

    public override void DisableObject()
    {
        meshRenderer.enabled = false;
        rg.Sleep();
        enabled = false;
    }
    public override void EnableObject()
    {
        enabled = true;
        meshRenderer.enabled = true;
        rg.WakeUp();
        rg.AddForce(new Vector3(Random.Range(0,1), 1, Random.Range(0,1)) * force);
        Invoke("DestroySelf", lifeTime);
    }

    void Start()
    {
        rg.AddForce(new Vector3(Random.Range(0,1), Random.Range(0,1), Random.Range(0,1)) * force);
        Invoke("DestroySelf", lifeTime);
    }

    private void DestroySelf()
    {
        _OnItemDestroyed?.Invoke(this);
    }

}
