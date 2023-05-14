using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private int frame; //index of sprite

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f); //start animating function
    }

    private void OnDisable()
    {
        CancelInvoke(); //stop animating function
    }

    private void Animate()
    {
        frame++; //increase current frame

        if(frame >= sprites.Length)
        {
            frame = 0; //come back
        }

        if(frame >= 0 && frame < sprites.Length)//to prevent bounds error
        {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate), 1f/GameManager.Instance.gameSpeed); //"1/our game speed", faster animation speed
    }
}
