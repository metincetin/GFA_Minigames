using System;
using GFA.MiniGames.Input;
using UnityEngine;

namespace GFA.MiniGames.Games.Spaceshooter
{
    public class Player : MonoBehaviour
    {
        private GameInput _gameInput;
        private ShipMovement _shipMovement;

        private void Awake()
        {
            _gameInput = new GameInput();
            _shipMovement = GetComponent<ShipMovement>();
        }

        private void Update()
        {
            _shipMovement.MovementInput = _gameInput.Main.LeftAnalog.ReadValue<Vector2>();
        }
    }
}
