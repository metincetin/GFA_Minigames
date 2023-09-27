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
			blockInstance.LevelData = this;
			
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
		
		public BlockInstance[] GetVertical(Vector2Int position)
		{
			var ret = new BlockInstance[GridSize.y];
			
			for (int y = 0; y < GridSize.y; y++)
			{
				var newPosition = new Vector2Int(position.x, y);
				ret[y] = GetBlock(newPosition);
			}
            
			return ret;
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

		public class LevelDataBuilder
		{
			private Vector2Int _size;
			private BlockType[] _blocks;

			public static LevelDataBuilder Create()
			{
				return new LevelDataBuilder();
			}
			
			public LevelDataBuilder SetGridSize(Vector2Int size)
			{
				_size = size;
				_blocks = new BlockType[_size.x * _size.y];
				return this;
			}
			
			public LevelDataBuilder SetBlock(Vector2Int position, BlockType blockType)
			{
				_blocks[GetIndexOfPosition(position)] = blockType;
				return this;
			}

			public LevelDataBuilder SetRemainingRandomly(params BlockType[] blocks)
			{
				for (var i = 0; i < _blocks.Length; i++)
				{
					var block = _blocks[i];
					if (block == null)
					{
						_blocks[i] = blocks[Random.Range(0, blocks.Length)];
					}
				}

				return this;
			}
			
			public int GetIndexOfPosition(Vector2Int position)
			{
				return position.x + position.y * _size.x;
			}
			
			public LevelData Build()
			{
				var ret = new LevelData();
				ret.GridSize = _size;
				ret._blocks = new BlockInstance[_size.x * _size.y];
				
				for (var i = 0; i < _blocks.Length; i++)
				{
					var blockType = _blocks[i];
					ret.CreateBlockInstanceAt(i, blockType);
				}

				return ret;
			}
			
		}
	}
}