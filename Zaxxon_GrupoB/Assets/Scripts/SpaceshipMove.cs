using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Importante importar esta librería para usar la UI

public class SpaceshipMove : MonoBehaviour
{
    //--SCRIPT PARA MOVER LA NAVE --//

  

    //Variable PÚBLICA que indica la velocidad a la que se desplaza
    //La nave NO se mueve, son los obtstáculos los que se desplazan
    public float speed;

    //Variable que determina cómo de rápido se mueve la nave con el joystick
    //De momento fija, ya veremos si aumenta con la velocidad o con powerUps
    private float moveSpeed = 3f;
    //Variable que determina si estoy en los margenes
    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;
    //de momenot fija, ya veremos si aumenta la 


    //Capturo el texto del UI que indicará la distancia recorrida
    [SerializeField] Text TextDistance;
    [SerializeField] Text TextVelocity;

    //Variables para rotacion

    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;

    //AudioSource

    private AudioSource audioSource;
    


    // Start is called before the first frame update
    void Start()
    {

        speed = 5f;

        //Llamo a la corrutina que hace aumentar la velocidad
        StartCoroutine("Distancia");

        //Asocio el componente audio
       // audioSource = GetComponent<audioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //Ejecutamos la función propia que permite mover la nave con el joystick
        MoverNave();


        //Disparo el sonido
       //f(Input.GetKeyDown("space"))
        {
          //audioSource.Play();
        }

    }

    //Corrutina que hace cambiar el texto de distancia
    IEnumerator Distancia()
    {
        //Bucle infinito que suma 10 en cada ciclo
        //El segundo parámetro está vacío, por eso es infinito
        for (int n = 0; ; n ++ )
        {
            //Cambio el texto que aparece en pantalla
            TextDistance.text = "DISTANCIA: " + n * speed;

            //cada ciclo aumenta la velocidad
            if(speed < 30)
            {
                speed = speed + 0.1f;
            }
           
            //Ejecuto cada ciclo esperando 1 segundo
            yield return new WaitForSeconds(0.25f);
        }
        
    }
    


    void MoverNave()
    {
        /*
        //Ejemplos de Input que podemos usar más adelante
        if(Input.GetKey(KeyCode.Space))
        {
            print("Se está pulsando");
        }

        if(Input.GetButtonDown("Fire1"))
        {
            print("Se está disparando");
        }
        */
        //Variable float que obtiene el valor del eje horizontal y vertical
        float desplX = Input.GetAxis("Horizontal");
        float desplY = Input.GetAxis("Vertical");

        //Movemos la nave mediante el método transform.translate
        //Lo multiplicamos por deltaTime, el eje y la velocidad de movimiento la nave
        //transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);
        // transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);


        //print(transfom.position.x);
        float myPosX = transform.position.x;
        float myPosY = transform.position.y;

        //Lanzamos el metodo que nos comprueba la restriccion en Xy en Y
         checkRestrX(myPosX, desplX);
        checkRestrY(myPosY, desplY);

        //si estoy en los margenes, me muevo
        if (inMarginMoveX)
        {
           transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * desplX);

            //Roto
            float rotZ = desplX * Time.deltaTime * moveSpeed;
            float rotX = desplY * Time.deltaTime * moveSpeed;

            //transform.Rotate(rotX * 10, 0, rotZ * -10);

            //modifying the Vector3, based on input multiplied by speed and time
            //currentEulerAngles += new Vector3(rotX * -5000, y, rotZ * -10000) * Time.deltaTime;

            //apply the change to the gameObject
           // transform.eulerAngles = currentEulerAngles;

            /* currentEulerAngles += new Vector3(rotX * -5000, desplY, rotZ * -10000) * Time.deltaTime;

             transform.eulerAngles = currentEulerAngles;*/
        }

                 if (inMarginMoveY)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed * desplY);
        }

    }

    void checkRestrX(float myPosX, float desplX)
    {
        //He usado una booleana para reducir el nº de IFs
        //Usando || podemos poner una condición OR otra
        if (myPosX < -4.5 && desplX < 0 || myPosX > 4.5 && desplX > 0)
        {
            inMarginMoveX = false;
        }
        else if (myPosX < -4.5 && desplX > 0 || myPosX > 4.5 && desplX < 0)
        {
            inMarginMoveX = true;
        }

    }

    void checkRestrY(float myPosY, float desplY)
    {
        //Retricción en Y
        if (myPosY < -0 && desplY < 0 || myPosY > 4 && desplY > 0)
        {
            inMarginMoveY = false;
        }
        else if (myPosY < -0 && desplY > 0 || myPosY > 4 && desplY < 0)
        {
            inMarginMoveY = true;
        }
    }



}
  
       
    




