
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBeam
{
    private Vector3 pos, dir;
    public GameObject laserObj;
    private LineRenderer laser;
    private List<Vector3> _laserIndices = new List<Vector3>();

    public Vector3 RayPos;
    public Vector3 RayPos2;
    public Vector3 RayPos3;
    public Vector3 RayDir;

    public Vector3 dirForAngle;

    public float refrectedVectorOne, refractedVector2, reflectionVector;

    private Dictionary<string, float> refractiveMaterials = new Dictionary<string, float>()
    {
        {"Air", 1.0f},
        {"Glass", 1.5f}
    };

    public LaserBeam(Vector3 poss, Vector3 dirs, Material mat)
    {
        laser = new LineRenderer();
        laserObj = new GameObject();
        laserObj.name = "Laser Beam";

        this.pos = poss;
        this.dir = dirs;

        laser = laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = 0.005f;
        laser.endWidth = 0.005f;
        laser.material = mat;
        laser.startColor = Color.green;
        laser.endColor = Color.green;

        CastRays(pos, dir, laser);
    }

    private void CastRays(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        _laserIndices.Add(pos);

        var ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            _laserIndices.Add(ray.GetPoint(1));
            UpdateLaser();
        }
    }

    private void UpdateLaser()
    {
        var count = 0;
        laser.positionCount = _laserIndices.Count;
        foreach (var idx in _laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    private void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.tag == "S")
        {
            var pos = hitInfo.point;
            var dir = Vector3.Reflect(direction, hitInfo.normal);
            dirForAngle = dir;
            RayPos3 = hitInfo.point;
            reflectionVector = Vector3.Angle(dir, -direction);
            CastRays(pos, dir, laser);
        }
        else if (hitInfo.collider.tag == "N")
        {
            Vector3 pos = hitInfo.point;
            _laserIndices.Add(pos);
            Vector3 newPos = new Vector3(Mathf.Abs(direction.x) / Mathf.Abs(direction.x + 0.0001f) * 0.0001f + pos.x,
                Mathf.Abs(direction.y) / Mathf.Abs(direction.y + 0.0001f) * 0.0001f + pos.y,
                Mathf.Abs(direction.z) / Mathf.Abs(direction.z + 0.0001f) * 0.0001f + pos.z);

            float n1 = refractiveMaterials["Air"];
            float n2 = refractiveMaterials["Glass"];

            Vector3 norm = hitInfo.normal;
            Vector3 incedent = direction;

            Vector3 refrectedVector = Refract(n1, n2, norm, incedent);
            //Debug.Log(Vector3.Angle(refrectedVector, Vector3.forward) + " its One");

            refrectedVectorOne = Vector3.Angle(refrectedVector, -direction);
            RayPos = hitInfo.point;
            Ray ray1 = new Ray(newPos, refrectedVector);
            Vector3 newRayStartPoint = ray1.GetPoint(1.5f);

            Ray ray2 = new Ray(newRayStartPoint, -refrectedVector);
            RaycastHit hit2;

            if (Physics.Raycast(ray2, out hit2, 1.6f, 1))
            {
                _laserIndices.Add(hit2.point);
                
            }
            UpdateLaser();

            Vector3 refrectedVector2 = Refract(n2, n1, -hit2.normal, refrectedVector);
            RayPos2 = hit2.point;
            RayDir = refrectedVector2;
            // Debug.Log(Vector3.Angle(refrectedVector2, Vector3.forward) + " its Two");
            refractedVector2 = Vector3.Angle(refrectedVector2, -direction);
            CastRays(hit2.point, refrectedVector2, laser);
           
        }
        else
        {
            _laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }

    public static Vector3 Refract(float RI1, float RI2, Vector3 surfNorm, Vector3 incident)
    {
        surfNorm.Normalize(); //should already be normalized, but normalize just to be sure
        incident.Normalize();

        return (RI1 / RI2 * Vector3.Cross(surfNorm, Vector3.Cross(-surfNorm, incident)) - surfNorm *
            Mathf.Sqrt(1 - Vector3.Dot(Vector3.Cross(surfNorm, incident) * (RI1 / RI2 * RI1 / RI2),
                Vector3.Cross(surfNorm, incident)))).normalized;
    }
}