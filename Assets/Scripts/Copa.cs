using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copa : MonoBehaviour{

    public ZonaCopa colocar;  
    public List<TipoObjecto> cosasQueActivar;
    public Dictionary<Liquid, float> liquidosInSide = new Dictionary<Liquid, float>();
    void Start(){        
        colocar.setCopa(this);        
    }       
    
    public void quitarTipo(TypeObecto tipo){
        foreach(TipoObjecto go in cosasQueActivar){
            if (go.myType == tipo){
                go.gameObject.SetActive(true);
                cosasQueActivar.Remove(go);
                return;
            }
        }              
    }
    public bool isValid(TypeObecto tipo){
        foreach (TipoObjecto go in cosasQueActivar){
            if (go.myType == tipo) 
                return true;
        }
        return false;
    }   
    public void setLiquidos(Dictionary<Liquid, float> liquidosInSide) { 
        this.liquidosInSide = liquidosInSide; 
    }
}
