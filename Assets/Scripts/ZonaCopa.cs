using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ZonaCopa : MonoBehaviour{
    Copa miCopa;
    private void OnTriggerEnter(Collider other){
        var tipo = other.GetComponent<TipoObjecto>();
        if (tipo != null && miCopa.isValid(tipo.myType)){         
            other.transform.SetParent(miCopa.transform);
            //quitar el objecto de la lista
            miCopa.quitarTipo(tipo.myType);
            Debug.Log("Puesta:"+ tipo.myType);
        }
    }
    private void OnTriggerExit(Collider other){
        var tipo = other.GetComponent<TipoObjecto>();
        if (tipo != null && miCopa.exist(tipo.myType)){
            other.transform.SetParent(null);
            //quitar el objecto de la lista
            miCopa.devolverTipo(tipo.myType);
            Debug.Log("Quitada:" + tipo.myType);
        }
    }
    public void setCopa(Copa copa){
        this.miCopa = copa;
    }
   
}
