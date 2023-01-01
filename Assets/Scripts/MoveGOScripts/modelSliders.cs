using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class modelSliders : MonoBehaviour
{
    public GameObject bodyPart;
    public GameObject endLocation;
    private float previousvalue = 0;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Awake()
    {
         originalPos = bodyPart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderUpdated(SliderEventData eventData)
    {

        float step = 1.0f;// 0.2f * Time.deltaTime;
        Vector3 direction = bodyPart.transform.position - transform.parent.transform.position;
        bodyPart.transform.position = Vector3.Lerp(originalPos, 2*direction, eventData.NewValue);
        /*
        if (eventData.NewValue > previousvalue)
        {
            bodyPart.transform.position = Vector3.MoveTowards(bodyPart.transform.position, endLocation.transform.position * eventData.NewValue, step);
            previousvalue = eventData.NewValue;
        }
        else
        {
            if (eventData.NewValue == 0)
            {
                bodyPart.transform.position = Vector3.MoveTowards(bodyPart.transform.position, originalPos, step);
                previousvalue = eventData.NewValue;
            }
            else
            {
                bodyPart.transform.position = Vector3.MoveTowards(bodyPart.transform.position, originalPos * eventData.NewValue, step);
                previousvalue = eventData.NewValue;
            }
        } */

    }
}
