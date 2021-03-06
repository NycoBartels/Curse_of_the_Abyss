using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrawLightBeam : MonoBehaviour
{
    [SerializeField] private float lightReach;
    [SerializeField] private GameObject lineRenderer;
    [SerializeField] private int maxlineRenderers;

    private (Vector3, Vector3) lightData;
    private Vector3 startPosition;
    private Vector3 lastWallHit;
    private List<LineRenderer> lines = new List<LineRenderer>();

    [SerializeField]
    private List<Transform> selectedTriggers = new List<Transform>();
    public static Action<int, int> callPuzzleManager;

    [SerializeField]
    private int laserID;

    private void Awake()
    {

    }

    void Start()
    {
        startPosition = transform.position;

        //Creates initial raycast
        lightData = ReflectBeam(transform.position + transform.forward * 0.075f, transform.forward);
    }


    void FixedUpdate()
    {
        //Creates new raycast
        lightData = ReflectBeam(lightData.Item1, lightData.Item2);
        //print(startPosition);


    }


    private (Vector3, Vector3) ReflectBeam(Vector3 position, Vector3 direction)
    {

        //Create Ray at position in direction, draw ray, record hitData
        Ray lightBeam = new Ray(position, direction * lightReach * Time.deltaTime);
        //Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.blue);
        RaycastHit hit;

        
        if(Physics.Raycast(lightBeam, out hit) && hit.transform.tag == "Mirror") //If the ray hits a mirror
        {
            TriggerActivate triggerScript = hit.transform.GetComponent<TriggerActivate>();

            if (triggerScript != null)
            {
                if (!selectedTriggers.Contains(hit.transform))
                {
                    selectedTriggers.Add(hit.transform);
                    callPuzzleManager?.Invoke(laserID, selectedTriggers.Count);
                }
            }

            //Create a normal direction for the next ray
            direction = Vector3.Reflect(direction, hit.normal);
            //Create starting position for the next ray
            position = hit.point;

            //Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.red);

            //Draw the lightbeam for this ray at previous last hitPoint to current hitPoint
            CreateLineRenderer(startPosition, hit.point);

            //Reset current hitPoint to future starting point
            startPosition = hit.point;

        } else if (Physics.Raycast(lightBeam, out hit)) //If the ray hits something other than a mirror
        {

            if (lastWallHit != hit.point) //If the ray does not hit the same spot on the wall AKA if something has moved
            {
                //Clear the LineRenderers
                RemoveLineRenderers();

                //Reset the ray to the dock.
                lastWallHit = hit.point;
                startPosition = transform.position;
                return (transform.position, transform.forward);

                
            } else
            {
                //Cast a ray from the lightdock without drawing linerenderers
                CreateLineRenderer(startPosition, hit.point);

                startPosition = transform.position;
                return (transform.position, transform.forward);


            }

        } else
        {

            position += direction * lightReach * Time.deltaTime;
            //Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.yellow);
        }



        return (position, direction);

        
    }





    private void CreateLineRenderer(Vector3 start, Vector3 end)
    {   
        GameObject lr = Instantiate(lineRenderer, startPosition, Quaternion.identity);
        LineRenderer LR = lr.GetComponent<LineRenderer>();

        LR.SetPosition(0, start);
        LR.SetPosition(1, end);

        lines.Add(LR);

        if (lines.Count > maxlineRenderers)
        {
            //print("too loooooong");

            Destroy(lines[0].gameObject);
            lines.RemoveAt(0);
            
        }

    }

    private void RemoveLineRenderers()
    {
        foreach(LineRenderer lr in lines)
        {
            Destroy(lr.gameObject);
        }

        lines.Clear();
    }

}
