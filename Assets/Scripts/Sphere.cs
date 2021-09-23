using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Interactable
{
    public override void Interact()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }
}
