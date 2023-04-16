using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedido : MonoBehaviour
{
    public enum EstadoPedido { Bien = 0, Medio, Mal }
    public enum Cockteles { NULO = 0, BEACH = 1, NOMBRE2 = 2, NOMBRE3 = 3 }

    EstadoPedido estado=EstadoPedido.Bien;
    Cockteles tipoCocktel=Cockteles.NULO;

    float esperandoPedido = 0.0f;
    public float MaxTimePedidoEsperando = 60;

    public  List<Color> colorEstado;
    public List<Sprite> spritesCocktails;
    public Image imagenComic;
    public Image imagenCocktail;

    bool servido=false;
    bool irme=false;

    Cliente cliente;

    private void Start(){
        cliente = GetComponentInParent<Cliente>();
        activar(false);
    }

    private void Update(){
        if (irme||cliente.GetEstado()==Cliente.Estado.IENDO) return;
        esperandoPedido += Time.deltaTime;

        if(servido||esperandoPedido / MaxTimePedidoEsperando >= 1.0){
            irme=true;
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
            tipoCocktel = Cockteles.BEACH;
            imagenCocktail.sprite = spritesCocktails[0];
            Debug.Log("BEACH1");
        }
        else if (rnd == 2)
        {
            tipoCocktel = Cockteles.NOMBRE2;
            imagenCocktail.sprite = spritesCocktails[1];
            Debug.Log("BEACH2");
        }
        else
        {
            tipoCocktel = Cockteles.NOMBRE3;
            imagenCocktail.sprite = spritesCocktails[2];
            Debug.Log("BEACH3");
        }
    }
    public void activar(bool act){
        imagenComic.enabled= act;
        imagenCocktail.enabled= act;
    }
    public bool getIrme() { return irme; }
}
