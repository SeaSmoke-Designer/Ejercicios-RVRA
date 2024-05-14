using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(AudioSource))]
public class FireBullet : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private Transform frontOfGun;
    [Range(1, 15)]
    [SerializeField] private int bullets = 10;
    private int currentBullets;

    [Range(1f, 5f)]
    [SerializeField] private float timeReloadBullets = 3f;

    private AudioSource audioSource;
    private bool isReloadBullets;

    [SerializeField] private AudioClip disparo;
    [SerializeField] private AudioClip noAmmo;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentBullets = bullets;
        isReloadBullets = false;
        audioSource.clip = disparo;
    }

    public static event Action GunFired;
    public void Fire()
    {
        if (currentBullets > 0)
        {
            audioSource.Play();
            GameObject spawnedBullet = Instantiate(bulletObj, frontOfGun.position, frontOfGun.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speed * frontOfGun.forward;
            Destroy(spawnedBullet, 6f);
            GunFired?.Invoke();
            currentBullets--;
        }
        else
        {
            if (!isReloadBullets)
                StartCoroutine(CorReloadBullets());
            else
                audioSource.Play();
        }

    }

    IEnumerator CorReloadBullets()
    {
        isReloadBullets = true;
        audioSource.clip = noAmmo;
        yield return new WaitForSeconds(timeReloadBullets);
        currentBullets = bullets;
        isReloadBullets = false;
        audioSource.clip = disparo;
    }


}
