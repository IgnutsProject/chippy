using System;
using System.Collections;
using Gameplay.Common;
using Gameplay.Common.Interfaces;
using TMPro;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyAttack : MonoBehaviour, ISwitchable
    {
        public static EnemyAttack Instance { get; private set; }
        
        [Header("Attack properties")] 
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float speedMuzzleRotation = 200f;
        [SerializeField] private float attackRate = 0.5f;

        [Header("Points")]
        [SerializeField] private Transform center;
        [SerializeField] private Transform directionPoint;
        [SerializeField] private Transform spawnPoint;
        
        private bool _isActive = true;

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }

        public float AttackRate
        {
            get => attackRate;
            set => attackRate = value;
        }


        private IEnumerator _attackDelayCoroutine;

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
            _attackDelayCoroutine = AttackDelay();
            StartCoroutine(_attackDelayCoroutine);
        }

        private void Update()
        {
            if (IsActive == false) return;
            
            Rotate();
        }

        private void Attack()
        {
            Projectile projectile = Instantiate(projectilePrefab, spawnPoint.position, center.rotation);

            projectile.Direction = directionPoint.position;
        }

        private IEnumerator AttackDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(attackRate);
                
                Attack();
            }
        }
        
        private void Rotate()
        {
            center.Rotate(Vector3.forward * speedMuzzleRotation * Time.deltaTime);
        }


        public void SwitchOff()
        {
            IsActive = false;
            
            StopCoroutine(_attackDelayCoroutine);
        }

        public void SwitchOn()
        {
            IsActive = true;
            
            _attackDelayCoroutine = AttackDelay();
            StartCoroutine(_attackDelayCoroutine);
        }
    }
}
