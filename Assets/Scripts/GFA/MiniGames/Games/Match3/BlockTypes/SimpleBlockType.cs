using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.MiniGames.Games.Match3.BlockTypes
{
    
    [CreateAssetMenu(menuName = "Game Data/Match3/Simple Block")]
    public class SimpleBlockType : BlockType
    {
        public override void ExecuteClickInteraction(BlockInstance blockInstance)
        {
            blockInstance.GetComponentInChildren<Image>().DOFade(0, 0.1f);
        }
    }
}
