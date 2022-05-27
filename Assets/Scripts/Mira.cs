using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mira : MonoBehaviour
{
    [SerializeField] private Image setaImgCinza;
    [SerializeField] private Image setaImg;
    [SerializeField] private GameObject setaCinzaObject;
    public float zRotate;
    public bool bolaParada = false;
    public bool liberaRot;
    public bool atirar = false;
    private ProximaVez pVez;

    void Start()
    {
        zRotate = 180;
        liberaRot = false;
        setaImgCinza = GameObject.Find("Setas/Seta_Cinza").GetComponent<Image>();
        setaImg = GameObject.Find("Setas/Seta").GetComponent<Image>();
        setaCinzaObject = GameObject.Find("Setas/Seta_Cinza");
        setaCinzaObject.SetActive(false);
        pVez = GameObject.Find("Placar").GetComponent<ProximaVez>();
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

        if(Placar.instance.vezAtual == "P1"){
            pVez.AlertaVezP1();
        } else if(Placar.instance.vezAtual == "P2"){
            pVez.AlertaVezP2();
        }

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
        
        if(velocity.y == 0 && velocityx <= 0.2 && bolaParada == false){
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            bolaParada = true; //bola parada
            Placar.instance.jaJogou = true;
        } else if(velocity.y != 0 && velocityx >= 0.21) {
            
            bolaParada = false;
            
        }

    }

}
