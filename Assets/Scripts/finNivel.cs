using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class finNivel : MonoBehaviour
{
    //Control del fin de nivel
    //Controla las animaciones de anillos y activa el cambio de nivel
    Animator anillos;
    int nextLevel;
    NavMeshLink LevelUp;
    public Transform destino;
    private Transform origen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Animator>().enabled=true;
            GetComponent<AudioSource>().enabled = true;
            NivelCntrl.level = NivelCntrl.nivel + 1;
            NivelCntrl.subirNivel = true;
            LevelUp = GetComponent<NavMeshLink>();
            origen = GetComponent<Transform>();
        }
    }
}

