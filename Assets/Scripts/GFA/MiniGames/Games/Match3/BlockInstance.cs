using UnityEngine;

namespace GFA.MiniGames.Games.Match3
{
    public class BlockInstance : MonoBehaviour
    {
        public Vector2Int Position { get; set; }
        public LevelData LevelData { get; set; }
        public BlockType BlockType { get; set; }
    }
}
