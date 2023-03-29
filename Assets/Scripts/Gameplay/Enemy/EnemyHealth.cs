using System;
using Common;
using Gameplay.Common;
using Gameplay.Common.Interfaces;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyHealth : Health
    {
        public static EnemyHealth Instance { get; private set; }

        [Header("Death time")] 
        [SerializeField] private float deathTime = 2;

        [Header("Enemy")] 
        [SerializeField] private Collider2D enemyCollider;
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private EnemyMovement enemyMovement;
        
        [Header("Graphic")] 
        [SerializeField] private Transform graphic;

        protected override void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            
            base.Awake();
        }

        private void Start()
        {
            OnValueZero += () =>
            {
                if (enemyAttack.IsActive == false || enemyMovement.IsActive == false) return;
                
                (enemyAttack as ISwitchable).SwitchOff();
                (enemyMovement as ISwitchable).SwitchOff();
                
                enemyCollider.enabled = false;
                graphic.gameObject.SetActive(false);

                StartCoroutine(Utils.MakeActionDelay(deathTime, () =>
                {
                    (enemyAttack as ISwitchable).SwitchOn(); 
                    (enemyMovement as ISwitchable).SwitchOn();

                    enemyCollider.enabled = true;
                    graphic.gameObject.SetActive(true);
                }));
            };
        }
    }
}