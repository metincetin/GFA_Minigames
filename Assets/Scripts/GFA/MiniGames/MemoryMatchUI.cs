using UnityEngine;

namespace GFA.MiniGames
{
	public class MemoryMatchUI : MonoBehaviour
	{
		[SerializeField] private MemoryMatchCard _cardPrefab;

		[SerializeField] private Transform _container;

		[SerializeField]
		private Sprite[] _cardSprites;

		private MemoryMatchCard _selectedCard;

		public void GenerateCards()
		{
			for (int x = 0; x < 4; x++)
			{
				for (int y = 0; y < 4; y++)
				{
					var inst = Instantiate(_cardPrefab, _container);
					inst.Sprite = _cardSprites[Random.Range(0, _cardSprites.Length)];
					inst.UpdateUI();
					inst.Close();
					inst.CardOpened += () => { OnCardOpened(inst); };
				}
			}
		}

		private void OnCardOpened(MemoryMatchCard inst)
		{
			if (_selectedCard)
			{
				if (_selectedCard.Sprite == inst.Sprite)
				{
					Debug.Log("CORRECT!");
					_selectedCard = null;
				}
				else
				{
					_selectedCard.Close();
					inst.Close();
					_selectedCard = null;
				}
			}
			else
			{
				_selectedCard = inst;
			}
		}
	}
}