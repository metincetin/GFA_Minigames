using UnityEngine;
using System;
using UnityEngine.UI;

namespace GFA.MiniGames.Games.Match3
{
	public class LevelGrid : MonoBehaviour
	{
		private LevelData _levelData;

		[SerializeField] private Vector2Int _gridSize;

		[SerializeField] private BlockType[] _blocks;

		[SerializeField] private GridLayoutGroup _grid;

		[SerializeField] private BlockType _specialBlock;

		private void Start()
		{
			// _levelData = LevelData.CreateRandom(_gridSize, _blocks);
			var levelDataBuilder = LevelData.LevelDataBuilder.Create()
				.SetGridSize(_gridSize)
				.SetBlock(new Vector2Int(0, 0), _specialBlock)
				.SetBlock(new Vector2Int(5, 0), _specialBlock)
				.SetRemainingRandomly(_blocks);

			_levelData = levelDataBuilder.Build();

			var randomBuilder = LevelData.LevelDataBuilder.Create()
				.SetGridSize(_gridSize)
				.SetRemainingRandomly(_blocks);

			for (int y = 0; y < _gridSize.y; y++)
			{
				for (int x = 0; x < _gridSize.x; x++)
				{
					var blockInstance = _levelData.GetBlock(new Vector2Int(x, y));
					blockInstance.transform.SetParent(_grid.transform);
				}
			}

			_grid.constraintCount = _gridSize.x;
		}
	}
}