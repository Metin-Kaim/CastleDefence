using UnityEngine;

namespace Runtime.Data.ValueObjects
{
    [System.Serializable]
    public class TextureAndEntity
    {
        public string EntityName;
        public int EntityIndex;
        public GameObject EntityObject;
        public Texture EntityTexture;
    }
}
