using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    public bool activateIt = false;
    public int reflections;
    public float tick;
    public Transform movingArrows;
    public float sec, min;

   // public ActivateAllRays rayActivater;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;
    private Vector3 movingArrowsStartPos;
    public float maxLength;

    public bool differentSceneTwo = false;


    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        /*if (rayActivater)
            activateIt = rayActivater.isActivateAllRays;*/

        if (activateIt)
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
                    Debug.Log(hit.point);
                    if (movingArrows != null)
                        movingArrows.position = Vector3.Reflect(ray.direction, hit.normal);
                    //Vector3.MoveTowards(movingArrows.position, lineRenderer.GetPosition(lineRenderer.positionCount), Time.deltaTime);

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
    }

    private void SlowDownTheLength()
    {
        sec += Time.deltaTime * tick;

        if (sec > 60)
        {
            min += 1 / 10f * Time.deltaTime;
            sec = 0;
        }

        if (min > maxLength) min = maxLength;
    }

    public void ShootUltraWave()
    {
        tick = 5000;
    }
}

