using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{

    [SerializeField] GameObject ExplosionM;
    [SerializeField] Transform parent;
    [SerializeField] int hits = 10;


  
    void Start()
    {
        AddCollider();
        //tower.ActivateGuns();

    }

    private void AddCollider()
    {
        Collider enemy = gameObject.AddComponent<BoxCollider>();
        enemy.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hits--;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.z));
    }
    private void KillEnemy()
    {
        GameObject fx = Instantiate(ExplosionM, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        //tower.DeactivateGuns(); //todo deactivate guns when no enemies

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
