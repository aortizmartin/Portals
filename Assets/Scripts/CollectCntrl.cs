using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CollectCntrl : MonoBehaviour
{
    public GameObject Gate;
    private NavMeshAgent Collectible;
    private Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        Collectible = GetComponent<NavMeshAgent>();
        animacion.SetBool("isRunning", false);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag: " + other.tag);
        if (other.tag == "Player")
        {
            if (!Collectible.hasPath)
            {
                Collectible.SetDestination(Gate.transform.position);
                NivelCntrl.encontrados += 1;
            }
          
            //Desactivamos el Halo al tocar al NPC
            Component halo = GetComponent("Halo"); 
            halo.GetType().GetProperty("enabled").SetValue(halo, false, null);

        }
        if (other.tag == "Collectible")
        {
            //Desactivamos Agent y Collider para evitar la animación de Running en la Wait Zone
            Collectible.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Collectible.hasPath)
        {
            if (Collectible.tag == "Collectible")
            {
                Collectible.speed = 10f;
            }
            else
            {
                Collectible.speed = 3.5f;
            }
            if (Collectible.remainingDistance <= 1)
            {
                    Collectible.speed = 3.5f;
            }
            animacion.SetBool("isRunning", true);
            
        }
        else
        {
            animacion.SetBool("isRunning", false);
        } 
    }
}
