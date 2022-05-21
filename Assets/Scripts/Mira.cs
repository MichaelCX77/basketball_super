using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mira : MonoBehaviour
{
    
    [SerializeField] private Transform posStart;
    [SerializeField] private Image setaImgCinza;
    [SerializeField] private Image setaImg;
    [SerializeField] private GameObject setaCinzaObject;
    public float zRotate;

    public bool bolaParada = false;
    public bool liberaRot;
    public bool atirar = false;

    void Start()
    {
        zRotate = 180;
        liberaRot = false;
        posStart = GameObject.Find("Posicao_Inicial").GetComponent<Transform>();
        setaImgCinza = GameObject.Find("Canvas/Seta_Cinza").GetComponent<Image>();
        setaImg = GameObject.Find("Canvas/Seta").GetComponent<Image>();
        setaCinzaObject = GameObject.Find("Canvas/Seta_Cinza");
        setaCinzaObject.SetActive(false);
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {

        VerificaEstado();

        if(bolaParada == true){

            RotacaoMira();
            InputDeRotacao();
            LimitaRotacao();
            PosicionaMira();
        }

    }

    void PosicionaMira(){

        setaImgCinza.rectTransform.position = transform.position;
        setaImg.rectTransform.position = transform.position;
    }

    void PosicionaBola(){
        this.gameObject.transform.position = posStart.position;
    }

    void RotacaoMira(){
        
        setaImgCinza.rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
        setaImg.rectTransform.eulerAngles = new Vector3 (0,0,zRotate);
    }

    void InputDeRotacao(){

        if(liberaRot == true){
            float moveX = Input.GetAxis("Mouse X");
            float moveY = Input.GetAxis("Mouse Y");

            if(zRotate >= 180){
                if(moveX > 0){
                    zRotate+=1.5f;
                }
            }

            if(zRotate <= 360){
                if(moveX < 0){
                    zRotate-=1.5f;
                }
            }
        }
    }

    void LimitaRotacao(){

        if(zRotate < 180){
            zRotate = 180;
        } else if(zRotate > 360){
            zRotate = 360;
        }

    }

    void OnMouseDown()
    {

        liberaRot = true;
        setaCinzaObject.SetActive(true);

    }

    void OnMouseUp()
    {   
        
        if(bolaParada == true){
            liberaRot = false;
            atirar = true;
            setaCinzaObject.SetActive(false);
        }
        
    }

    void VerificaEstado(){
        
        Vector2 velocity = this.GetComponent<Rigidbody2D>().velocity;
        
        float velocityx = velocity.x;

        if(velocity.x <= 0){
            velocityx = (-velocity.x);
        }

        if(velocity.y == 0 && velocityx <= 0.2){
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            bolaParada = true; //bola parada
        } else {
            
            bolaParada = false;
        }

    }


}
