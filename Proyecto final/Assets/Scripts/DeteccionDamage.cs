using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDamage : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private int vida = 50;
    [Range(0, 30)]
    [SerializeField] private int damage = 25;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hi1");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            TakeDamage();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hi");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (vida > 0)
        {
            vida -= damage;
        }
    }
}
