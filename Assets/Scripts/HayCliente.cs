using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayCliente : MonoBehaviour
{
    Cliente clienteSide;
    bool haycliente=false;
    
    private void OnTriggerEnter(Collider other){
        Cliente cmp = other.gameObject.GetComponent<Cliente>();
        if (haycliente&&cmp!= null) {
            haycliente = true;
            clienteSide = cmp;
            //INICIAR EL PEDIDO DEL CLIENTE
        }
    }
    private void OnTriggerExit(Collider other){
        if(clienteSide.gameObject==other.gameObject){
            //clienteSide=null;
            haycliente=false;
            //Llamar a generador de Cliente;
        }
    }
    public Cliente getCliente() { return clienteSide; }
    public bool hayCliente() { return haycliente; }
}
