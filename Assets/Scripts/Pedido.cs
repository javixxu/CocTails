using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedido : MonoBehaviour
{
    public enum EstadoPedido { Bien = 0, Medio, Mal }
    public enum Cocteles { NULO = 0, BEACH = 1, DAIKIRI = 2, LIMA = 3 }

    EstadoPedido estado=EstadoPedido.Bien; 
    Cocteles tipoCocktel=Cocteles.NULO;

    float esperandoPedido = 0.0f;
    public float MaxTimePedidoEsperando = 60;

    public  List<Color> colorEstado;
    public List<Sprite> spritesCocktails;
    public Image imagenComic;
    public Image imagenCocktail;

    bool servido=false;

    Cliente cliente;
    GameManager gameManager;
    private void Start(){
        gameManager = GameManager.GetInstance();
        cliente = GetComponentInParent<Cliente>();
        activar(false);
    }

    private void Update(){
        if (cliente.GetEstado()==Cliente.Estado.SALIENDO || cliente.GetEstado()==Cliente.Estado.IENDO) return;
        esperandoPedido += Time.deltaTime;

        if(servido||esperandoPedido / MaxTimePedidoEsperando >= 1.0){

            if (tipoCocktel == Cocteles.BEACH) gameManager.AddPoints(-100);
            else if (tipoCocktel == Cocteles.LIMA) gameManager.AddPoints(-75);
            if (tipoCocktel == Cocteles.DAIKIRI) gameManager.AddPoints(-46);
            gameManager.UpdatePoints();
            cliente.irme();
            activar(false);
        }   
        else if (esperandoPedido / MaxTimePedidoEsperando < 0.33){ //Rojo
            imagenComic.color = colorEstado[2];
        }
        else if (esperandoPedido / MaxTimePedidoEsperando < 0.66){ //Naranja
            imagenComic.color = colorEstado[1];
        }
        else{ //verde
            imagenComic.color = colorEstado[0];
        }
    }

    public void generarPedido()
    {
        int rnd = Random.Range(1, 4);
        if (rnd == 1)
        {
            tipoCocktel = Cocteles.BEACH;
            imagenCocktail.sprite = spritesCocktails[0];
            //Debug.Log("BEACH");
        }
        else if (rnd == 2)
        {
            tipoCocktel = Cocteles.DAIKIRI;
            imagenCocktail.sprite = spritesCocktails[1];
            //Debug.Log("DAIKIRI");
        }
        else
        {
            tipoCocktel = Cocteles.LIMA;
            imagenCocktail.sprite = spritesCocktails[2];
            //Debug.Log("LIMAA");
        }
        
    }
    public void activar(bool act){
        imagenComic.enabled= act;
        imagenCocktail.enabled= act;
    }
    public Cocteles GetCocteles() { return tipoCocktel; }
}
