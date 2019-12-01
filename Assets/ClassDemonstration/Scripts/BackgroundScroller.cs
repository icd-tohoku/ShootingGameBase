using UnityEngine;

namespace MyGame
{
    public class BackgroundScroller : MonoBehaviour
    {
        public float scrollSpeed;
        public SpriteRenderer renderer;
        
        private void Update()
        {
            if (GameData.isPlayable == false)
            {
                return;
            }
            
            transform.Translate(-scrollSpeed, 0, 0);

            if (transform.position.x < -renderer.sprite.bounds.size.x * transform.localScale.x)
            {
                transform.position = new Vector3(renderer.sprite.bounds.size.x * transform.localScale.x, 0, 0);
            }
        }

        public void SetImage(Sprite image)
        {
            renderer.sprite = image;
        }
    }
}
