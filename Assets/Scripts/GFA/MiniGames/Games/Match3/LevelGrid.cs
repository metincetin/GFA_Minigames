using UnityEngine;
using UnityEngine.UI;

namespace GFA.MiniGames.Games.Match3
{
    public class LevelGrid : MonoBehaviour
    {
        private LevelData _levelData;
        
        [SerializeField]
        private Vector2Int _gridSize;

        [SerializeField]
        private BlockType[] _blocks;
        
        [SerializeField]
        private GridLayoutGroup _grid;
        
        private void Start()
        {
            _levelData = LevelData.CreateRandom(_gridSize, _blocks);

            for(int x = 0;x<_gridSize.x;x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    var blockInstance = _levelData.GetBlock(new Vector2Int(x, y));
                    blockInstance.transform.SetParent(_grid.transform);
                }
            }

            _grid.constraintCount = _gridSize.x;
        }
    }
}
