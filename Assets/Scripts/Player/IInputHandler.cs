using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public interface IInputHandler
    {
        public Vector2 rotationValue { get; set; }
        public Vector2 move{ get; set; }
        public bool isFiring { get; set; }
        public Vector2 aimRotation { get; set; }
    }
}