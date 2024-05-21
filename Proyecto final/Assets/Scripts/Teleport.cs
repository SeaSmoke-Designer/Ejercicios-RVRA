using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private bool teleported;
    
    void Start()
    {
        teleported = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("XR-Origin") && !teleported)
        {
            SceneManager.LoadScene(1);
            teleported = true;
        }

    }
}
