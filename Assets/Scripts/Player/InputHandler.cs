using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidMining.PlayerController
{
    public class InputHandler : MonoBehaviour, IInputHandler
    {
        public Vector2 rotationValue { get; set; }
        public Vector2 move{ get; set; }
        public bool isFiring { get; set; }
        public Vector2 aimRotation { get; set; }
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput(context.ReadValue<Vector2>());
        }
        public void OnRotation(InputAction.CallbackContext context)
        {
            RotationInput(context.ReadValue<Vector2>());
        }
        public void OnFire(InputAction.CallbackContext context)
        {
            FireInput(context.ReadValue<float>());
            //Debug.Log($"<color=red>fireThreshold: {context.ReadValue<float>()} </color>");
        }
        public void OnAim(InputAction.CallbackContext context)
        {
            AimRotation(context.ReadValue<Vector2>());
        }
        private void RotationInput(Vector2 newRotationDirection) => rotationValue = newRotationDirection;
        private void MoveInput(Vector2 newMoveDirection) => move = newMoveDirection;
        private void FireInput(float fireThreshold) => isFiring = fireThreshold > 0;
        private void AimRotation(Vector2 newRotationAim) => aimRotation = newRotationAim;
    }
}