using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFoco : MonoBehaviour
{

    private Transform bolaFocoT;
    private Animator anim;
    private Mira rot;

    void Start()
    {
        GameObject animBolaFoco = GameObject.Find("Armature_Foco_Bola_00");
        bolaFocoT = animBolaFoco.GetComponent<Transform>();
        anim = animBolaFoco.GetComponent<Animator>();
        rot = GetComponent<Mira> ();
    }

    // Update is called once per frame
    void Update()
    {
        PosicionaAnimacao();
        AtivaFoco();
    }

    void PosicionaAnimacao(){
        bolaFocoT.position = transform.position;
    }

    void AtivaFoco(){

        if((rot.liberaRot == true && rot.bolaParada == true) ||
        (rot.liberaRot == false && rot.bolaParada == false)) {
            anim.SetBool("foco", false);
        } else if(rot.bolaParada == true){
            anim.SetBool("foco", true);
        } 
    }
}
