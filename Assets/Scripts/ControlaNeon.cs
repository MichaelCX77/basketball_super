using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaNeon : MonoBehaviour
{
    
    private Animator animP1, animP2;

    void Start()
    {
        animP1 = GameObject.Find("Placares/Neon_Red").GetComponent<Animator>();
        animP2 = GameObject.Find("Placares/Neon_Blue").GetComponent<Animator>();
    }

    void Update(){
        // Liga neonAutomatico
        // if(animP1.GetBool("piscaNeon") == true){
        //     animP1.SetBool("piscaNeon", false);
        //     animP1.SetBool("acendeNeon", true);
        // } else if (animP2.GetBool("piscaNeon") == true){
        //     animP2.SetBool("piscaNeon", false);
        //     animP2.SetBool("acendeNeon", true);
        // }
    }
    // Update is called once per frame
    public void PiscaNeonBlue(){
        animP2.SetBool("piscaNeon", true);
        animP2.SetBool("apagaNeon", false);
        animP2.SetBool("acendeNeon", false);
    }

    public void PiscaNeonRed(){
        animP1.SetBool("piscaNeon", true);
        animP1.SetBool("apagaNeon", false);
        animP1.SetBool("acendeNeon", false);
    }

    public void ApagaNeonRed(){
        animP1.SetBool("apagaNeon", true);
        animP1.SetBool("acendeNeon", false);
    }

    public void ApagaNeonBlue(){
        animP2.SetBool("apagaNeon", true);
        animP2.SetBool("acendeNeon", false);
    }

    public void AcendeNeonRed(){
        animP1.SetBool("acendeNeon", true);
        animP1.SetBool("piscaNeon", false);
    }

    public void AcendeNeonBlue(){
        animP2.SetBool("acendeNeon", true);
        animP2.SetBool("piscaNeon", false);
    }
}
