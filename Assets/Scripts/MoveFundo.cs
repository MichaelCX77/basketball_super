using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    [SerializeField] private Transform bola;
    public float posX,posY;
    public Renderer quad;
    void Start()
    {
        posX = 0; posY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.jogoComecou == true){
            if(bola == null && GameManager.instance.bolasEmJogo > 0){
                bola = GameObject.Find("Bola").GetComponent<Transform>();
            } else {

//              Quanto maior - mais lento, quanto menor, mais rápido
                posX=bola.position.x / 200;
                posY=bola.position.y / 160;

                Vector2 offset = LimitaMovFundo(posX , posY);
                quad.material.mainTextureOffset = offset;

            }
        }
    }

    Vector2 LimitaMovFundo(float posX, float posY){


        if(posX > 0.036f){
            posX = 0.036f;
        }
        if(posX < -0.036f){
            posX = -0.036f;
        }

        if(posY > 0.04f){
            posY = 0.04f;
        }
        if(posY < 0.017f){
            posY = 0.017f;
        }

        return new Vector2 (-posX , -posY);
    }
}
