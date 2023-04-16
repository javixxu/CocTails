using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Valve.Newtonsoft.Json.Serialization;
using Valve.VR.InteractionSystem;
using static Pedido;

public class Cliente : MonoBehaviour{
    public enum Estado { START=0,IENDO, ESPERANDO,SALIENDO }

    Animator animator;
    HayCliente zona;
    NavMeshAgent agent;
    Pedido pedido;

    Estado estado;

    public GameObject salir;

    // Start is called before the first frame update
    public void Start(){
        estado = new Estado();

        agent=GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        pedido= GetComponent<Pedido>();

        init();
    }

    private void Update(){
        if (estado == Estado.IENDO){
            if ((transform.position - zona.transform.position).magnitude<0.5) { 
                agent.Stop();
                agent.enabled = false;
                animator.StopPlayback();                
                estado = Estado.ESPERANDO;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.position = zona.transform.position;
                pedido.generarPedido();
                pedido.activar(true);
            }
        }      
    }

    public void setZonaCliente(HayCliente hayCliente) {
        zona=hayCliente;
        if (zona == null) Debug.Log("ZONA CLIENTE NULL"); 
    }
    public void init(){
        estado = Estado.IENDO;
        agent.enabled= true;
        agent.ResetPath();
        agent.SetDestination(zona.transform.position);
    }
    public void irme(){
        agent.enabled = true;
        agent.SetDestination(salir.transform.position);
    }
    public Estado GetEstado() { return estado; }
}
