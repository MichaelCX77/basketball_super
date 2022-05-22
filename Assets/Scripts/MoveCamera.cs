using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private Transform limiteD, limiteE, limiteI, limiteS, bola;

    public bool segueBola = true;
    public bool toP1 = false;
    public bool toP2 = false;

    void Start() {
        limiteD = GameObject.Find("LimitCamD").GetComponent<Transform>();
        limiteE = GameObject.Find("LimitCamE").GetComponent<Transform>();
        limiteI = GameObject.Find("LimitCamI").GetComponent<Transform>();
        limiteS = GameObject.Find("LimitCamS").GetComponent<Transform>();
    }

    void Update() {

        if(segueBola){
            CameraSegueBola();
        } else if(toP1){

            Vector3 posCam = transform.position;
            posCam.y = bola.position.y;
            posCam.x = limiteD.position.x;
            posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
            transform.position = posCam;

        } else if (toP2){
            Vector3 posCam = transform.position;
            posCam.x = limiteE.position.x;
            posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
            transform.position = posCam;
        }
        
    }

    void CameraSegueBola() {
        if(GameManager.instance.jogoComecou == true){
            if(bola == null && GameManager.instance.bolasEmJogo > 0){
                bola = GameObject.Find("Bola").GetComponent<Transform>();
            } else if (GameManager.instance.bolasEmJogo > 0){
                Vector3 posCam = transform.position;
                posCam.x = bola.position.x;
                posCam.y = bola.position.y;
                posCam.x = Mathf.Clamp(posCam.x, limiteE.position.x, limiteD.position.x);
                posCam.y = Mathf.Clamp(posCam.y, limiteI.position.y, limiteS.position.y);
                transform.position = posCam;
            }
        } 
    }
}
