using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    bool isPouring = false;
    bool stop = false;
    Stream currentStream;

    [SerializeField]
    bool NoRotacion=false;

    private void Update(){
        if (stop) return;
        bool pourCheck = CalculatePourAngle() > pourThreshold;
        if(isPouring != pourCheck){
            isPouring = pourCheck;
            if (currentStream==null) 
                StartPour();
            else 
                EndPour();            
        }
        if (currentStream == null) isPouring = false;
        if(currentStream!= null) isPouring=true;
    }

    public void StartPour(){
        //Debug.Log("Start Pouring");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    public void EndPour(){
        if (currentStream==null) return;
        //Debug.Log("End Pouring");
        currentStream.End();
        currentStream= null;
    }

    public void EndPourForzado()
    {
        if (currentStream == null) return;
        Debug.Log("End Pouring");
        currentStream.End();
        currentStream = null;
    }

    float CalculatePourAngle(){
        //Debug.Log(Vector3.Angle(transform.forward, Vector3.up));        
       if(!NoRotacion) return Vector3.Angle(transform.forward, Vector3.up);
       else return Vector3.Angle(transform.up, Vector3.up);
    }

    Stream CreateStream(){
        GameObject streamObject= Instantiate(streamPrefab,origin.position,Quaternion.identity,transform);
        return streamObject.GetComponent<Stream>();
    }
    public void SetStop(bool stop) { this.stop= stop; }
    public void SetPouring(bool act) { isPouring = act; }
    public bool IsStop() { return stop; }
    public bool IsPouring() { return isPouring; }
   
    public Stream Current() { return currentStream; }
}