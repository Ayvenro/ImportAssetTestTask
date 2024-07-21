using _Project.CodeBase.Infrastructure;
using UnityEngine;

namespace _Project.CodeBase.Logic.NPC
{
    public class NPCLife : MonoBehaviour
    {
        public void IncreaseScore()
        {
            Events.IncreaseScore();
            Destroy(this);
        }
    }
}