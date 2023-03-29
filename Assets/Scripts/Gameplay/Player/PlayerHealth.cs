using System;
using Gameplay.Common;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerHealth : Health
    {
        protected override void Awake()
        {
            base.Awake();

            OnValueZero += () =>
            {
                GameManager.Instance.Lose();
            };
        }
    }
}