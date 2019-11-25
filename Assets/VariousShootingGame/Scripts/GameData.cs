using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public static class GameData
    {
        public const int MaxHitPoint = 100;
        public const int MaxMagicPoint = 100;

        public static int hitPoint = MaxHitPoint;
        public static int experiencePoint = 0;
        public static int level = 1;
        public static int magicPoint = 0;

        public static bool isPlayable = false;
    }
}
