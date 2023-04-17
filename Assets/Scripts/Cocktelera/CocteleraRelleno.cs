using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocteleraRelleno : MonoBehaviour{
    

    float percent; //PORCENTAJE DE LLENADO
    public float percentPerColision = 0.5f;// PORCENTAJE POR COLISION

    public int NumOnzasMaximas = 6; //NUMERO MAXIMO DE ONZAS Q LE PUEDES HECHAR A LA COCKTELERA


    public bool escalarX = false;
    public bool escalarY = true;
    public bool escalarZ = false;

    MeshRenderer meshRenderer;//LA MALLA DEL OBJECTO
    LiquidInSide liquid;
    Coctelera coctelera;

    Vector3 escalar = new Vector3();//mero uso en update no relevancia en nada
    public Vector3 finalTamMesh = new Vector3(1, 1, 1);

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
        liquid = GetComponentInParent<LiquidInSide>();
        coctelera= GetComponentInParent<Coctelera>();
        finalTamMesh = transform.localScale;
        reset();
    }
    private void OnParticleCollision(GameObject other){
        var cmp = other.GetComponentInParent<LiquidInSide>();
            //SI NO ESTA LLENA                   //SI NO ES NULO Y NI EL MISMO    //SI NO ES NULO               
        if (percent < 100f * NumOnzasMaximas && cmp != null && cmp != liquid && cmp.Inside != Liquid.NULL){
            LLENAR(cmp);
        }
    }
    public void LLENAR(LiquidInSide other)
    {
        if (!meshRenderer.enabled){
            meshRenderer.enabled = true; //percent = 30;
        } //si relleno con un lñiquido

        coctelera.Meterliquido(other.Inside,percentPerColision);//METO LIQUIDO EN EL MAP

        percent += percentPerColision;
        if (percent > 100f*NumOnzasMaximas) percent = 100f*NumOnzasMaximas;
        escalar = finalTamMesh;
        if (escalarX) escalar.x = finalTamMesh.x * (percent / (100f * NumOnzasMaximas));
        if (escalarY) escalar.y = finalTamMesh.y * (percent / (100f * NumOnzasMaximas));
        if (escalarZ) escalar.z = finalTamMesh.z * (percent / (100f * NumOnzasMaximas));
        transform.localScale = escalar;
        //Debug.Log("Percent: " + percent);
    }
    public void VACIAR()
    {
        percent -= percentPerColision * Time.deltaTime * 10;
        if (percent < 0) percent = 0;
        escalar = finalTamMesh;
        if (escalarX) escalar.x = finalTamMesh.x * (percent / (100f * NumOnzasMaximas));
        if (escalarY) escalar.y = finalTamMesh.y * (percent / (100f * NumOnzasMaximas));
        if (escalarZ) escalar.z = finalTamMesh.z * (percent / (100f * NumOnzasMaximas));
        transform.localScale = escalar;

        //Debug.Log("Vaciando: " + percent);
    }
    public void reset(){
        meshRenderer.enabled = false;
        liquid.Inside = Liquid.COCKTELERA;
        percent = 0;
    }
    public float getPercent() { return percent; }
    
}
