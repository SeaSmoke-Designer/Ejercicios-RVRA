using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject firstCanvas;
    [SerializeField] private GameObject secondCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private TextMeshProUGUI numberVidas;
    [SerializeField] private TextMeshProUGUI numberAsteroids;
    //private ButtonManager buttonManager;

    private int vidas;
    private int puntuacion;

    private void Awake()
    {
        //buttonManager = GameObject.Find("ButtonManager").GetComponent<ButtonManager>();
        //buttonManager.CambiarCanvas += 
        vidas = 3;
        numberVidas.text = vidas.ToString();
        numberAsteroids.text = 0.ToString();
        firstCanvas.SetActive(true);
        secondCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AsteroidDestruido()
    {
        numberAsteroids.text += 1;

    }

    //void Cambio
}
