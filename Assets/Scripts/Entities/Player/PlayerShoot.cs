using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject prefabZone;
    public int damage;
    public float radiusBullet;
    public float fireRate;

    bool canShoot;

    private void Start()
    {
        canShoot = true;
    }
    // Update is called once per frame
    void Update ()
    {
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved) && ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }



    IEnumerator Shoot()
    {
        canShoot = false;
        Vector3 fingerPos = Input.GetTouch(0).position;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(fingerPos);
        GameObject zone = Instantiate(prefabZone, new Vector3(objPos.x, objPos.y, 0), Quaternion.identity) as GameObject;
        zone.GetComponent<ExplosionObject>().Init(damage, radiusBullet);
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
