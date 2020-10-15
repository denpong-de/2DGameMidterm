using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class moonBehav : MonoBehaviour
{
    public playerValue gameValues; //ScriptableObject

    Light2D moonLight;
 
    // Start is called before the first frame update
    void Start()
    {
        moonLight = this.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameValues.difficultyIndex)
        {
            default:
            case 1: moonLight.color = (Color.yellow); break;
            case 2: moonLight.color = (Color.red); break;
            case 3: moonLight.color = new Color(255f,0f,255f); break;
        }
    }
}
