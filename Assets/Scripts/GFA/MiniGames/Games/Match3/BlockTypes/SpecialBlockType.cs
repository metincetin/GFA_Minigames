using UnityEngine;

namespace GFA.MiniGames.Games.Match3.BlockTypes
{
    [CreateAssetMenu(menuName = "Game Data/Match3/Special Block")]
	public class SpecialBlockType: BlockType
	{
		public override void ExecuteClickInteraction(BlockInstance blockInstance)
		{
			Debug.Log("YOU INTERACTED WITH A SPECIAL BLOCK");
		}
	}
}