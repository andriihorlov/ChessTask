using GLTFast;
using Unity.Properties;

namespace Chess.Game.States
{
    public class LoadingGeometry : GameState
    {
        private readonly GltfAsset _gltfAsset;
        private readonly string[] _paths;
        private readonly string _messageCantFindGtlf;

        public LoadingGeometry(GltfAsset gltfAsset, string[] paths, string messagesCantFindGtlfPath)
        {
            _gltfAsset = gltfAsset;
            _paths = paths;
            _messageCantFindGtlf = messagesCantFindGtlfPath;
        }
        
        public override void ActivateState()
        {
            base.ActivateState();
            LoadAsset();
        }

        private async void LoadAsset()
        {
            foreach (string path in _paths)
            {
                bool isLoaded = await _gltfAsset.Load(path);
                if (!isLoaded)
                {
                    continue;
                }
                
                CompleteStep();
                return;
            }

            throw new InvalidPathException(_messageCantFindGtlf);
        }
    }
}