using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirClientes : MonoBehaviour{
    public GenerararClientes generar;
    private void OnTriggerEnter(Collider other){
        var cmp = other.GetComponent<Pedido>();
        if (cmp != null && cmp.getIrme()){
            Destroy(other.gameObject);
            Invoke("Generar",Random.Range(25,45));
        }
    }
    void Generar(){
        generar.generarUnCliente();
    }
}
