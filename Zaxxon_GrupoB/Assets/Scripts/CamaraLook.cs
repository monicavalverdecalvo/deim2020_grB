using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraLook : MonoBehaviour
{
    //[SerializeField] Transform Tarjet;
    [SerializeField] Transform SpacePosition;
    
    //VARIABLES NECESARIAS PARA LA OPCION DE SUAVIZADO EN EL SEGUIMIENTO
    [SerializeField] float smoothVelocity;
    private Vector3 cameraVelocity = Vector3.zero;

    
    // Start is called before the first frame update
    void Start()
    {


        //Damos una velocidad de suavizado en el seguimiento
        smoothVelocity = 0.1f;
    }

    // Update is called once per frame
    void Update()

    {

        //transform.position = new Vector3(SpacePosition.position.x, SpacePosition.position.y, - 5);


        //ESTAS LINEAS DE CODIGO HACEN QUE LA CAMARA SIGA AL OBJETIVO (targetPosition) con suavizador (smoothVelocity)
        Vector3 targetPosition = new Vector3(SpacePosition.position.x, SpacePosition.position.y + 0.5f, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, smoothVelocity);

        
        
        //transform.position = new Vector3(transform.position.x, playerPosition.position.y, transform.position.z);


        // transform.LookAt(Tarjet);
    }
}
