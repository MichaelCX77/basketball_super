using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePredios : MonoBehaviour
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

                posX=bola.position.x / 260;
                posY=bola.position.y / 90;

                Vector2 offset = LimitaMovFundo(posX , posY);
                quad.material.mainTextureOffset = offset;

            }
        }
    }

    Vector2 LimitaMovFundo(float posX, float posY){

        if(posX > 0.020f){
            posX = 0.020f;
        }
        if(posX < -0.020f){
            posX = -0.020f;
        }

        if(posY < 0.014f){
            posY = 0.014f;
        }

        return new Vector2 (posX , posY);
    }
}
