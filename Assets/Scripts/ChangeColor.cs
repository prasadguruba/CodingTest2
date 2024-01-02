using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject targetObject;
    public float proximityDistance = 3.0f;
    public Color withinProximityColor = Color.green;
    public Color defaultColor = Color.white;

    Renderer renderer;

    void Start()
    {
        // Get the Renderer component of the GameObject
        renderer = GetComponent<Renderer>();
        // Set the default color at the start
        SetDefaultColor();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        // Move the GameObject based on input
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Check proximity to the targetObject
        if (Vector3.Distance(transform.position, targetObject.transform.position) < proximityDistance)
        {
            // Change the color when within proximity
            ChangeColorOfObject(withinProximityColor);
        }
        else
        {
            // Set the default color when outside of proximity
            SetDefaultColor();
        }
    }

    void ChangeColorOfObject(Color newColor)
    {
        // Change the color of the GameObject
        renderer.material.color = newColor;
    }

    void SetDefaultColor()
    {
        // Set the default color of the GameObject
        renderer.material.color = defaultColor;
    }
}

