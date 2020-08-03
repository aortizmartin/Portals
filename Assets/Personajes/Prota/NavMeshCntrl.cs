using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCntrl : MonoBehaviour
{
    public GameObject posicFinal; 
    public NavMeshAgent personajeNav;
    //public Transform posicFinal;
    private float radio;
    private float timer;
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        posicFinal = GetComponent<GameObject>(); 
        personajeNav = GetComponent<NavMeshAgent>();
        //posicFinal = GetComponent<Transform>();
        count = timer;
    }

    // Update is called once per frame
    void Update()
    {
        personajeNav.SetDestination(posicFinal.transform.position);
    }
}
