using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTriangles : MonoBehaviour
{
    public GameObject liver;
    RaycastHit hitInfo;
    public float radius=5f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(liver.transform);
        

    }

    // Update is called once per frame
    void Update()
    {




        /*
        if (Physics.SphereCast(transform.position, 0.05f ,liver.transform.position-transform.position, out hitInfo, 20))
        {
            Debug.Log(""+hitInfo.triangleIndex);
            Debug.DrawLine(transform.position,hitInfo.point);
        }
        else
        {
            Debug.Log("Nothing");
        }  */
    }
    public void calfunc()
    {
        Mesh mesh = liver.GetComponent<MeshFilter>().mesh;
        Matrix4x4 localToWorld = transform.localToWorldMatrix;

        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            if (insideornot(transform.TransformPoint(vertices[i])))  //localToWorld.MultiplyPoint3x4(vertices[i])
            {
                colors[i] = new Color(199, 21, 133);
            }
            else
            {
                colors[i]=Color.red;
            }
        }
        liver.GetComponent<MeshFilter>().mesh.colors = colors;

    }
    bool insideornot(Vector3 point)
    {
        if ((Mathf.Pow((transform.position.x - point.x),2f) + Mathf.Pow((transform.position.y - point.y), 2f) + Mathf.Pow((transform.position.z - point.z), 2f) - Mathf.Pow(radius, 2)) < 0) {
            //Debug.Log(point);
            return true; 
        }
        else
        {
            return false;
        }
    }


}
