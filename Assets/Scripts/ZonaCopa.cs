using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ZonaCopa : MonoBehaviour{
    Copa miCopa;

    private void OnTriggerEnter(Collider other){
        var tipo = other.GetComponent<TipoObjecto>();
        if (tipo != null && miCopa.isValid(tipo.myType) && other.GetComponent<Interactable>().attachedToHand.ObjectIsAttached(other.gameObject))
        {         
            //other.transform.SetParent(miCopa.transform);
            //quitar el objecto de la lista
            miCopa.quitarTipo(tipo.myType);
            Debug.Log("Puesta:"+ tipo.myType);
            other.GetComponent<Interactable>().attachedToHand.DetachObject(other.gameObject);//desasocio el objecto de la mano
            Destroy(other.gameObject);
        }
    }   
    public void setCopa(Copa copa){
        this.miCopa = copa;
    }
}
