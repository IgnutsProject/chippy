using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.Common
{
    public class Health : MonoBehaviour
    {
        [Header("General properties")] 
        [SerializeField] private float startValue = 20f;
        [SerializeField] private float maxValue = 20;

        [Header("Events")] 
        [SerializeField] private UnityEvent<float> onValueChanged;
        [SerializeField] private UnityEvent onValueZero;
        
        private float _value;

        public float MaxValue
        {
            get => maxValue;
            set => maxValue = value;
        }

        public float Value
        {
            get => _value;
            set
            {
                _value = value;

                if (_value <= 0)
                {
                    onValueZero.Invoke();
                }
                
                onValueChanged.Invoke(_value);
            }
        }
        
        public event UnityAction<float> OnValueChanged
        {
            add => onValueChanged.AddListener(value);
            remove => onValueChanged.RemoveListener(value);
        }
        
        public event UnityAction OnValueZero
        {
            add => onValueZero.AddListener(value);
            remove => onValueZero.RemoveListener(value);
        }

        protected virtual void Awake()
        {
            Value = startValue;
        }
    }
}