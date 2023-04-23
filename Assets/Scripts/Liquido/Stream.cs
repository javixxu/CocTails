using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    LineRenderer lineRenderer = null;
    Vector3 targetPosition = Vector3.zero;
    ParticleSystem splashParticle = null;
    Coroutine pourRoutine = null;

    private void Awake(){
        lineRenderer = GetComponent<LineRenderer>();
        splashParticle= GetComponentInChildren<ParticleSystem>();
    }

    private void Start(){
        MoveToPosition(0,transform.position);
        MoveToPosition(1,transform.position);
    }

    public void Begin(){
        StartCoroutine(UpdateParticles());
        pourRoutine = StartCoroutine(BeginPour());       
    }

    IEnumerator BeginPour(){
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();

            MoveToPosition(0, transform.position);
            AnimateToPosition(1, targetPosition);

            yield return null;
        }       
    }

    public void End(){
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    IEnumerator EndPour(){
        while (!HasReachedPosition(0, targetPosition)){
            AnimateToPosition(0,targetPosition);
            AnimateToPosition(1, targetPosition);
            yield return null;
        }
        Destroy(gameObject);
    }

    Vector3 FindEndPoint(){
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit,80.0f,~layerMask);
        Vector3 endPoint = hit.collider ? hit.point :ray.GetPoint(60.0f);
        return endPoint;
    }

    void MoveToPosition(int index,Vector3 targetPosition){
        lineRenderer.SetPosition(index,targetPosition);
    }

    void AnimateToPosition(int index, Vector3 targetPosition){
        Vector3 currentPoint = lineRenderer.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
        lineRenderer.SetPosition(index, newPosition);
    }

    bool HasReachedPosition(int index, Vector3 targetPosition){
        Vector3 curr= lineRenderer.GetPosition(index);
        return curr == targetPosition;
    }

    IEnumerator UpdateParticles(){
        while (gameObject.activeSelf)
        {
            splashParticle.gameObject.transform.position = targetPosition;
            bool isHitting = HasReachedPosition(1, targetPosition);
            splashParticle.gameObject.SetActive(isHitting);

            yield return null;
        }
    }
}
