using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCntrl : MonoBehaviour
{
    //Controla el movimiento del jugador con el Mouse y su aparición en la escena
    private Camera cam;
    public NavMeshAgent jugador;
    private Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        animacion = GetComponent<Animator>();
        animacion.SetBool("isRunning", false);
        if (NivelCntrl.nivel > 0)
        {
            StartCoroutine(esperaVisible());
        }
        else { this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true; }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 raton = Input.mousePosition;
            //Ray rayo = cam.ScreenPointToRay(raton);
            Ray rayo = Camera.main.ScreenPointToRay(raton);
            RaycastHit hit;
            if(Physics.Raycast(rayo, out hit, Mathf.Infinity))
            {
                jugador.SetDestination(hit.point);
                jugador.speed = 10;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            jugador.speed = 0;
            jugador.SetDestination(jugador.transform.position);
        }
        if (Input.GetMouseButtonUp(0))
        {
            jugador.speed = 3.5f;
        }
        if (jugador.hasPath)
        {
            animacion.SetBool("isRunning", true);
        }
        else
        {
            animacion.SetBool("isRunning", false);
        }


    }
    IEnumerator esperaVisible()
    {
        //Espera hasta la mitad de la animación de los anillos para mostrar al jugador
        yield return new WaitForSeconds(1.6f);
        this.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
    }
}
