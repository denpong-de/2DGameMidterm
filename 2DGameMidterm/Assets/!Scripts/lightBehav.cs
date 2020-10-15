using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBehav : MonoBehaviour
{
    Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Animator.enabled = false;
        StartCoroutine(LightDelay());
    }

    IEnumerator LightDelay()
    {
        float random = Random.Range(0, 4f);
        yield return new WaitForSeconds(random);
        Animator.enabled = true;
    }
}
