using UnityEngine;

namespace Chess.Data
{
    [CreateAssetMenu(fileName = "Config", menuName = "Chess/Config")]
    public class GameConfig : ScriptableObject
    {
        [field: SerializeField] public int MouseButtonId { get; private set; }
        [field: SerializeField] public string PivotObjectName { get; private set; }
        [field: SerializeField] public string SpawnObjectName { get; private set; } = "GLTF Model";
        
        [field: Header("Path"), SerializeField] private string DefaultAssetPath { get; set; } =
            "https://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/d7a3cc8e51d7c573771ae77a57f16b0662a905c6/2.0/ABeautifulGame/glTF/ABeautifulGame.gltf";
        [field: SerializeField] private string AnalogAssetPath { get; set; } =
            "file://raw.githubusercontent.com/KhronosGroup/glTF-Sample-Models/d7a3cc8e51d7c573771ae77a57f16b0662a905c6/2.0/ABeautifulGame/glTF/ABeautifulGame.gltf";
        
        public string[] GetAssetPaths() => new string[2] {DefaultAssetPath, AnalogAssetPath};
    }
}