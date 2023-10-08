using System;
using GFA.MiniGames.Input;
using UnityEngine;

namespace GFA.MiniGames.Games.FruitNinja
{
    public class Player : MonoBehaviour
    {
        private GameInput _gameInput;
        private Camera _camera;
        

        private void Awake()
        {
            _gameInput = new GameInput();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _gameInput.Enable();
        }
        
        private void OnDisable()
        {
            _gameInput.Disable();
        }

        private void Update()
        {
            if (!_gameInput.Generic.Click.IsPressed()) return;
            
            var mousePosition = _gameInput.Generic.PointerPosition.ReadValue<Vector2>();
            var ray = _camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.rigidbody.TryGetComponent(out ICuttable cuttable))
                {
                    cuttable.Cut(Vector3.up, 0);
                }
            }
        }
    }
}
