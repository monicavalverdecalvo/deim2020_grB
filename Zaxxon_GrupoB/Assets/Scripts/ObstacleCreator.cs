using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    //---SCRIPT ASOCIADO AL EMPTY OBJECT QUE CREARÁ LOS OBSTÁCULOS--//

    //array de mallas para cambiar el obstaculo
    [SerializeField] Mesh[] mallasObstaculos;
    //array de materiales
    [SerializeField] Material[] mateObstaculos;
   
    //Variable que contendré el prefab con el obstáculo, su malla y su material
    [SerializeField] GameObject Columna;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    //Variable que tiene la posición del objeto de referencia
    [SerializeField] Transform InitPos;

    //Variables para generar columnas de forma random
    private float randomNumberX;
    private float randomNumberY;

    Vector3 RandomPosX;
    Vector3 RandomPosY;

    //Distacia a la que se crean las columnas iniciales
    //[SerializeField] float distaciaInicial = 0;

    //Distancia entre columnas
    float distanciaSep = 4f;


    //Acceder a los componentes de la nave
    public GameObject Nave;
    private SpaceshipMove spaceshipMove;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = Columna.GetComponent<MeshRenderer>();
        
        //accedo al mesh filter del obstaculo
        meshFilter = Columna.GetComponent<MeshFilter>();
        
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
        randomNumberX = Random.Range(-5f, 5f);
        randomNumberY = Random.Range(-2f, 2f);
        RandomPosX = new Vector3(randomNumberX, randomNumberY, posZ);


        int randomMesh = Random.Range(0, mallasObstaculos.Length);
        meshFilter.mesh = mallasObstaculos[randomMesh];
        meshRenderer.material = mateObstaculos[randomMesh];
        //print(RandomPos);
        Vector3 FinalPos = InitPos.position + RandomPosX + RandomPosY;
        Instantiate(Columna, FinalPos, Quaternion.identity);


    }


    //Corrutina que se ejecuta cada segundo
    //NOTA_1: habría que cambiar ese segundo por una variable que dependa de la velocidad
    //NOTA_2: ahora el intervalo de la corrutina depende de la variable "speed" de la nave
    //Aplicamos la formula "espacioEntreColumnas / velocidad"
    IEnumerator InstanciadorColumnas()
    {
       

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
