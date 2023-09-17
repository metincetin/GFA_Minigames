using System;
using UnityEngine;

namespace GFA.MiniGames.Games.Spaceshooter
{
    public class ShipMovement : MonoBehaviour
    {
        public Vector2 MovementInput { get; set; }

        [SerializeField]
        private float _acceleration = 4;
        
        [SerializeField]
        private float _maxSpeed = 5;
        
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(MovementInput * _acceleration * Time.deltaTime, ForceMode2D.Force);

            _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
        }
    }
}
