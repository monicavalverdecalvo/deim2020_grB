using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    //[SerializeField] Transform Tarjet;
    [SerializeField] Transform SpacePosition;
 
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {

        transform.position = new Vector3(SpacePosition.position.x, SpacePosition.position.y, - 5);

        //transform.position = new Vector3(transform.position.x, playerPosition.position.y, transform.position.z);


        // transform.LookAt(Tarjet);
    }
}
