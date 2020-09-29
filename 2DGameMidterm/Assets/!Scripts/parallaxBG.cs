using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBG : MonoBehaviour
{
    [SerializeField] private Transform bgProp;
    [SerializeField] private Transform bg;
    public playerValue ParallaxBG; //ScriptableObject

    private Transform cameraTransform;
    private Vector3 cameraPosition;
    private Vector3 deltaMovement;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
        cameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaMovement = cameraTransform.position - cameraPosition;

        objParallax(bgProp, ParallaxBG.bgPropMultiplier);
        objParallax(bg, ParallaxBG.bgMultiplier);

        cameraPosition = cameraTransform.position;
    }

    private void objParallax(Transform obj, Vector2 Multiplier)
    {
        obj.transform.position += new Vector3(deltaMovement.x * Multiplier.x, deltaMovement.y * Multiplier.y);
        cameraPosition = cameraTransform.position;
    }
}
