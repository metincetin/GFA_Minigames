using TMPro;
using UnityEngine;

namespace GFA.MiniGames.Data
{
    [CreateAssetMenu(menuName = "Data/Weighted Game Object Set")]
    public class WeightedGameObjectSet : ScriptableObject
    {
        [SerializeField]
        private WeightedGameObject[] _objects;

        private float TotalWeight
        {
            get
            {
                float weight = 0;
                foreach (var obj in _objects)
                {
                    weight += obj.Weight;
                }

                return weight;
            }
        }
        
        public GameObject SelectRandom()
        {
            var totalWeight = TotalWeight;
            var randomValue = Random.value * totalWeight;
            float currWeight = 0;
            
            foreach (var obj in _objects)
            {
                currWeight += obj.Weight;
                if (randomValue < currWeight)
                {
                    return obj.GameObject;
                }
            }
            return null;
        }
        

        [System.Serializable]
        public class WeightedGameObject
        {
            public GameObject GameObject;
            public float Weight;
        }
    }
}
