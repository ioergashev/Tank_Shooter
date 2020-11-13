using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnimationController : MonoBehaviour
{
    private Vector3 lastFramePosition;
    private SpriteRenderer spriteRenderer;
    public List<Sprite> Sprites;

    public float AnimationDuration = 0.2f;
    private float LastAnimationTime;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        lastFramePosition = transform.position;
        LastAnimationTime = Time.time - AnimationDuration;
    }

    void Update()
    {
        if (Time.time >= LastAnimationTime + AnimationDuration && transform.position != lastFramePosition)
        {
            LastAnimationTime = Time.time;
            ChangeSprite();
        }
        lastFramePosition = transform.position;
    }

    private void ChangeSprite()
    {
        int currentItemIndex = Sprites.IndexOf(spriteRenderer.sprite);
        int nextItemIndex = currentItemIndex == Sprites.Count - 1 ? 0 : currentItemIndex+1;

        spriteRenderer.sprite = Sprites[nextItemIndex];
    }
}
