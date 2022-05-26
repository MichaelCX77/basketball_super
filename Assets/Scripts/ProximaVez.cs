using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximaVez : MonoBehaviour
{

    private Mira mira;

    private PosicaoBola pBola;

    private ControlaNeon cNeon;

    void Start()
    {
        mira = GameObject.Find("Bola").GetComponent<Mira>();
        pBola = GameObject.Find("Bola").GetComponent<PosicaoBola>();
        cNeon = GameObject.Find("Placares").GetComponent<ControlaNeon>();
    }

    // Update is called once per frame
    void Update()
    {

        if(mira.bolaParada == true && Placar.instance.jaJogou == true){

            if(!Placar.instance.novoPonto){

                string vezAtual = Placar.instance.vezAtual;
                
                if(vezAtual == "P1"){
                    Placar.instance.vezAtual = "P2";
                    Placar.instance.proximaVez = "P1";
                    cNeon.PiscaNeonBlue();
                    cNeon.ApagaNeonRed();
                } else {
                    Placar.instance.vezAtual = "P1";
                    Placar.instance.proximaVez = "P2";
                    cNeon.PiscaNeonRed();
                    cNeon.ApagaNeonBlue();
                }
                Placar.instance.jaJogou = false;
            } else if(Placar.instance.novoPonto && pBola.isPosStart == true) {

                Placar.instance.novoPonto = false;
                Placar.instance.jaJogou = false;

                if(Placar.instance.pontoFeitoEm == "P2"){
                    Placar.instance.vezAtual = "P1";
                    Placar.instance.proximaVez = "P2";
                    cNeon.PiscaNeonRed();
                    cNeon.ApagaNeonBlue();
                } else if (Placar.instance.pontoFeitoEm == "P1"){
                    Placar.instance.vezAtual = "P2";
                    Placar.instance.proximaVez = "P1";
                    cNeon.PiscaNeonBlue();
                    cNeon.ApagaNeonRed();
                }

                Placar.instance.pontoFeitoEm = null;
            }
        }
    }
}
