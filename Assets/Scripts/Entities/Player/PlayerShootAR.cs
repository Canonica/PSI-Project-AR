using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerShootAR : MonoBehaviour {
    public int damage;
    public float fireRate;

    bool canShoot;
    public AudioSource gunSound;
    public GameObject gun;
    private ParticleSystem emitter;
    public GameObject aimImage;

    private void Start()
    {
        canShoot = true;
        gunSound = GetComponent<AudioSource>();
        emitter = gun.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            ContextManager.instance.SwitchContext(ContextManager.GameContext.Shoot);
        }
        if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved) && ContextManager.instance.CompareContext(ContextManager.GameContext.Shoot) && canShoot)
        {
            StartCoroutine(Shoot());
        }
       
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        gunSound.pitch = Random.Range(0.9f, 1.1f);
        gunSound.Play();
        emitter.Play();
        aimImage.transform.DOScale(1.2f, 0.1f).OnComplete(()=> aimImage.transform.DOScale(1f, 0.3f));
        gun.transform.DOShakePosition(0.2f, 0.01f, 10, 10);
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.GetComponent<Fish>().TakeDamage(damage);
            VFXManager.instance.PlayVFX(VFXManager.instance.GetVFX(VFXNames.VFX_Explo), hit.transform.position);
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
