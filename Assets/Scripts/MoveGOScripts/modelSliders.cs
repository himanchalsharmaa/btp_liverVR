using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class modelSliders : MonoBehaviour
{
    public GameObject bodyPart;
    public GameObject endLocation;
    public GameObject playspaceCam;
    private float previousvalue = 0;
    Vector3 oPos;
    // Start is called before the first frame update
    void Awake()
    {
      //   originalPos = bodyPart.transform.position;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSliderUpdated(SliderEventData eventData)
    {
        float step = 1.0f;// 0.2f * Time.deltaTime;
        Vector3 direction = playspaceCam.transform.position - bodyPart.transform.position;
        oPos = bodyPart.transform.position;
        //bodyPart.transform.position = Vector3.Lerp(originalPos, 2*direction, eventData.NewValue);

        if (eventData.NewValue > previousvalue)
        {
            bodyPart.transform.position = Vector3.Lerp(oPos, 2*direction, 0.08f*eventData.NewValue);
            previousvalue = eventData.NewValue;
        }
        else if(eventData.NewValue < previousvalue)
        {
            if (eventData.NewValue != 0)
            {
                Vector3 gobackdirection = endLocation.transform.position - bodyPart.transform.position;
                bodyPart.transform.position = Vector3.Lerp(oPos, 2*gobackdirection, 0.8f * (eventData.NewValue));
                previousvalue = eventData.NewValue;
            }
            if(eventData.NewValue == 0 && previousvalue < 0.05f)
            {
                bodyPart.transform.position = endLocation.transform.position;
            }
        } 

    }
}
