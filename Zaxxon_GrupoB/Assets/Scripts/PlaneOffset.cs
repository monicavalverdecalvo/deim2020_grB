using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOffset : MonoBehaviour
{

    //Componente de tipo Renderer
    Renderer rend;
    //Vector de desplazamiento
    [SerializeField] Vector2 despl;
    //Datos del juego
    InitGame initGame;
    //Velocidad a la que se movera la textura
    [SerializeField] float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //Asignamos el componente renderer
        rend = GetComponent<Renderer>();
        //Obtenemos el script
        GameObject InitEmpty = GameObject.Find("initGame");
        initGame = InitEmpty.GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {
        scrollSpeed = initGame.speed / 1; //Velocidad de desplazamiento
        //Distancia de desplazamiento, segun el tiempo de transc
        float offset = Time.time * scrollSpeed;
        //Vector de desplazamiento
        despl = new Vector2(0, -offset);
        //desplazamos la textura albedo y la normal
        rend.material.SetTextureOffset("_MainTex", despl);
        rend.material.SetTextureOffset("_BumpMap", despl);

    }
}
