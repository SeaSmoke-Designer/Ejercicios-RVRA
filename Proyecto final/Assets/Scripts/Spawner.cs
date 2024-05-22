using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabZombie;
    private GameManager zombie;
    private List<GameObject> zombieList = new List<GameObject>();
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnZombies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnZombies()
    {
        for (int i = 0; i < gm.GetMaxEnemies(); i++)
        {
            Instantiate(prefabZombie);
        }
    }
}
