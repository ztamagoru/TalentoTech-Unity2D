using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    [SerializeField] private float parallaxMultiplier; //parallax velocity

    private float spriteWidth, startPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    void LateUpdate()
    {
        float deltaX = (cameraTransform.position.x - lastCameraPosition.x) * parallaxMultiplier;
        float moveDistance = cameraTransform.position.x * (1 - parallaxMultiplier);

        transform.Translate(new Vector3(deltaX, 0, 0));
        lastCameraPosition = cameraTransform.position;

        if (moveDistance > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveDistance < startPosition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
    }
}
