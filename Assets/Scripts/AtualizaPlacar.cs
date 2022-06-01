using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizaPlacar : MonoBehaviour
{
    private Text pontosP1, pontosP2;

    private ControlaMeteoro cMeteoro;
    private ControlaEfeitoPonto cePonto;
    void Start(){
        pontosP1 = GameObject.Find("Placares/PlacarImg/PontosP1").GetComponent<Text>();
        pontosP2 = GameObject.Find("Placares/PlacarImg/PontosP2").GetComponent<Text>();
        cePonto = GetComponent<ControlaEfeitoPonto>();
        cMeteoro = GetComponent<ControlaMeteoro>();
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   
        if(colisor.gameObject.CompareTag("ponto")){

            Placar.instance.novoPonto = true;

            bool three = false;

            if(cMeteoro.animMeteoro.enabled == true){
                three = true;
            }

            if(colisor.gameObject.name == "PontoP1"){
                cePonto.AcendePontoP2();
                pontosP1.text = three ? (Placar.instance.pontosP1 += 3) +"" : (Placar.instance.pontosP1 += 2) + "";
                Placar.instance.pontoFeitoEm = "P2";
            }
            if(colisor.gameObject.name == "PontoP2"){
                cePonto.AcendePontoP1();
                pontosP2.text = three ? (Placar.instance.pontosP2 += 3) +"" : (Placar.instance.pontosP2 += 2) +"";
                Placar.instance.pontoFeitoEm = "P1";
            }

        }
    }
}
