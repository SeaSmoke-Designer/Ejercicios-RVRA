using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject firstCanvas;
    [SerializeField] private GameObject secondCanvas;
    //public delegate void DelegateButton();
    //public event DelegateButton CambiarCanvas;

    public void TaskOnClick()
    {
        //CambiarCanvas();
        firstCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }
}
