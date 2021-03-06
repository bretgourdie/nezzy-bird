﻿using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;

namespace NezzyBird.Components
{
    public class FloatIn : Component
    {
        public float TimePassed { get; private set; }

        public readonly float TotalTime;

        public readonly Vector2 StartPosition;

        public readonly Vector2 EndPosition;

        public readonly EaseType EaseType;

        public bool PlayedTransitionSwoosh { get; set; }

        public FloatIn(
            Vector2 startPosition,
            Vector2 endPosition,
            EaseType easeType,
            float totalTime)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            EaseType = easeType;

            TotalTime = totalTime;
        }

        public void PassTime(float deltaTime)
        {
            TimePassed += deltaTime;
        }
    }
}
