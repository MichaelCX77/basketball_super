using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContagemRegressiva : MonoBehaviour
{
    
    private Text time;
    private Image focoTimer;
    private Animator timeEnd;
    private float timeLeft = 100;
    public double timeLeftRounded = 100;
    private Mira mira;

    void Start()
    {
        time = GetComponent<Text>();
        focoTimer = GameObject.Find("Placares/PlacarImg/Foco_Timer").GetComponent<Image>();
        timeEnd = GameObject.Find("Placares/PlacarImg/Bola_Sup").GetComponent<Animator>(); 
        mira = GameObject.Find("Bola").GetComponent<Mira>();


        time.text = timeLeft + "";
    }

    // Update is called once per frame
    void Update()
    {

        if(mira.bolaParada == true){
            timeLeft -= Time.deltaTime;
            timeLeftRounded =  Math.Floor(timeLeft);
            
            if ( timeLeftRounded <= 0 ) {
                time.text = "00";
            } else if ( timeLeftRounded < 10 ) {
                time.text = "0" +  timeLeftRounded + "";
            } else {
                time.text = timeLeftRounded + "";
            }   

            ControlaFocoTimer();
        }


        if(timeLeftRounded <= 16 && timeEnd.GetBool("timeend") == false){
            timeEnd.SetBool("timeend", true);
            print(timeLeftRounded);
        }

    }

    void ControlaFocoTimer(){
        focoTimer.fillAmount = (float) (timeLeft/100f);
    }
}
