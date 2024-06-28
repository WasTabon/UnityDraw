using Draw.Scripts.System.Input;
using UnityEngine;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Brush : MonoBehaviour
    {
        private Movement _movement;

        private bool _isInitialized;
        
        public void Initialize(InputManager inputManager)
        {
            _movement = new Movement(transform, inputManager);

            _isInitialized = true;
        }
    }
}
