using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtualizaPlacar : MonoBehaviour
{
    void Start(){
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   
        if(colisor.gameObject.CompareTag("ponto")){

            Placar.instance.novoPonto = true;

            if(colisor.gameObject.name == "PontoP1"){
                Placar.instance.pontosP1 += 1;
            }
            if(colisor.gameObject.name == "PontoP2"){
                Placar.instance.pontosP2 += 1;

            }

        }
    }
}
