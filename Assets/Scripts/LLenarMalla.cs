using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pedido;
using static Unity.Burst.Intrinsics.X86.Avx;

public class LLenarMalla : MonoBehaviour{
    float percent; //PORCENTAJE DE LLENADO
    public float percentPerColision = 0.5f;// PORCENTAJE POR COLISION

    public bool escalarX = false;
    public bool escalarY = true;
    public bool escalarZ = false;

    MeshRenderer meshRenderer;//LA MALLA DEL OBJECTO
    LiquidInSide liquid;

    Vector3 escalar = new Vector3();//mero uso en update no relevancia en nada
    public Vector3 finalTamMesh = new Vector3(1, 1, 1);

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
        liquid = GetComponentInParent<LiquidInSide>();
        finalTamMesh = transform.localScale;

        meshRenderer.enabled = false;
        percent = 0;
    }
    private void OnParticleCollision(GameObject other){
        var cmp = other.GetComponentInParent<LiquidInSide>();
        if (cmp != null && cmp != liquid && (liquid.Inside==Liquid.NULL||cmp.Inside==liquid.Inside)){
            LLENAR(cmp);
        }    
    }
    public void LLENAR(LiquidInSide other){
        if (!meshRenderer.enabled){
            meshRenderer.enabled = true; percent = 30; liquid.Inside = other.Inside;
        } //si relleno con un lñiquido            
        percent += percentPerColision;
        if (percent > 100f) percent = 100f;
        escalar = finalTamMesh;
        if (escalarX) escalar.x = finalTamMesh.x * (percent / 100f);
        if (escalarY) escalar.y = finalTamMesh.y * (percent / 100f);
        if (escalarZ) escalar.z = finalTamMesh.z * (percent / 100f);
        transform.localScale = escalar;
        Debug.Log("LLenar: " + percent);
    }
    public void VACIAR(){
        percent -= percentPerColision * Time.deltaTime*12;
        if (percent < 0) percent = 0;
        escalar = finalTamMesh;
        if (escalarX) escalar.x = finalTamMesh.x * (percent / 100f);
        if (escalarY) escalar.y = finalTamMesh.y * (percent / 100f);
        if (escalarZ) escalar.z = finalTamMesh.z * (percent / 100f);
        transform.localScale = escalar;        

        //Debug.Log("Vaciando: " + percent);
    }
    public void reset(){
        meshRenderer.enabled = false;        
        liquid.Inside = Liquid.NULL;
        percent = 0;
    }
    public float getPercent() { return percent; }
}
