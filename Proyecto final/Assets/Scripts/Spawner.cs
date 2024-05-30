using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabZombie;
    private GameObject zombie;
    private List<GameObject> zombieList = new List<GameObject>();
    [SerializeField] private List<Transform> pointsZombies;
    private GameManager gm;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pointsZombies = new List<Transform>();
        
    }
    void Start()
    {
        SpawnZombies();
    }
    void Update() { }
    private void SpawnZombies()
    {
        for (int i = 0; i < gm.GetMaxEnemies(); i++)
        {
            zombie = Instantiate(prefabZombie);
            zombie.GetComponent<EnemyBT>().points = pointsZombies;
            zombieList.Add(zombie);
        }
    }
}
