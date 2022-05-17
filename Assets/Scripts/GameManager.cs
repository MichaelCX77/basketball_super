using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int bolasEmJogo;
    public bool jogoComecou;
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame(){
        jogoComecou = true;
        bolasEmJogo = 1;
    }

    void GameOver(){
        jogoComecou = false;
    }

    void GameWin(){
        jogoComecou = false;
    }

}
