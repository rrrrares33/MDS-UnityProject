using UnityEngine;

namespace Data.SimpleRandomWalk
{
    [CreateAssetMenu(fileName = "SimpleRandomWalkParams_", menuName = "PCG/SimpleRandomWalkData")]
    public class SimpleRandomWalkData : ScriptableObject
    {
        [SerializeField] private int iterations = 10;
        [SerializeField] private int walkLength = 10;
        [SerializeField] private bool startEachIterationRandomly = true;

        public int Iterations
        {
            get => iterations;
            set => iterations = value;
        }

        public int WalkLength
        {
            get => walkLength;
            set => walkLength = value;
        }

        public bool StartEachIterationRandomly
        {
            get => startEachIterationRandomly;
            set => startEachIterationRandomly = value;
        }
    }
}
