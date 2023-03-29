using System;
using UnityEngine;

namespace Common
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        
        public Action<float> OnMoveX;
        public Action<float> OnMoveY;
        public Action<float> OnMouseX;
        public Action OnStartAttack;
        public Action OnEndAttack;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Update()
        {
            OnMoveX?.Invoke(Input.GetAxis(InputConfig.HorizontalAxis));
            OnMoveY?.Invoke(Input.GetAxis(InputConfig.VerticalAxis));
            OnMouseX?.Invoke(Input.GetAxis(InputConfig.MouseX));

            if (Input.GetKeyDown(InputConfig.AttackKey))
            {
                OnStartAttack?.Invoke();
            }
            
            if (Input.GetKeyUp(InputConfig.AttackKey))
            {
                OnEndAttack?.Invoke();
            }
        }
    }
}
