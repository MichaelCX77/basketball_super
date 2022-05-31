using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaEfeitoPonto : MonoBehaviour
{
    private Animator animP1, animP2;

    void Start()
    {
        animP1 = GameObject.Find("EfeitoPontoP1").GetComponent<Animator>();
        animP2 = GameObject.Find("EfeitoPontoP2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcendePontoP1(){
        animP1.SetBool("isoff", false);
        animP1.SetBool("isponto", true);
    }

    public void AcendePontoP2(){
        animP2.SetBool("isoff", false);
        animP2.SetBool("isponto", true);
    }

    public void ApagaPontoP1(){
        animP1.SetBool("isoff", true);
        animP1.SetBool("isponto", false);
    }

    public void ApagaPontoP2(){
        animP2.SetBool("isoff", true);
        animP2.SetBool("isponto", false); 
    }
}
