using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GFA.MiniGames.Games.Match3
{
    public class BlockInstance : MonoBehaviour, IPointerDownHandler
    {
        public Vector2Int Position { get; set; }
        public LevelData LevelData { get; set; }
        public BlockType BlockType { get; set; }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            BlockType.ExecuteClickInteraction(this);
        }
    }
}
