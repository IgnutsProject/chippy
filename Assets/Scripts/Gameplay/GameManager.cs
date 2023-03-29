using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [SerializeField] private UnityEvent onGameOver;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void Lose()
        {
            Time.timeScale = 0;
            
            onGameOver.Invoke();
        }
    }
}
