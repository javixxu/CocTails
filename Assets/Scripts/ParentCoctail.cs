using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ParentCoctail : MonoBehaviour
{
    public List<Transform> hijos;
    // Start is called before the first frame update    
    private void Update(){
        foreach (Transform t in hijos){
            Hand aux = t.gameObject.GetComponent<Interactable>().attachedToHand;
            if (t.gameObject.GetComponent<Interactable>().attachedToHand==null||!aux.ObjectIsAttached(t.gameObject)){
                t.SetParent(transform);
            }
        }
    }
}
