using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class patchLiver : MonoBehaviour
{
    public GameObject liver;
    public int patchdivision ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeColor()
    {
        int a = 0;
        Mesh mesh = liver.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Debug.Log(vertices.Length);
        // create new colors array where the colors will be created.
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
            else { 
            colors[i] = Color.white;//Color.Lerp(Color.red, Color.green, vertices[i].y);
            }
        }
        //Debug.Log("Done coloring: "+cpu);
        // assign the array of colors to the Mesh.
        mesh.colors = colors;
        liver.GetComponent<MeshFilter>().mesh = mesh;
    }
}
