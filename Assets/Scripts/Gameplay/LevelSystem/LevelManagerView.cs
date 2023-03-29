using System;
using TMPro;
using UnityEngine;

namespace Gameplay.LevelSystem
{
    public class LevelManagerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start()
        {
            LevelManager.Instance.OnLevelChanged += level =>
            {
                scoreText.text = $"Level: {level}";
            };
            
            scoreText.text = $"Level: {LevelManager.Instance.Level}";
        }
    }
}
