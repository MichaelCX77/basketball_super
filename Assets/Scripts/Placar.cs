using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placar : MonoBehaviour
{
    public static Placar instance;
    public int pontosP1, pontosP2;
    public bool novoPonto = false;
    public string vezAtual = "P2";
    public string proximaVez = "P1";
    public string pontoFeitoEm = null;
    public bool jaJogou = false;
    
    
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start(){
        pontosP1 = 0;
        pontosP2 = 0;
    }

}
