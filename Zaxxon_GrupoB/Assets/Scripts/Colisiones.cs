using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{
    private MeshRenderer myMesh;


    private void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            myMesh.enabled = false;

           
            
        }
    }
}