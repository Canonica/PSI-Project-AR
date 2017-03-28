using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionObject : MonoBehaviour {

    private int damage;
    private float radius;
    private SphereCollider myCollider;

    public void Init(int parDamage, float parRadius)
    {
        myCollider = GetComponent<SphereCollider>();
        radius = parRadius;
        myCollider.radius = radius;
        damage = parDamage;
        Destroy(gameObject, 0.5f);
        Invoke("DisableDamage", 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fish")
        {
            other.GetComponent<Fish>().TakeDamage(damage);
            DisableDamage();
            Destroy(gameObject, 0.5f);
        }
    }

    void DisableDamage()
    {
        damage = 0;
    }
}
