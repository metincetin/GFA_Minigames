using UnityEngine;

namespace GFA.MiniGames.Games.Match3
{
    public abstract class BlockType : ScriptableObject
    {
        [SerializeField]
        private GameObject _graphics;

        public virtual GameObject CreateGraphics()
        {
            return Instantiate(_graphics);
        }
    }
}
