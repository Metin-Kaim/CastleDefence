
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Abstract.Enemies
{
    public abstract class AbsEnemy : MonoBehaviour
    {
        public int Index;
        public List<Transform> List_pathPoints = new();
        public Transform hitPoint;
    }
}
