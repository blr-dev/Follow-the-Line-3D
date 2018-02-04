using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour {


    public void SetColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    void Update()
    {
        SetColor(GameController.instance.platformsColor);
    }

}
