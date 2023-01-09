using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class enzymevalueslider : MonoBehaviour
{
    public GameObject gallBladder;
    public GameObject liver;
    Color[] livercolor;
    Vector3 scal;
    // Start is called before the first frame update
    void Start()
    {
        scal = gallBladder.transform.localScale;
        Debug.Log(scal);
        livercolor = liver.GetComponent<MeshFilter>().mesh.colors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSliderUpdated(SliderEventData eventData)
    {
        if (eventData.NewValue != 0)
        {
            if (eventData.NewValue > 0.5)
            {
                gallBladder.transform.localScale = scal * (1 + eventData.NewValue);
            }
            else if (eventData.NewValue < 0.35)
            {
                int patchdivision = (int)(100 * (eventData.NewValue));
                patchLiver(patchdivision);
            }
            else
            {
                liver.GetComponent<MeshFilter>().mesh.colors = livercolor;
                gallBladder.transform.localScale = scal;
            }
        }
    }
    void patchLiver(int patchdivision)
    {
        int a = 0;
        Mesh mesh = liver.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];
        System.Random r = new System.Random();
        int rInt = r.Next(1, 2);
        for (int i = 0; i < vertices.Length; i++)
        {
            a++;
            if (a % patchdivision == 0)
            {
                for (int j = i; j < i + rInt; j++)
                {
                    if (j < vertices.Length)
                    {
                        colors[j] = new Color(199, 21, 133);
                    }
                    else
                    {
                        break;
                    }
                    i = j;
                }
                rInt = r.Next(1, 2);
                a = 0;
            }
            else
            {
                colors[i] = Color.white;
            }
        }
        mesh.colors = colors;
        liver.GetComponent<MeshFilter>().mesh = mesh;
    }

}
