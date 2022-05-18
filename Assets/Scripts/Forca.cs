using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Forca : MonoBehaviour
{
    
    public Rigidbody2D bola;
    public float force = 0;
    private Mira rot;
    private bool forca_reversa = false;
    public Image setaImg;

    void Start()
    {
        bola = GetComponent<Rigidbody2D> ();
        rot = GetComponent<Mira> ();
        setaImg = GameObject.Find("Canvas/Seta").GetComponent<Image>();
    }

    void Update()
    {
        ControlaForca();
        AplicaForca();
    }

    void AplicaForca(){

        float x = force * Mathf.Cos((rot.zRotate -180) * Mathf.Deg2Rad);
        float y = force * Mathf.Sin((rot.zRotate -180) * Mathf.Deg2Rad);

        if(rot.liberaTiro == true){
            bola.AddForce(new Vector2(x,y));
            Quick.onQuick();
            rot.liberaTiro = false;
            setaImg.fillAmount = 0;
        }

    }

    void ControlaForca(){

        if (rot.liberaRot == true){
            
            if(!forca_reversa){
                setaImg.fillAmount += 0.5f * Time.deltaTime;
                if(setaImg.fillAmount == 1){
                    forca_reversa = true;
                }
            } else {
                setaImg.fillAmount -= 0.5f * Time.deltaTime;
                if(setaImg.fillAmount == 0){
                    forca_reversa = false;
                }
            }

            force = setaImg.fillAmount * 1000;

        }

        // if(rot.liberaRot == true){

        //     float moveY = Input.GetAxis("Mouse Y");

        //     if(moveY < 0){
        //         setaImg.fillAmount += 1 * Time.deltaTime;
        //     } else if(moveY > 0){
        //         setaImg.fillAmount -= 1 * Time.deltaTime;
        //     }

            // force = setaImg.fillAmount * 950;
        // }   

    }
    
}
