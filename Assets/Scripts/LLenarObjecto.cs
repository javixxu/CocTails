using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLenarObjecto : MonoBehaviour
{
    // Start is called before the first frame update
    LiquidInSide liquid;
    LLenarMalla llenarMalla;
    void Start(){
        llenarMalla= GetComponentInChildren<LLenarMalla>();
        liquid= GetComponent<LiquidInSide>();
    }
    private void OnParticleCollision(GameObject other){
        var cmp = other.GetComponentInParent<LiquidInSide>();
        //SI NO ESTA LLENA                   //SI NO ES NULO Y NI EL MISMO    //SI NO ES NULO               
        if (llenarMalla.getPercent() < 100f && cmp != null && cmp != liquid && (liquid.Inside == Liquid.NULL || cmp.Inside == liquid.Inside)){
            llenarMalla.LLENAR(cmp);
        }
    }
}
