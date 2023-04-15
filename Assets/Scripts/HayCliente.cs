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
            Debug.Log("cliente en side");
        }
    }
    private void OnTriggerExit(Collider other){
        if(clienteSide!=null&&clienteSide.gameObject==other.gameObject){
            clienteSide=null;
            haycliente=false;
            //Llamar a generador de Cliente;
            //que el cliente salga del local y se elimine
        }
    }
    public Cliente getCliente() { return clienteSide; }
    public bool hayCliente() { return haycliente; }
}
