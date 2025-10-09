
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastReflectionForSecScene : MonoBehaviour
{
    public int reflections;
    public float tick;
    public Transform movingArrows;
    public float sec, min;
    
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    private Vector3 movingArrowsStartPos;
    public float maxLength;
    public GameObject secRaycastObj;
    public bool oneAndOnly = true;
    public bool isMilkAdded;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
            SlowDownTheLength();
            ray = new Ray(transform.position, transform.forward);

            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);
            var remainingLength = min;

            for (var i = 0; i < reflections; i++)
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                    remainingLength -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    if (movingArrows != null)
                        movingArrows.position = Vector3.Reflect(ray.direction, hit.normal);
                    //Vector3.MoveTowards(movingArrows.position, lineRenderer.GetPosition(lineRenderer.positionCount), Time.deltaTime);

                    if (hit.collider.tag == "Salt" && oneAndOnly )
                    {
                        StartCoroutine(CastSecRay());
                        oneAndOnly = false;
                    }
                    if (hit.collider.tag != "S")
                        break;
                    
                }
                else
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1,
                        ray.origin + ray.direction * remainingLength);
                }

        
    }

    IEnumerator CastSecRay()
    {
        yield return new WaitForSeconds(0.1f);
        if (secRaycastObj != null && isMilkAdded)
        {
            secRaycastObj.SetActive(true);
        }
        
    }

    private void SlowDownTheLength()
    {
        sec += Time.deltaTime * tick;

        if (sec > 60)
        {
            min += 0.01f; /// 10f * Time.deltaTime;
            sec = 0;
        }

        if (min > maxLength) min = maxLength;
    }

    public void ShootUltraWave()
    {
        tick = 5000;
    }
}

