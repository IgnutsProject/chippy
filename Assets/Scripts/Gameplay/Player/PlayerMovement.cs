using Common;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Graphics")] 
        [SerializeField] private Transform graphic;
        
        [Header("Movement properties")]
        [SerializeField] private float speedMovement = 7f;
        [SerializeField] private float speedRotation = 70f;
        
        
        private Rigidbody2D _rigidbody;
        private Vector3 _velocity;
        private Quaternion _targetRotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            InputManager.Instance.OnMoveX += value =>
            {
                _velocity.x = value * speedMovement;
            };

            InputManager.Instance.OnMoveY += value =>
            {
                _velocity.y = value * speedMovement;
            };
        }

        private void Update()
        {
            Rotate();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _velocity;
        }

        private void Rotate()
        {
            if (_velocity.x == 0 && _velocity.y == 0) return;
            
            _targetRotation = Quaternion.LookRotation(transform.forward, _velocity);
            
            graphic.rotation = Quaternion.RotateTowards(
                graphic.rotation, 
                _targetRotation, 
                Time.deltaTime * speedRotation);
        }
    }
}
