using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayCliente : MonoBehaviour
{
    Cliente clienteSide;
    [SerializeField]
    DejarCopa zonaCopa;
    bool haycliente=false;
    bool asignado = false;

    private void OnTriggerEnter(Collider other){
        Cliente cmp = other.gameObject.GetComponent<Cliente>();
        if (!haycliente&&cmp!= null) {
            haycliente = true;
            clienteSide = cmp;
            //INICIAR EL PEDIDO DEL CLIENTE
            Debug.Log("cliente en side");
            zonaCopa.setCoctel(cmp.GetComponent<Pedido>().GetCocteles());
            zonaCopa.setCliente(clienteSide);
        }
    }
    private void OnTriggerExit(Collider other){
        if(clienteSide!=null&&clienteSide.gameObject==other.gameObject){
            clienteSide=null;
            haycliente=false;
            setAsignado(false);
            zonaCopa.eliminarGenerated();
            zonaCopa.setCliente(clienteSide);
            Debug.Log("Desasignado: "+gameObject.name);
        }
    }
    public bool hayCliente() { return haycliente; }
    public bool Asignado() { return asignado; }
    public void setAsignado(bool act) { asignado = act; }
}
