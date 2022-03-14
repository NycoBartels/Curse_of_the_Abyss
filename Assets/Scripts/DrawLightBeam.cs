using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLightBeam : MonoBehaviour
{
    [SerializeField] private float lightReach;
    [SerializeField] private GameObject lineRenderer;
    private (Vector3, Vector3) lightData;
    private Vector3 startPosition;
    private List<LineRenderer> lines = new List<LineRenderer>();


    private void Awake()
    {

    }

    void Start()
    {

        lightData = ReflectBeam(transform.position + transform.forward * 0.075f, transform.forward);
        startPosition = transform.position;

        
    }


    void Update()
    {

        lightData = ReflectBeam(lightData.Item1, lightData.Item2);
        print(startPosition);


    }


    private (Vector3, Vector3) ReflectBeam(Vector3 position, Vector3 direction)
    {
        
        Ray lightBeam = new Ray(position, direction * lightReach * Time.deltaTime);
        Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.blue);
        RaycastHit hit;


        if (Physics.Raycast(lightBeam, out hit))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
            Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.red);

            CreateLineRenderer(startPosition, hit.point);

            startPosition = hit.point;

            if (hit.transform.tag != "Mirror")
            {
                startPosition = transform.position;
                RemoveLineRenderers();

            } else
            {
                print("MY PRECIOUS");
            }

        } else
        {
            position += direction * lightReach * Time.deltaTime;
            Debug.DrawRay(position, direction * lightReach * Time.deltaTime, Color.yellow);
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
