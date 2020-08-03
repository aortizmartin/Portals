using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viaje : MonoBehaviour
{
    // Clase diseñada para destruir el NPC una vez traspasa la puerta
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collected")
        {
            Debug.Log("A Destruir: " + other.name);
            Destroy(other.gameObject);
        }
    }
}
