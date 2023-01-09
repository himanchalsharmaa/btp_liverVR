using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

public class cameramovement : MonoBehaviour
{
    private Vector3 destination1;
    private Vector3 destination2;
    public TMP_Text inpurcheck;
    public GameObject sliderValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        Vector2 leftright = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        SliderValueObtain sliderValueObtain = sliderValue.GetComponent<SliderValueObtain>();
        float magnitude = sliderValueObtain.maginitude;
        if (magnitude == 0)
        {
            magnitude = 1/3;
        }

        //transform.rotation = Quaternion.LookRotation(transform.forward);
        //Vector3 destination1=transform.position+leftright.x;
        if (leftright.x != 0 || leftright.y != 0)
        {
            float a = Mathf.Abs(leftright.y);
            a *= magnitude;
            float b = Mathf.Abs(leftright.x);
            b *= magnitude;
          //  inpurcheck.text = a + ":" + b;
            if (leftright.y > 0)
            {
                destination1 = transform.position + a * transform.forward;
            }
            else if (leftright.y < 0)
            {
                destination1 = transform.position - a * transform.forward;
            }
            transform.position = Vector3.Lerp(transform.position, destination1, 0.05f);
            if (leftright.x > 0)
            {
                //obj1.transform.rotation=Quaternion.FromToRotation(Vector3.up, transform.forward);
                //obj2.transform.rotation=Quaternion.FromToRotation(Vector3.up,Vector3.Cross(transform.forward,new Vector3(0,transform.position.y,0)));
                //obj3.transform.rotation=Quaternion.FromToRotation(Vector3.up,Vector3.Cross(transform.forward,new Vector3(0,transform.position.y,0)));
                //inpurcheck.text=""+Quaternion.Angle(obj1.transform.rotation,obj2.transform.rotation);
                destination2 = transform.position - b * Vector3.Normalize(Vector3.Cross(transform.forward, new Vector3(0, Mathf.Abs(transform.position.y), 0)));
            }
            else if (leftright.x < 0)
            {
                //obj1.transform.rotation=Quaternion.FromToRotation(Vector3.up, transform.forward);
                //obj2.transform.rotation=Quaternion.FromToRotation(Vector3.up,Vector3.Cross(transform.forward,new Vector3(0,transform.position.y,0)));
                //obj3.transform.rotation=Quaternion.FromToRotation(Vector3.up,Vector3.Cross(transform.forward,new Vector3(0,transform.position.y,0)));
                //inpurcheck.text=""+Quaternion.Angle(obj1.transform.rotation,obj2.transform.rotation);
                destination2 = transform.position + b * Vector3.Normalize(Vector3.Cross(transform.forward, new Vector3(0, Mathf.Abs(transform.position.y), 0)));
            }
            transform.position = Vector3.Lerp(transform.position, destination2, 0.05f);
        }
        Vector2 updown = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 destination3 = new Vector3(transform.position.x, transform.position.y + updown.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, destination3, 0.05f*magnitude);
        transform.Rotate(0, updown.x, 0, Space.World);
    }
}
