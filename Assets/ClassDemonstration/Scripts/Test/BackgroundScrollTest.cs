using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class BackgroundScrollTest : MonoBehaviour
    {
        public BackgroundScroller scroller1;
        public BackgroundScroller scroller2;

        public Sprite image1;
        public Sprite image2;
        
        private void Start()
        {
            GameData.isPlayable = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scroller1.SetImage(image1);
                scroller2.SetImage(image2);
            }
        }
    }
}