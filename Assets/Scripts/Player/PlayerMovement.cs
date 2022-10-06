using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidMining.GameUtils;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputHandler input;
        [SerializeField] private Rigidbody2D rb;
        [Range(1, 500)] public float thrust;
        [Range(1, 500)] public float turnSpeed;

        private float thrustInput;
        private float turnInput;
        private Vector2 testVector;
        private float easeInValue;
        private float currentTime;
        private float turnTimeElapsed;

        private void Start()
        {
        }

        private void Update()
        {
            thrustInput = input.move.y;
            turnInput = input.rotationValue.x;
            
            if(thrustInput > 0)
                currentTime += Time.deltaTime;
            else
                currentTime = 0;
            
            easeInValue = thrustInput * GameUtils.Easing.QuadEaseOut(currentTime, 0, thrust, 0.5f);
            easeInValue = Mathf.Clamp(easeInValue, 0, thrust);
            //Debug.Log($"<color=cyan>easeInValue: {easeInValue} </color>");
        }

        private void FixedUpdate()
        {
            transform.Rotate(-Vector3.forward * turnInput * turnSpeed * Time.fixedDeltaTime);
            rb.AddForce(transform.up * easeInValue * Time.fixedDeltaTime);
        }
    }
}