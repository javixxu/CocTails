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

    private void Update(){
        if (stop) return;
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        if(isPouring != pourCheck){
            isPouring = pourCheck;
            if (isPouring&&currentStream==null) 
                StartPour();
            else EndPour();            
        }
    }

   public void StartPour(){
        Debug.Log("Start Pouring");
        currentStream = CreateStream();
        currentStream.Begin();
    }

   public void EndPour(){
        if (!isPouring||currentStream==null) return;
        Debug.Log("End Pouring");
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
        return transform.forward.y * Mathf.Rad2Deg;
    }

    Stream CreateStream(){
        GameObject streamObject= Instantiate(streamPrefab,origin.position,Quaternion.identity,transform);
        return streamObject.GetComponent<Stream>();
    }
    public void setStop(bool stop) { this.stop= stop; }
    public bool isStop() { return stop; }
    public void ispouring(bool act){
        isPouring = act;
    }
}