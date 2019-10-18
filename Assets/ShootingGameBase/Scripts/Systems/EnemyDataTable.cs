using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting.Systems
{
    [CreateAssetMenu]
    public class EnemyDataTable : ScriptableObject
    {
        public List<EnemyData> table;
    }

    [Serializable]
    public class EnemyData
    {
        [SerializeField] private string name;
        [SerializeField] private int hp = 1;
        [SerializeField] private int defeatPoint = 100;
        [SerializeField] private GameObject model = null;

        public string Name => name;
        public int HP => hp;
        public int DefeatPoint => defeatPoint;
        public GameObject Model => model;
    }
}