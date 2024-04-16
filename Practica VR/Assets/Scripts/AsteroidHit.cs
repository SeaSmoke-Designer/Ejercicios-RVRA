using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void AsteroidDestroyed()
    {
        gm.AsteroidDestruido();
        Instantiate(asteroidExplosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
