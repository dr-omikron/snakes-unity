using System;
using UnityEngine;

namespace _SnakesGame.Scripts.Character
{
    [RequireComponent(typeof(GameplayInputManager))]
    [RequireComponent(typeof(AnimationsController))]

    public class CharacterAttackHandler : MonoBehaviour
    {
        private GameplayInputManager _gameplayInputManager;
        private AnimationsController _animationsController;

        private bool _isLongAttack;

        private void Awake()
        {
            _gameplayInputManager = GetComponent<GameplayInputManager>();
            _animationsController = GetComponent<AnimationsController>();

            _gameplayInputManager.OnAttackPressed += OnAttackPressed;
            _gameplayInputManager.OnAttackReleased += OnAttackReleased;

            _animationsController.SetAnimatorIsLongAttack(_isLongAttack);
        }

        private void OnAttackPressed() => _animationsController.SetAnimatorStartAttackTrigger();

        private void OnAttackReleased()
        {
            
        }
    }
}
