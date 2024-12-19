using Chess.Data;
using Cysharp.Threading.Tasks;
using GLTFast;
using Unity.Properties;

namespace Chess.Game.States
{
    public class LoadingGeometry : GameState
    {
        private readonly string[] _paths;
        private readonly string _messageCantFindGtlf;
        
        public GltfImport GltfImport { get; private set; }

        public LoadingGeometry(GameConfig paths, MessagesConfig messageConfig)
        {
            _paths = paths.GetAssetPaths();
            _messageCantFindGtlf = messageConfig.CantFindGtlfPath;
        }
        
        public override void ActivateState(object data = null)
        {
            base.ActivateState(data);
            GltfImport = new GltfImport();
            LoadAsset().Forget();
        }
        
        private async UniTaskVoid LoadAsset()
        {
            foreach (string path in _paths)
            {
                bool isLoaded = await GltfImport.Load(path).AsUniTask();
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