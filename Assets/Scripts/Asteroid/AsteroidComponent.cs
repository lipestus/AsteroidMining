using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AsteroidComponent : MonoBehaviour
{
    // Update is called once per frame

    private float xRandom;
    private float yRandom;
    private void Update()
    {
        transform.Rotate(new Vector3(xRandom, xRandom, 0) * (0.77f * Time.fixedDeltaTime));
    }
    private void LateUpdate()
    {
        xRandom = UnityEngine.Random.Range(2f, 10f);
        xRandom = UnityEngine.Random.Range(3f, 6f);
    }
}
