using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    private RectTransform reticle;
    public float restSize;
    public float maxSize;
    public float speed;
    private float currentSize;
    private float startTime;
    private Interactable currentObject = null;
    public Transform player;
    [SerializeField] Image[] img = new Image[4]; 
    void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    void ChangeColor(Color color)
    {
        for (int j = 0; j < 4; j++)
        {
            img[j].color = color;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Ray rayOrigin = new Ray(Camera.current.transform.position,Camera.current.transform.forward); 
        RaycastHit hitinfo;
        if (Physics.Raycast(rayOrigin, out hitinfo))
        {
            Interactable i = hitinfo.collider.GetComponent<Interactable>();
            if(i != currentObject)
            {
                startTime = Time.time;
                currentObject = i;
            }
            if (currentObject != null)
            {
                if (currentObject.isActive(player))
                {
                    if (Time.time - startTime > 2)
                    {
                        currentObject.Interact();
                        startTime = 0;
                        currentObject = null;
                    }
                    ChangeColor(Color.green);
                    currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
                }
                else
                {
                    ChangeColor(Color.red);
                }
            }
            else
            {
                startTime = 0;
                ChangeColor(Color.black);
                currentSize = Mathf.Lerp(currentSize, restSize, Time.deltaTime * speed);
                currentObject = null;
            }
        }
        else
        {
            startTime = 0;
            ChangeColor(Color.black);
            currentSize = Mathf.Lerp(currentSize, restSize, Time.deltaTime * speed);
            currentObject = null;
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }
}
