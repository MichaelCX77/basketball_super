using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComACamera : MonoBehaviour
{

    private MoveCamera moveCamera;

    void Start()
    {   
        moveCamera = GetComponent<MoveCamera>();
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 posCam = MoveCamera.instance.PosicionaCamera();
        transform.position = new Vector3(posCam.x,(posCam.y + 2.8f),-15);
    }
}
