using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    Color[] color = { Color.black, Color.blue, Color.green };
    public override void Interact()
    {
        ChangeColor();
    }

    private void ChangeColor()
    {
        int k = Random.Range(0, 3);
        GetComponent<Renderer>().material.color = color[k];
    }
}
