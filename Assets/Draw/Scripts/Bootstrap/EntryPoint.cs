using System;
using Draw.Scripts.Gameplay.Brush;
using Draw.Scripts.System.Input;
using Draw.Scripts.System.Utils;
using UnityEngine;

namespace Draw.Scripts.Bootstrap
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Brush _brush;

        private InputManager _inputManager;
        private Updater _updater;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
           CreateUpdater();
           CreateInputManager();
           CreateBrush(_inputManager);
           
           _updater.RegisterUpdatable(_inputManager);
        }
        
        private void CreateUpdater()
        {
            GameObject created = new GameObject("Updater");
            Updater updater = created.AddComponent<Updater>();
            updater.Initialize();
            
            _updater = updater;
        }

        private void CreateInputManager()
        {
            _inputManager = new InputManager();
        }

        private void CreateBrush(InputManager inputManager)
        {
            _brush.Initialize(inputManager);
        }
    }
}
