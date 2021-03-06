using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Colisiones : MonoBehaviour
{

    [SerializeField] MeshRenderer myMesh;
    public GameObject ExplosionParticulas;
    Vector3 pos;
    public float speed = 3f;
    AudioSource audioSource;
    [SerializeField] AudioClip explosion;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;

        
    }
    void OnTriggerEnter(Collider other)
       
    {
        if (other.gameObject.tag == "obstacle")
        {

            Choque();
        }
    }

         void Choque()
    {
        myMesh.enabled = false;
        speed = 0;
        pos = transform.position;
        Instantiate(ExplosionParticulas, pos, Quaternion.identity);
       
        Invoke("Over", explosion.length);
        audioSource.PlayOneShot(explosion, 1f);
    }

        void Over()
    {
        SceneManager.LoadScene("Game_Over");
    }
}
