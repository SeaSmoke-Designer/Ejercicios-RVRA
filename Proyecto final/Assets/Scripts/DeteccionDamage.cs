using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDamage : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private int vida = 50;
    [Range(0, 30)]
    [SerializeField] private int damage = 25;
    private GameManager gm;
    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (vida <= 0)
        {
            DestroyObject();
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

    private void TakeDamage()
    {
        if (vida > 0)
        {
            vida -= damage;
        }
    }

    void DestroyObject()
    {
        gm.SumarPoints();
        Destroy(gameObject);
    }
}
