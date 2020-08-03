using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class VigiaCntrl : MonoBehaviour
{
    public GameObject[] wayPoints;
    private NavMeshAgent agente;

    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        int aleatorio = Random.Range(0, wayPoints.Count());
        Debug.Log(aleatorio);
        agente.SetDestination(wayPoints[aleatorio].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //int zona = agente.areaMask;
        //Debug.Log("zona " + zona);
        if (Input.GetKeyDown("z"))
        {
            agente.SetAreaCost(4, 1);
            agente.SetDestination(wayPoints[0].transform.position);
            agente.speed = 10;
        }
        if (agente.remainingDistance <= .1)
        {
            agente.speed = 4;
            int aleatorio = Random.Range(0, wayPoints.Count());
            Debug.Log(aleatorio);
            agente.SetAreaCost(4, 10);
            agente.SetDestination(wayPoints[aleatorio].transform.position);

        }else if (agente.hasPath)
        {
            Vector3 destino = agente.steeringTarget - this.transform.position;
            float giro = Vector3.Angle(this.transform.forward, destino);
        }
       
    }
}
