using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerararClientes : MonoBehaviour
{
    public List<HayCliente> sitiosClientes;
    private bool generar=false;
    [SerializeField]
    private int timeToStart = 60;
    [SerializeField]
    List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("changeGeneration",timeToStart);
        CanGenrate();
    }    

    public void setGeneration(bool generar){
        this.generar= generar;
    }
    public void changeGeneration(){
        generar = !generar;
    }
    public void CanGenrate(){
        foreach(HayCliente obj in sitiosClientes){
            if (!obj.hayCliente()){                
                generateCliente(obj);
            }
        }
    }
    public void generateCliente(HayCliente obj){
        GameObject gmb= Instantiate(prefabs[0], transform.position+ new Vector3(0,5,0),Quaternion.identity);
        var cmp=gmb.GetComponent<Cliente>();
        cmp.Start();
        cmp.setZonaCliente(obj);
        cmp.init();
    }
}
