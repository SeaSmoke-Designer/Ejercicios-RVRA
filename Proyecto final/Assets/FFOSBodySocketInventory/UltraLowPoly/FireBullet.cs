using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
[RequireComponent(typeof(AudioSource))]
public class FireBullet : MonoBehaviour
{
    [SerializeField] private float speedBullet = 50f;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private Transform frontOfGun;
    [Range(1, 15)]
    [SerializeField] private int bullets = 10;
    private int currentBullets;

    [Range(1f, 5f)]
    [SerializeField] private float timeReloadBullets = 3f;

    private AudioSource audioSource;
    private bool isReloadBullets;

    [SerializeField] private AudioClip gunShot;
    [SerializeField] private AudioClip emptyGunShot;
    [SerializeField] private TextMeshProUGUI textNumberBullets;

    [SerializeField] private GameObject animationReload;
    [SerializeField] private GameObject textBullets;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animationReload.SetActive(false);
    }

    private void Start()
    {

        currentBullets = bullets;
        isReloadBullets = false;
        audioSource.clip = gunShot;
        textNumberBullets.text = currentBullets.ToString();
    }

    public static event Action GunFired;
    public void Fire()
    {
        if (currentBullets > 1)
        {
            audioSource.Play();
            GameObject spawnedBullet = Instantiate(bulletObj, frontOfGun.position, frontOfGun.rotation);
            spawnedBullet.GetComponent<Rigidbody>().velocity = speedBullet * frontOfGun.forward;
            Destroy(spawnedBullet, 6f);
            GunFired?.Invoke();
            currentBullets--;
            textNumberBullets.text = currentBullets.ToString();
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
        audioSource.clip = emptyGunShot;
        animationReload.SetActive(true);
        textBullets.SetActive(false);
        yield return new WaitForSeconds(timeReloadBullets);
        currentBullets = bullets;
        textNumberBullets.text = currentBullets.ToString();
        isReloadBullets = false;
        audioSource.clip = gunShot;
        animationReload.SetActive(false);
        textBullets.SetActive(true);
    }


}
