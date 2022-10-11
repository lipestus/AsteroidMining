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
        [Range(1, 50)] public float turnSpeed;

        private float thrustInput;
        private float turnInput;
        private Vector2 testVector;
        private float easeInValue;
        private float currentTime;
        private float turnTimeElapsed;

        private Vector2 turnVector;
        private Vector3 forwardDirection;
        private Quaternion rotation;
        private float minValue;

        private void Update()
        {
            float angle = Mathf.Atan2(input.rotationValue.x, input.rotationValue.y) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            forwardDirection = transform.rotation * Vector3.up;
            
            thrustInput = input.move.normalized.sqrMagnitude;

            if (thrustInput > 0)
            {
                currentTime += Time.deltaTime;
                minValue = 100f;
            }
            else
            {
                minValue = 0;
                currentTime = 0;
            }
            
            easeInValue = thrustInput * GameUtils.Easing.QuadEaseOut(currentTime, minValue, thrust, 1f);
            easeInValue = Mathf.Clamp(easeInValue, minValue, thrust);
            Debug.Log($"<color=cyan>easeInValue: {rb.velocity} </color>");
        }

        private void FixedUpdate()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                turnSpeed * Time.deltaTime);
            rb.AddForce(forwardDirection * easeInValue * Time.deltaTime);
        }
    }
}