using UnityEngine;

namespace GFA.MiniGames.Games.Match3
{
    public class BlockType : MonoBehaviour
    {
        [SerializeField]
        private GameObject _graphics;

        public virtual GameObject CreateGraphics()
        {
            return Instantiate(_graphics);
        }
    }
}
