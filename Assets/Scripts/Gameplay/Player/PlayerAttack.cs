using System;
using System.Collections;
using Common;
using Gameplay.Common;
using UnityEngine;
using UnityEngine.Windows.WebCam;

namespace Gameplay.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [Header("Spawn properties")]
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform spawnPoint;

        [Header("Attack properties")] 
        [SerializeField] private float speedRotation = 60f;
        [SerializeField] private float attackRate = 0.3f;
        [SerializeField] private Transform center;
        [SerializeField] private Transform directionPoint;

        private IEnumerator _attackCoroutine;

        private void Start()
        {
            InputManager.Instance.OnStartAttack += () =>
            {
                _attackCoroutine = AttackDelay();
                StartCoroutine(_attackCoroutine);
            };

            InputManager.Instance.OnEndAttack += () =>
            {
                StopCoroutine(_attackCoroutine);
            };

            InputManager.Instance.OnMouseX += value =>
            {
                if (value == 0) return;
                
                center.Rotate(Vector3.back * speedRotation * Time.deltaTime * value);
            };
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
    }
}
