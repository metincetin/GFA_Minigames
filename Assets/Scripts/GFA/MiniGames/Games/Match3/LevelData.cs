using UnityEngine;

namespace GFA.MiniGames.Games.Match3
{
	public class LevelData
	{
		private BlockInstance[] _blocks;

		public Vector2Int GridSize { get; private set; }

		private BlockInstance CreateBlockInstanceAt(int index, BlockType blockType)
		{
			var inst = new GameObject("BlockInstance", typeof(RectTransform), typeof(BlockInstance));
			var blockInstance = inst.GetComponent<BlockInstance>();
			blockInstance.Position = GetPositionOfIndex(index);
			blockInstance.BlockType = blockType;
			var graphics = blockType.CreateGraphics();
			
			graphics.transform.SetParent(blockInstance.transform);
			
			var graphicsTransform = graphics.transform as RectTransform;
			graphicsTransform.offsetMax = Vector2.zero;
			graphicsTransform.offsetMin = Vector2.zero;

			_blocks[index] = blockInstance;

			return blockInstance;
		}

		public BlockInstance GetBlock(Vector2Int position)
		{
			return _blocks[GetIndexOfPosition(position)];
		}

		public int GetIndexOfPosition(Vector2Int position)
		{
			return position.x + position.y * GridSize.x;
		}

		public BlockInstance[] GetHorizontal(Vector2Int position)
		{
			var ret = new BlockInstance[GridSize.x];
			
			for (int x = 0; x < GridSize.x; x++)
			{
				var newPosition = new Vector2Int(x, position.y);
				ret[x] = GetBlock(newPosition);
			}
            
			return ret;
		}

		public Vector2Int GetPositionOfIndex(int index)
		{
			return new Vector2Int(index % GridSize.x, index / GridSize.x);
		}

		public static LevelData CreateRandom(Vector2Int gridSize, params BlockType[] blockTypes)
		{
			var levelData = new LevelData();
			levelData.GridSize = gridSize;
			levelData._blocks = new BlockInstance[gridSize.x * gridSize.y];

			for (var i = 0; i < levelData._blocks.Length; i++)
			{
				var randomBlockType = blockTypes[Random.Range(0, blockTypes.Length)];
				levelData.CreateBlockInstanceAt(i, randomBlockType);
			}

			return levelData;
		}
	}
}