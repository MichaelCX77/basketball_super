using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicaoBola : MonoBehaviour
{
    [SerializeField] private Transform posStart;
    public bool isPosStart = false;
    private Mira mira;
    void Start()
    {   
        posStart = GameObject.Find("Posicao_Inicial").GetComponent<Transform>();
        mira = GetComponent<Mira> ();
        PosicaoInicial();
    }

    // Update is called once per frame
    void Update()
    {
        ReiniciaPosicao();
    }
    void PosicaoInicial(){
        isPosStart = true;
        this.gameObject.transform.position = posStart.position;
    }
    void ReiniciaPosicao(){
        
        if(Placar.instance.novoPonto == true && mira.bolaParada == true){
            isPosStart = true;
            Placar.instance.novoPonto = false;
            this.gameObject.transform.position = posStart.position;
        }
        
    }
}
