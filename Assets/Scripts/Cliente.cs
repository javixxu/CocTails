using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Valve.Newtonsoft.Json.Serialization;

public class Cliente : MonoBehaviour{
    enum Pedido { Ansioso=0, Normal, Cansado }
    enum Estado { START=0,IENDO, ESPERANDO }

    HayCliente zona;
    Pedido estadoPedido;
    Estado estado;
    NavMeshAgent agent;
    // Start is called before the first frame update
    public void Start(){
        estado = new Estado();
        estadoPedido = new Pedido();
        agent=GetComponent<NavMeshAgent>();       
    }

    private void Update(){
        if (estado == Estado.IENDO){
            
        }
        else{
            if (estadoPedido == Pedido.Ansioso){

            }
            else if (estadoPedido == Pedido.Normal){

            }
            else{

            }
        }
    }

    public void setZonaCliente(HayCliente hayCliente) { zona=hayCliente;if (zona == null) Debug.Log("PUTA MIERDA"); }
    public void init(){
        estado = Estado.IENDO;
        agent.SetDestination(zona.transform.position);
    }
}
