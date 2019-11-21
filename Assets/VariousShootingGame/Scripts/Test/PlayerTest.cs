using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VariousShooting
{
    public class PlayerTest : MonoBehaviour
    {
        private void Start()
        {
            GameData.isPlayable = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Player.AddExperience(55);
            }
        }
    }
}
