using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerararClientes : MonoBehaviour
{
    public List<HayCliente> sitiosClientes;
    private bool generar=false;
    [SerializeField]
    private int timeToStart = 10;
    [SerializeField]
    List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start(){
       // InvokeRepeating("changeGeneration",timeToStart,Random.Range(5,10));
        changeGeneration();
        Invoke("CanGenerate", 2);
    }    

    public void setGeneration(bool generar){
        this.generar= generar;
    }
    public void changeGeneration(){
        generar = !generar;
    }
    public void CanGenerate(){
        if (!generar) return;
        foreach(HayCliente obj in sitiosClientes){
            if (!obj.hayCliente()&&!obj.Asignado()){                
                generateCliente(obj);
                obj.setAsignado(true);
                Debug.Log("Asignado: " + obj.name);
                Invoke("CanGenerate", Random.Range(20,45));
                return;
            }
        }
    }
    public void generateCliente(HayCliente obj){
        GameObject gmb= Instantiate(prefabs[0], transform.position + new Vector3(0,5,0),Quaternion.identity);
        var cmp=gmb.GetComponent<Cliente>();
        cmp.setZonaCliente(obj);
        cmp.salir = GameObject.Find("Salir");
    }
    public void generarUnCliente(){
        foreach (HayCliente obj in sitiosClientes){
            if (!obj.hayCliente() && !obj.Asignado())
            {
                generateCliente(obj);
                obj.setAsignado(true);
                Debug.Log("Asignado: " + obj.name);
                return;
            }
        }
    }
}
