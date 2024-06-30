using UnityEngine;
using DG.Tweening;

namespace Draw.Scripts.Gameplay.Brush
{
    public class Movement
    {
        private const int HorizontalRotate = -70;
        private const int VerticalRotate = 70;
        
        private Transform _brushTransform;
        
        private Vector3 _previousPosition;
        private Vector3 _movementDirection;
        private Vector3 _targetRotation;

        private bool _isAttached;
        
        private int _horizontalDir;
        private int _verticalDir;
        
        private float _absX;
        private float _absY;

        public Movement(Transform brushTransform)
        {
            _brushTransform = brushTransform;
            _previousPosition = _brushTransform.position;
        }
        
        public void MoveHandler(Vector3 targetPos)
        {
            _brushTransform.position = targetPos;
            
            RotationHandler(targetPos);
            Rotate();   
        }
        private void RotationHandler(Vector3 targetPos)
        {
            _movementDirection = (targetPos - _previousPosition).normalized; 
            _previousPosition = targetPos;

             _absX = Mathf.Abs(_movementDirection.x); 
             _absY = Mathf.Abs(_movementDirection.y);
            
             _horizontalDir = 0;
             _verticalDir = 0;
             
            if (_absX > float.Epsilon || _absY > float.Epsilon)
            {
                if (_absX > _absY)
                {
                    _horizontalDir = _movementDirection.x > 0 ?  1 :  -1;
                }
                else
                {
                    _verticalDir = _movementDirection.y > 0 ? 1 : -1; 
                }
            }
        }

        private void Rotate()
        {
            _targetRotation = new Vector3(HorizontalRotate * _verticalDir, VerticalRotate * _horizontalDir, 0);
            _brushTransform.DOLocalRotate(_targetRotation, 0.5f);
        }
    }
}