using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using static Pedido;

public class DejarCopa : MonoBehaviour{

    Cocteles miPedido;
    public List<GameObject> list;
    public GameObject dondeGenerar;
    GameObject objGenerated;
    Cliente cliente;
    Dictionary<Liquid, float> conf = new Dictionary<Liquid, float>();

    private GameObject obj;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }
    private void OnTriggerEnter(Collider other){
        var cmp = other.GetComponent<Copa>();
        if (miPedido != Cocteles.NULO && cmp!=null && cliente!=null){
            if (other.GetComponentInChildren<LLenarMalla>().getPercent() > 50){
                ResolucionDelPedido(cmp);
            }
            else Debug.Log("Es necesario rellenar la copa");
        }
    }
    public void setCoctel(Cocteles coctel){
        miPedido = coctel;
        conf.Clear();
        if (miPedido == Cocteles.BEACH){
            objGenerated = Instantiate<GameObject>(list[0], dondeGenerar.transform.position, dondeGenerar.transform.rotation);

            //CONFIGURACION
            conf.Add(Liquid.VODKA, 200);
            conf.Add(Liquid.LICOR_FRAMBUESA, 100);
            conf.Add(Liquid.LICOR_MELOCOTON, 100);
            conf.Add(Liquid.ZUMO_NARANJA, 100);
            conf.Add(Liquid.ZUMO_ARANDANOS, 100);
            //CONFIGURACION

        }
        else if (miPedido == Cocteles.DAIKIRI){
            objGenerated = Instantiate<GameObject>(list[1], dondeGenerar.transform.position, dondeGenerar.transform.rotation);

            //CONFIGURACION
            conf.Add(Liquid.RON, 200);
            conf.Add(Liquid.ZUMO_LIMA, 300);
            //CONFIGURACION

        }
        else{
            objGenerated = Instantiate<GameObject>(list[2], dondeGenerar.transform.position, dondeGenerar.transform.rotation);
            objGenerated.transform.position=
                new Vector3(objGenerated.transform.position.x,objGenerated.transform.position.y, 0.737f);

            //CONFIGURACION
            conf.Add(Liquid.VODKA, 100);
            conf.Add(Liquid.RON, 100);
            conf.Add(Liquid.GIN, 100);
            conf.Add(Liquid.ZUMO_ARANDANOS, 300);
            //CONFIGURACION

        }
    }
    public void eliminarGenerated(){
        Destroy(objGenerated);
    }
    public void ResolucionDelPedido(Copa copa){
        float percentBueno = 0;bool clavao = true;
        if (copa.cosasQueActivar.Count == 0) percentBueno = 20.0f;
        else if (copa.cosasQueActivar.Count < 1) { percentBueno = 10.0f; clavao = false; }
        else { percentBueno = 5.0f; clavao = false; }

        foreach(var it in conf){
            if (copa.liquidosInSide.ContainsKey(it.Key)){
                if (Mathf.Abs( it.Value - copa.liquidosInSide[it.Key])<35.0){
                    percentBueno += 15;
                }
                else{
                    percentBueno += 5;
                    clavao = false;
                }
            }
        }

        float rnd=Random.RandomRange(0, 100);

        if (rnd < percentBueno){
            Debug.Log("Bueno");
            if (miPedido == Cocteles.BEACH) gameManager.AddPoints(210);
            else if (miPedido == Cocteles.LIMA) gameManager.AddPoints(150);
            if (miPedido == Cocteles.DAIKIRI) gameManager.AddPoints(55);
        }
        else{
            Debug.Log("Malo");
            if (miPedido == Cocteles.BEACH) gameManager.AddPoints(-100);
            else if (miPedido == Cocteles.LIMA) gameManager.AddPoints(-75);
            if (miPedido == Cocteles.DAIKIRI) gameManager.AddPoints(-46);
        }
        gameManager.UpdatePoints();
        obj = copa.gameObject;
        Invoke("salirme", 1.0f);
    }
   public void setCliente(Cliente cliente) { this.cliente = cliente; }
    public void salirme(){
        desactivar();
        cliente.irme();
        cliente.GetComponent<Pedido>().activar(false);
    }
    void desactivar(){
        if (obj.GetComponent<Interactable>().attachedToHand.ObjectIsAttached(obj)){
            obj.GetComponent<Interactable>().attachedToHand.DetachObject(obj);
        }
    }
}
