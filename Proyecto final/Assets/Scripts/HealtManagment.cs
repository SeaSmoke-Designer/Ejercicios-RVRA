using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealtManagment : MonoBehaviour
{
    [SerializeField] private int vidaMaxima = 100;
    private int vidaActual;
    [SerializeField] private int daño = 20;
    [SerializeField] private AudioClip soundDamage;

    private void Awake()
    {
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        if (vidaActual <= 0)
            SceneManager.LoadScene(0);
    }
    void TakeDamage()
    {
        if (vidaActual > 0)
        {
            vidaActual -= daño;
            AudioManager.Instance.PlayClip(soundDamage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("Hi1");
            TakeDamage();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("hi2");
        if (other.gameObject.CompareTag("Zombie"))
            TakeDamage();
    }
}
