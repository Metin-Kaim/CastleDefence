using Runtime.Data.ValueObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Data.UnityObjects
{
    [CreateAssetMenu(fileName ="NewEntityDoc", menuName ="Self/Create Entity Doc")]
    public class SO_EntityDoc : ScriptableObject
    {
        public List<TextureAndEntity> List_TexturesAndEntities;
    }
}
