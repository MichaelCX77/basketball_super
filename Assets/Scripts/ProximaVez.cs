using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximaVez : MonoBehaviour
{

    private Mira mira;

    private PosicaoBola pBola;

    private ControlaNeon cNeon;

    private PassaAVez pVez;

    void Start()
    {
        mira = GameObject.Find("Bola").GetComponent<Mira>();
        pBola = GameObject.Find("Bola").GetComponent<PosicaoBola>();
        cNeon = GameObject.Find("Placares").GetComponent<ControlaNeon>();
        pVez = GetComponent<PassaAVez>();
    }

    // Update is called once per frame
    void Update()
    {

        if(mira.bolaParada == true && Placar.instance.jaJogou == true){

            if(!Placar.instance.novoPonto){

                string vezAtual = Placar.instance.vezAtual;
                
                if(vezAtual == "P1"){
                    SetVezP2();
                } else {
                    SetVezP1();
                }
                Placar.instance.jaJogou = false;
            } else if(Placar.instance.novoPonto && pBola.isPosStart == true) {

                pVez.ResetVez();
                Placar.instance.novoPonto = false;
                Placar.instance.jaJogou = false;

                if(Placar.instance.pontoFeitoEm == "P2"){
                    SetVezP1();
                } else if (Placar.instance.pontoFeitoEm == "P1"){
                    SetVezP2();
                }

                Placar.instance.pontoFeitoEm = null;
            }
        }
    }

    public void SetVezP1(){
        Placar.instance.vezAtual = "P1";
        Placar.instance.proximaVez = "P2";
        cNeon.ApagaNeonBlue();
        cNeon.PiscaNeonRed();
    }

    public void SetVezP2(){
        Placar.instance.vezAtual = "P2";
        Placar.instance.proximaVez = "P1";
        cNeon.ApagaNeonRed();
        cNeon.PiscaNeonBlue();
    }

    public void AlertaVezP1(){
        cNeon.AcendeNeonRed();
    }
    
    public void AlertaVezP2(){
        cNeon.AcendeNeonBlue();
    }

}
