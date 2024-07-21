using System;
using _Project.CodeBase.Infrastructure.Services.PersistentProgress;

namespace _Project.CodeBase.Infrastructure
{
    public class Events
    {
        public static Action OnScoreIncreased;

        public static void IncreaseScore()
        {
            OnScoreIncreased?.Invoke();
        }
    }
}