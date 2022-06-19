using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockRotation : MonoBehaviour
{
    [SerializeField] [Range(0, 8)] public int rotation;
    public int rotationNo;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(DockRotationAnimator());
    }

    void Update()
    {
        /*
        if(rotationNo != 0)
        {
            if(rotationNo > 0.5f)
            {
                anim.SetTrigger("TurnClockwise");
                rotation++;
                rotationNo = 0;
                
            } else
            {
                anim.SetTrigger("TurnCounterClockwise");
                rotation--;
                rotationNo = 0;
            }
        }
        */
        transform.eulerAngles = new Vector3(0, rotation * 45f, 0);
        
    }

    private IEnumerator DockRotationAnimator()
    {
        while (true)
        {
            if (rotationNo != 0)
            {
                if (rotationNo > 0.5f)
                {
                    anim.SetTrigger("TurnClockwise");
                    yield return new WaitForSeconds(Time.deltaTime * 2);
                    yield return new WaitForSeconds(0.6f);
                    rotationNo = 0;
                    rotation++;
                }
                else
                {
                    anim.SetTrigger("TurnCounterClockwise");
                    yield return new WaitForSeconds(Time.deltaTime * 2);
                    yield return new WaitForSeconds(0.6f);
                    rotation--;
                    rotationNo = 0;
                }
            }

            //transform.eulerAngles = new Vector3(0, rotation * 45f, 0);

            yield return null;
        }

    }
}
