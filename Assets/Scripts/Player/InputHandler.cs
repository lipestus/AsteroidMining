﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidMining.PlayerController
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 rotationValue { get; private set; }
        public Vector2 move{ get; private set; }
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput(context.ReadValue<Vector2>());
        }
        public void OnRotation(InputAction.CallbackContext context)
        {
            RotationInput(context.ReadValue<Vector2>());
        }
        private void RotationInput(Vector2 newRotationDirection) => rotationValue = newRotationDirection;
        private void MoveInput(Vector2 newMoveDirection) => move = newMoveDirection;
    }
}