using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quick : MonoBehaviour
{

    public static float force = 300f;
    public static bool isQuick = true;
    public Rigidbody2D bola;

    // Start is called before the first frame update
    void Start()
    {
        bola = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {   
        if(colisor.gameObject.CompareTag("chao")  && isQuick){

            bola.AddForce(new Vector2 (0,force));
            force-=80;

            if(force     <= 130){
                isQuick = false;
            }
        } else if(colisor.gameObject.CompareTag("parede")){
            bola.AddForce(new Vector2 (colisor.gameObject.name == "Parede_D" ? -170 : 170 ,0));
        } else if(colisor.gameObject.CompareTag("borda")){
            bola.AddForce(new Vector2 (0,250));

        } else if(colisor.gameObject.CompareTag("cesto")){
            
            force = 200f;

        }
    }

    public static void onQuick(){
        force = 300f;
        isQuick = true;
    }

}
