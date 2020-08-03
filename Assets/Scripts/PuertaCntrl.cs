using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PuertaCntrl : MonoBehaviour
{
    public GameObject boton;
    public GameObject vortex;
    public GameObject anillos;
    private GameObject[] targets;
    private NavMeshAgent agente;

    // Update is called once per frame
    void Update()
    {
        if (NivelCntrl.activar)
        {
            boton.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Cuando el jugador toca el boton activador, activamos los objetos relativos al transporte de Jugador y NPCs
        if (other.tag == "Player")
        {
            vortex.SetActive(true);   //Transporte de NPCs
            anillos.SetActive(true);  //Transporte de Jugador
            enviarObjetos();
        }
    }
    private void enviarObjetos()
    {
        //Todos los NPCs son enviados desde la Wait Zone a la Gate
        targets = GameObject.FindGameObjectsWithTag("Collectible");
        for (int i = 0; i < targets.Count(); i++)
        {
            targets[i].tag = "Collected";
            agente = targets[i].GetComponent<NavMeshAgent>();
            agente.enabled = true;
            agente.speed = 3.5f;
            agente.GetComponent<CapsuleCollider>().enabled = true;
            agente.SetDestination(vortex.transform.position);
            
        }

    }
    
}
