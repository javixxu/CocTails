using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coctelera : MonoBehaviour{
    public Dictionary<Liquid, float> liquidosInSide = new Dictionary<Liquid, float>();
    CocteleraRelleno cocteleraRelleno;
    LiquidInSide liquid;
    [SerializeField]
    float percentField = 300.0f; //porcentaje minimo con el k se puede hechar liquido
    PourDetector detector;

    private void Start(){
        cocteleraRelleno=GetComponentInChildren<CocteleraRelleno>();
        liquid=GetComponent<LiquidInSide>();
        detector = GetComponent<PourDetector>();
        percentField = cocteleraRelleno.NumOnzasMaximas / 2 * 100;
    }
    void Update(){
        if (cocteleraRelleno.getPercent() > percentField){ //puedo hechar liquido
            detector.SetStop(false);
            if (detector.IsPouring()/*||detector.Current()!=null*/)
            { //si se esta vaciando vacio la malla
                cocteleraRelleno.VACIAR();
                if (cocteleraRelleno.getPercent() < percentField)//si esta lo suficientemente vacio, lo vacio del todo
                    cocteleraRelleno.reset();
            }
            
        }
        else{ //no puedo hechar liquido
            detector.SetStop(true);
            detector.SetPouring(false);
            detector.EndPourForzado();
            //Debug.Log("STOP");
        }
    }

    public void Meterliquido(Liquid type,float percentPerColision){
        if (liquidosInSide.ContainsKey(type))
            liquidosInSide[type] += percentPerColision;
        else 
            liquidosInSide.Add(type, percentPerColision);

        if (liquidosInSide[type] > 100f * cocteleraRelleno.NumOnzasMaximas) 
                liquidosInSide[type] = 100f * cocteleraRelleno.NumOnzasMaximas;

        Debug.Log("Percent " + type + ": " + liquidosInSide[type]);
    }

    private void OnParticleCollision(GameObject other){
        var cmp = other.GetComponentInParent<LiquidInSide>();
        //SI NO ESTA LLENA                   //SI NO ES NULO Y NI EL MISMO    //SI NO ES NULO               
        if (cocteleraRelleno.getPercent() < 100f * cocteleraRelleno.NumOnzasMaximas 
            && cmp != null && cmp != liquid && cmp.Inside != Liquid.NULL){
            cocteleraRelleno.LLENAR(cmp);
        }
    }
}
