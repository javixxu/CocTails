using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaciarMalla : MonoBehaviour{
    public float percentField=5.0f; //porcentaje minimo con el k se puede hechar liquido
    LLenarMalla llenarMalla;
    PourDetector detector;

    void Start(){
        detector=GetComponent<PourDetector>();
        llenarMalla=GetComponentInChildren<LLenarMalla>();       
    }

    void Update(){
        if(llenarMalla.getPercent() > percentField) { //puedo hechar liquido
            detector.SetStop(false);
            if(detector.IsPouring()/*||detector.Current()!=null*/){ //si se esta vaciando vacio la malla
                llenarMalla.VACIAR();
                if(llenarMalla.getPercent() < percentField)//si esta lo suficientemente vacio, lo vacio del todo
                    llenarMalla.reset();
            }
        }
        else{ //no puedo hechar liquido
            detector.SetStop(true);
            detector.SetPouring(false);
            detector.EndPourForzado();
            //Debug.Log("STOP");
        }
    }
}
