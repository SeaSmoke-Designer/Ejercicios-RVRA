using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPoints;
    
    [SerializeField] private int maxPoints;
    private int currentPoints;
    private int sumPoints = 50; //puntos por cada enemigo que matas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarPoints()
    {

    }
}
