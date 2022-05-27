using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaAVez : MonoBehaviour
{
    
    private float vez = 10.5f;
    private string vezAtual = null;
    private Mira mira;
    private ProximaVez pVez;

    void Start()
    {
        vezAtual = Placar.instance.vezAtual;
        mira = GameObject.Find("Bola").GetComponent<Mira>();
        pVez = GetComponent<ProximaVez>();
    }

    void Update()
    {

        if(Placar.instance.vezAtual != vezAtual){
            vezAtual = Placar.instance.vezAtual;
            ResetVez();
        } else {

            if(vez > 0.5 && mira.bolaParada == true){
                vez -= Time.deltaTime;
            } else if (vez <= 0.5f) {

                vez = (vez <= 0) ? 10.5f : vez;

                if(vezAtual == "P1"){
                    pVez.SetVezP2();
                } else if (vezAtual == "P2"){
                    pVez.SetVezP1();
                }
            }
            
            if (vez-1 <= 3 && vez-1 > 0){
                if(vezAtual == "P1"){
                    pVez.AlertaVezP1();
                } else if(vezAtual == "P2"){
                    pVez.AlertaVezP2();
                }
            } 
        }
    }

    public void ResetVez(){
        vez = 10.5f;
    }
}
