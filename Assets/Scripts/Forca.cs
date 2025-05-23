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
    private PosicaoBola pos;
    private bool forca_reversa = false;
    public Image setaImg;

    void Start()
    {
        bola = GetComponent<Rigidbody2D> ();
        rot = GetComponent<Mira> ();
        setaImg = GameObject.Find("Setas/Seta").GetComponent<Image>();
        pos = GetComponent<PosicaoBola> ();
    }

    void Update()
    {
        ControlaForca();
        AplicaForca();
    }

    void AplicaForca(){

        float x = force * Mathf.Cos((rot.zRotate -180) * Mathf.Deg2Rad);
        float y = force * Mathf.Sin((rot.zRotate -180) * Mathf.Deg2Rad);

        if(rot.bolaParada == true && rot.atirar == true){
            
            bola.AddForce(new Vector2(x,y));
            Quick.onQuick();
            rot.atirar = false;
            setaImg.fillAmount = 0;
            force = 0;

            if(pos.isPosStart == true){
                pos.isPosStart = false;
            }

        }

    }

    void ControlaForca(){

        if (rot.bolaParada == true && rot.liberaRot == true){
            
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
