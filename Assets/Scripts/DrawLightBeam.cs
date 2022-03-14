using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLightBeam : MonoBehaviour
{
    [SerializeField] private float lightReach;
    private (Vector3, Vector3) lightData;
    //private LineRenderer lineRenderer;
    private Vector3[] lightHitPoints;
    private int hitPointsNo = 0;




    void Start()
    {

        lightData = ReflectBeam(transform.position + transform.forward * 0.075f, transform.forward);
        //LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();

        //lightHitPoints[0] = transform.position;
        //lightHitPoints[1] = transform.position + transform.forward * 0.75f;

    }


    void Update()
    {

        lightData = ReflectBeam(lightData.Item1, lightData.Item2);
        //lineRenderer.SetPositions(lightHitPoints);



    }


    private (Vector3, Vector3) ReflectBeam(Vector3 position, Vector3 direction)
    {
        
        Ray lightBeam = new Ray(position, direction * lightReach);
        Debug.DrawRay(position, direction * lightReach, Color.blue);
        print(lightBeam);
        RaycastHit hit;


        if (Physics.Raycast(lightBeam, out hit))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            Debug.DrawRay(position, direction * lightReach, Color.red);
            //hitPointsNo++;

            //lightHitPoints[hitPointsNo +1] = position;

        } else
        {
            position += direction * lightReach;
            Debug.DrawRay(position, direction * lightReach, Color.yellow);
        }



        return (position, direction);
    }

}
