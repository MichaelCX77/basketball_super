using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizaPlacar : MonoBehaviour
{
    private Text pontosP1, pontosP2;
    void Start(){
        pontosP1 = GameObject.Find("Placares/PlacarP1/Pontos").GetComponent<Text>();
        pontosP2 = GameObject.Find("Placares/PlacarP2/Pontos").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   
        if(colisor.gameObject.CompareTag("ponto")){

            Placar.instance.novoPonto = true;

            if(colisor.gameObject.name == "PontoP1"){
                pontosP1.text = (Placar.instance.pontosP1 += 1) +"";
            }
            if(colisor.gameObject.name == "PontoP2"){
                pontosP2.text = (Placar.instance.pontosP2 += 1) +"";
            }

        }
    }
}
