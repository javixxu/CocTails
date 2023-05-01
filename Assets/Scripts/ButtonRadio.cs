using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using static Valve.VR.InteractionSystem.Hand;

public class ButtonRadio : MonoBehaviour
{
    public bool power;
    public Animator animator;
    Radio radio;
    bool isHandOver;
    void Start()
    {
        radio = GetComponentInParent<Radio>();
        isHandOver=false;
    }
    protected virtual void OnHandHoverBegin(Hand hand)
    {
        Debug.Log("BOTON PULSADO");
        animator.SetBool("Pulsado", true);
        int i = radio.index + 1;
        if (i > 3) i = 0;
        isHandOver = true;
        if (power)
        {
            radio.audioSource.Stop();
        }
        else
        {
            radio.index = i;
            radio.audioSource.clip = radio.songs[i];
            radio.audioSource.Play();
        }
    }


    //-------------------------------------------------
    protected virtual void OnHandHoverEnd(Hand hand)
    {
        isHandOver = false;
        animator.SetBool("Pulsado", false);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (/*other.gameObject.GetComponent<Hand>()!=null*/other.CompareTag("Hand"))
    //    {
    //        Debug.Log("BOTON PULSADO");
    //        if (power)
    //        {
    //            radio.audioSource.Stop();
    //        }
    //        else
    //        {
    //            int i = (radio.index + 1) % 4;
    //            radio.index = i;
    //            radio.audioSource.clip = radio.songs[i];
    //        }
    //    }
    //}
}
