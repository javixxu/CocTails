using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Copa : MonoBehaviour{

    public List<ZonaCopa> colocar;
    Dictionary<TypeObecto, int> listCosas= new Dictionary<TypeObecto,int>();
    void Start(){
        foreach(var cmp in colocar){
            cmp.setCopa(this);
        }
        Beach();
    }       
    public void remove(ZonaCopa cmp){
        colocar.Remove(cmp);
    }
    public void quitarTipo(TypeObecto tipo){
        listCosas[tipo]--;
    }
    public void devolverTipo(TypeObecto tipo){
        listCosas[tipo]++;
    }
    public bool isValid(TypeObecto tipo){
        foreach(var cmp in listCosas) {
            if (cmp.Key == tipo&&cmp.Value>0) 
                return true;
        }
        return false;
    }
    public bool exist(TypeObecto tipo){
        foreach (var cmp in listCosas){
            if (cmp.Key == tipo)
                return true;
        }
        return false;
    }
    public void Daikiri(){
        
    }
    public void Beach(){
        listCosas.Add(TypeObecto.Naranja, 1);
        listCosas.Add(TypeObecto.Cereza, 1);
        listCosas.Add(TypeObecto.Hielo, 2);
    }
    public void Lima(){

    }

}
