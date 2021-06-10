using Dungeon;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(DungeonGenerator), true)]
    public class DungeonGeneratorEditor : UnityEditor.Editor
    {
        private DungeonGenerator _generator;

        private void Awake()
        {
            _generator = (DungeonGenerator) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Generate Dungeon"))
            {
                _generator.GenerateDungeon();
            }
        }
    }
}
