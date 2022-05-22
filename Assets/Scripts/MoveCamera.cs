using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private Transform limiteD, limiteE, limiteI, limiteS, bola;
    public static MoveCamera instance;
    public bool segueBola;
    public bool toP1;
    public bool toP2;

    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        bola = GameObject.Find("Bola").GetComponent<Transform>();
        limiteD = GameObject.Find("LimitCamD").GetComponent<Transform>();
        limiteE = GameObject.Find("LimitCamE").GetComponent<Transform>();
        limiteI = GameObject.Find("LimitCamI").GetComponent<Transform>();
        limiteS = GameObject.Find("LimitCamS").GetComponent<Transform>();
        segueBola = true; toP1 = false; toP2 = false;
    }

    void Update() {

        transform.position = PosicionaCamera();
        
    }

    public Vector3 PosicionaCamera(){

        if(segueBola){
            return SegueBola();
        } else if(toP1){
            return MovetoP1();
        } else if (toP2){
            return MovetoP2();
        } else {
            return transform.position;
        }

    }
    private Vector3 MovetoP1(){
        Vector3 posCam = transform.position;
        posCam.y = bola.position.y;
        //testeaaa
        posCam.x = limiteD.position.x;
        posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
        return posCam;
    }

    private Vector3 MovetoP2(){

        Vector3 posCam = transform.position;
        posCam.x = limiteE.position.x;
        posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
        return posCam;
    }
    public Vector3 SegueBola() {
        if(GameManager.instance.jogoComecou == true){
            Vector3 posCam = transform.position;
            posCam.x = bola.position.x;
            posCam.y = bola.position.y;
            posCam.x = Mathf.Clamp(posCam.x, limiteE.position.x, limiteD.position.x);
            posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
            return posCam;
        } else {
            return transform.position;
        } 
    }
}
