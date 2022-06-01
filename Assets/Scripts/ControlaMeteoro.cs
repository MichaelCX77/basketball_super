using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ControlaMeteoro : MonoBehaviour
{
    public Animator animMeteoro;
    private Mira mira;
    private TrailRenderer tr;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animMeteoro = GetComponent<Animator>();
        mira = GetComponent<Mira>();
        tr = GetComponent<TrailRenderer>();
        // sprites = new SpriteCollection("Assets/Sprites");
        // spriteBola = new SpriteCollection("Assets/Sprites/Bola.png");
        animMeteoro.enabled = false;

    }
    void Update()
    {
        if(this.transform.position.y > 6.20f && animMeteoro.enabled == false){
            animMeteoro.enabled = true;
            tr.startColor = new Color (255f, 0.000f, 0.000f, 1.000f);
            tr.endColor = new Color (255f, 0.000f, 0.000f, 0.522f);
        }

        if(mira.bolaParada == true && animMeteoro.enabled == true){
            animMeteoro.enabled = false;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Bola");

            tr.startColor = new Color (0.976f, 0.514f, 0.169f, 1.000f);
            tr.endColor = new Color (1.000f, 0.475f, 0.000f, 0.522f);

        }
    }
}
