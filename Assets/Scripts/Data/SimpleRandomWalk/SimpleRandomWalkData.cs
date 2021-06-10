using UnityEngine;

namespace Data.SimpleRandomWalk
{
    [CreateAssetMenu(fileName = "SimpleRandomWalkParams_", menuName = "PCG/SimpleRandomWalkData")]
    public class SimpleRandomWalkData : ScriptableObject
    {
        public int iterations = 10;
        public int walkLength = 10;
        public bool startEachIterationRandomly = true;
    }
}
