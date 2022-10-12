using System.Collections;
using System.Collections.Generic;
using AsteroidMining.PlayerController;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class TestAnalogStick : MonoBehaviour
    {
        private float moveInput;
        [SerializeField] private InputHandler input;
        [SerializeField] private Rigidbody2D rb;
        private float easeInValue;
        public float currentTime;
        private float normalizedTime;
        private float duration = 1f;
        private Vector3 forwardDirection;
        // Update is called once per frame
        void Update()
        {
            transform.position = input.move;
            forwardDirection = rb.rotation * Vector3.up;
            moveInput = input.move.normalized.sqrMagnitude;
            if (moveInput > 0)
            {
                currentTime += Time.deltaTime;
                normalizedTime = currentTime / duration;
            }
            else
            {
                currentTime = 0;
            }
        
            easeInValue = moveInput * GameUtils.Easing.QuadEaseOut(normalizedTime, 0, 350f, normalizedTime);
            //Debug.Log($"<color=cyan> normalizedTime: {normalizedTime} </color>");
        }

        private void FixedUpdate()
        {
            rb.AddForce(input.move * easeInValue * Time.deltaTime);
        }
    }
}



