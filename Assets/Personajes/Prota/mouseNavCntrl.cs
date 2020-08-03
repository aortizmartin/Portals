using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mouseNavCntrl : MonoBehaviour
{
    public NavMeshAgent personaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetMouseButtonDown(0))
        {
            Vector3 raton = Input.mousePosition;
            Ray destino = Camera.main.ScreenPointToRay(raton);
            RaycastHit hit;
            if (Physics.Raycast(destino, out hit, Mathf.Infinity))
            {
                personaje.SetDestination(hit.point);
            }
        }
    }
}
