using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotation : MonoBehaviour
{
    [SerializeField] [Range(0, 16)] public int rotation;
    public int rotationNo;

    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(MirrorRotationAnimator());
    }


    void Update()
    {
        transform.eulerAngles = new Vector3(0, rotation * 22.5f, 0);
    }

    private IEnumerator MirrorRotationAnimator()
    {
        while (true)
        {
            if (rotationNo != 0)
            {
                if (rotationNo > 0.5f)
                {
                    anim.SetTrigger("TurnClockwise");
                    yield return new WaitForSeconds(Time.deltaTime * 2);
                    yield return new WaitForSeconds(0.9f);
                    rotationNo = 0;
                    rotation++;
                }
                else
                {
                    anim.SetTrigger("TurnCounterClockwise");
                    yield return new WaitForSeconds(Time.deltaTime * 2);
                    yield return new WaitForSeconds(0.9f);
                    rotation--;
                    rotationNo = 0;
                }
            }

            //transform.eulerAngles = new Vector3(0, rotation * 45f, 0);

            yield return null;
        }

    }
}
