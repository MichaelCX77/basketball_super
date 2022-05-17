using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private Transform limiteD, limiteE, bola;
    void Update() {
        if(GameManager.instance.jogoComecou == true){
            if(bola == null && GameManager.instance.bolasEmJogo > 0){
                bola = GameObject.Find("Bola").GetComponent<Transform>();
            } else if (GameManager.instance.bolasEmJogo > 0){
                Vector3 posCam = transform.position;
                posCam.x = bola.position.x;
                posCam.x = Mathf.Clamp(posCam.x, limiteE.position.x, limiteD.position.x);
                transform.position = posCam;
            }
        } 
    }
}
