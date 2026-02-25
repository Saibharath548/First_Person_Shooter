using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController playerScript;
    [SerializeField] private PlayerInputActions playerInputs;
    private RaycastHit bulletTraceHitInfo;
    private Vector3 targetPoint;
    

    [Header("Gun Properties")]
    [SerializeField] private Transform gunShootingPoint;
    [SerializeField] private int bulletPerMagzine;
    [SerializeField] private bool canShoot;
    [SerializeField] private AudioSource audioSource;

    [Header("Bullet Properties")]
    [SerializeField] private ParticleSystem particleEffect;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioClip bulletShot;
    [SerializeField] private int bulletInMagzine;


    private void Start()
    {
        playerInputs.OnShooting += PlayerScript_OnShooting;
        bulletInMagzine = bulletPerMagzine;
        canShoot = true;
    }


    private void PlayerScript_OnShooting(object sender, System.EventArgs e)
    {
        if (canShoot)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.yellow);

            if (Physics.Raycast(ray, out bulletTraceHitInfo, 100, layerMask))
            {
                targetPoint = bulletTraceHitInfo.point;
            }
            else
            {
                targetPoint = ray.GetPoint(1000);
            }

            Vector3 particleDirection = (targetPoint - gunShootingPoint.position).normalized;

            particleEffect.transform.SetPositionAndRotation(gunShootingPoint.position, Quaternion.LookRotation(particleDirection));
            Debug.DrawRay(gunShootingPoint.position, particleDirection * 1000f, Color.red);
        }
    }

    public void FireFunction()
    {
        bulletInMagzine--;
        audioSource.PlayOneShot(bulletShot);
        CameraShake.instance.CameraShakeFrequency(0.5f, 0.065f);
        particleEffect.Play();
    }

    private void ReloadComplete()
    {
        canShoot = true;
        bulletInMagzine = bulletPerMagzine;
    }

    public int RemainingBullet()
    {
        return bulletInMagzine;
    }
    public int BulletsPerMagzine()
    {
        return bulletPerMagzine;
    }

    public void GunReload()
    {
        canShoot = false;
        Invoke("ReloadComplete", 1.5f);
    }
}