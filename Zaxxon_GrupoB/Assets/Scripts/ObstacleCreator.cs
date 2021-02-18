using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //Variable que contendré el prefab con el obstáculo
    [SerializeField] GameObject Columna;


    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumber;
    Vector3 RandomPos;

    //Distacia a la que se crean las columnas iniciales
    //[SerializeField] float distaciaInicial = 5;

    //Distancia entre columnas
    float distanciaSep = 6f;


    //Acceder a los componentes de la nave
    public GameObject Nave;
    private SpaceshipMove spaceshipMove;


    // Start is called before the first frame update
    void Start()
    {
        //Acedo al script de la nave
        spaceshipMove = Nave.GetComponent<SpaceshipMove>();
        
       
        //Crear columnas iniciales
        for(int n = 1; n <= 10;n++)
        {

            //CrearColumna(n * distaciaInicial);
            //Creamos cada columna con la separacion establecida
            CrearColumna(-n * distanciaSep);

        }
        
        //Lanzo la corrutina
        StartCoroutine("InstanciadorColumnas");
  
    }

    //Función que crea una columna en una posición Random
    //Lo hemos cambiado para que se le pueda pasar el valor en x o por defecto
    void CrearColumna(float posZ =0f)
    {
        randomNumber = Random.Range(-5f, 7f);
        RandomPos = new Vector3(randomNumber, 0, posZ);
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPos;
        Instantiate(Columna, FinalPos, Quaternion.identity);
    }

  
    //Corrutina que se ejecuta cada segundo
    //NOTA_1: habría que cambiar ese segundo por una variable que dependa de la velocidad
    //NOTA_2: ahora el intervalo de la corrutina depende de la variable "speed" de la nave
    //Aplicamos la formula "espacioEntreColumnas / velocidad"
    IEnumerator InstanciadorColumnas()
    {
        //Bucle infinito (poner esto es lo mismo que while(true){}
      //  for (; ; )
        {
          //  CrearColumna();
           // yield return new WaitForSeconds(1f);
        }

        //Bucle infinito (poener esto es lo mismo que while(true){}
        for (; ; )
        {

            CrearColumna();
            //float interval = 4 / spaceshipMove.speed;
            // yield return new WaitForSeconds(interval);
            float interval = distanciaSep / spaceshipMove.speed;
            yield return new WaitForSeconds(interval);
        }

        

    }


}
