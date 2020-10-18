using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBG : MonoBehaviour
{
    public playerValue ParallaxBG; //ScriptableObject

    [SerializeField] private Transform bgProp;
    [SerializeField] private Transform bg;
    [SerializeField] private Transform bgXL;
    [SerializeField] private Transform cloud;

    private Transform cameraTransform;
    private Vector3 cameraPosition;
    private Vector3 deltaMovement;

    [SerializeField] private player player;

    void Awake()
    {
        cameraTransform = Camera.main.transform;
        cameraPosition = cameraTransform.position;
    }

    void FixedUpdate()
    {
        deltaMovement = cameraTransform.position - cameraPosition;

        objParallax(bgProp, ParallaxBG.bgPropMultiplier);
        objParallax(bg, ParallaxBG.bgMultiplier);
        objParallax(cloud, ParallaxBG.bgXLMultiplier);
        objParallax(bgXL, ParallaxBG.bgXLMultiplier);

        cameraPosition = cameraTransform.position;

        infiniteLevel(bg);
        infiniteLevel(bgProp);
        infiniteLevel(cloud);
        infiniteLevel(bgXL);
    }

    private void objParallax(Transform obj, Vector2 Multiplier)
    {
        obj.transform.position += new Vector3(deltaMovement.x * Multiplier.x, deltaMovement.y * Multiplier.y);
        cameraPosition = cameraTransform.position;
    }

    private void infiniteLevel(Transform obj)
    {
        float lastEndPosition = obj.Find("EndPosition").position.x;

        if (player.transform.position.x >= lastEndPosition)
        {
            obj.position = new Vector3(player.transform.position.x, obj.transform.position.y);
        } 
    }
}
