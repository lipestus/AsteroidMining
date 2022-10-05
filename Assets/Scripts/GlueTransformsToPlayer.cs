using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GlueTransformsToPlayer : MonoBehaviour
{
    [SerializeField] private Transform transformReference;
    [NonReorderable][SerializeField] public Test[] parts;
    
    [Serializable]
    public struct Test
    {
        public Transform part;
        public Vector3 offset;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < parts.Length; i++)
        {
            parts[i].part.position = transformReference.position + parts[i].offset;
        }
    }
}
