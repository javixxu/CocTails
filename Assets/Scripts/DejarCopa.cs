using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pedido;

public class DejarCopa : MonoBehaviour{

    Cocteles miPedido;
    public List<GameObject> list;
    public GameObject dondeGenerar;
    private void OnTriggerEnter(Collider other){
        var cmp = other.GetComponent<Copa>();
        if (miPedido != Cocteles.NULO&&cmp!=null){

        }
    }
    public void setCoctel(Cocteles coctel){
        miPedido = coctel;
        if (miPedido == Cocteles.BEACH){
            Instantiate<GameObject>(list[0], dondeGenerar.transform.position, dondeGenerar.transform.rotation);
        }
        else if (miPedido == Cocteles.DAIKIRI){
            Instantiate<GameObject>(list[1], dondeGenerar.transform.position, dondeGenerar.transform.rotation);
        }
        else{
            Instantiate<GameObject>(list[2], dondeGenerar.transform.position, dondeGenerar.transform.rotation);
        }
    }
}
