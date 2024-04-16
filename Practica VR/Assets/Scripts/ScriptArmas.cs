using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptArmas : MonoBehaviour
{
    [SerializeField] private Animator laserAnimator;
    [SerializeField] private AudioClip laserSFX;
    private AudioSource laserAudioSource;

    [SerializeField] private Transform raycastOrigin;
    //[SerializeField] private LineRenderer laserLineRenderer;

    private RaycastHit hit;

    private void Awake()
    {

        laserAudioSource = GetComponent<AudioSource>();

    }

    public void LaserGunfired()
    {
        //animate the gun
        laserAnimator.SetTrigger("Fire");
        //play laser gun SFX
        laserAudioSource.PlayOneShot(laserSFX);
        // Start drawing the laser
        //laserLineRenderer.enabled = true;
        //laserLineRenderer.SetPosition(0, raycastOrigin.position);
        //raycast



        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
            if (hit.transform.GetComponent<AsteroidHit>() != null)
            {
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
            }
            //laserLineRenderer.SetPosition(1, hit.point);

        }
        else
        {
            //laserLineRenderer.SetPosition(1, raycastOrigin.position + raycastOrigin.forward * 800f); // No hit, draw laser to max length
        }

        // Optionally, disable the laser line after a short delay
        StartCoroutine(DisableLaserAfterDelay(0.1f)); // Adjust delay as needed
    }

    private IEnumerator DisableLaserAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //laserLineRenderer.enabled = false;
    }

}
