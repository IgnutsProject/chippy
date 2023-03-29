using System;
using Gameplay.Enemy;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Gameplay.LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        [SerializeField] private float enemyHealthIncreaseValue = 10f;
        [SerializeField] private float enemyAttackRateDecreaseValue = 0.01f;
        
        private int _level = 1;

        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                
                OnLevelChanged?.Invoke(_level);
            }
        }

        public Action<int> OnLevelChanged;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            EnemyHealth.Instance.OnValueZero += () =>
            {
                Level++;

                EnemyHealth.Instance.MaxValue += enemyHealthIncreaseValue;
                EnemyHealth.Instance.Value = EnemyHealth.Instance.MaxValue;

                EnemyAttack.Instance.AttackRate -= enemyAttackRateDecreaseValue;
                
                Debug.Log(EnemyHealth.Instance.Value);
            };
        }
    }
}
