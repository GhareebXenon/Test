using UnityEngine;
using DG.Tweening;

public class ObjectAnimation : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 3, 0); // move upward
    public float duration = 1.5f; // how fast the animation happens

    void Start()
    {
        // Create a sequence to combine animations
        Sequence seq = DOTween.Sequence();

        // Move up
        seq.Append(transform.DOMove(targetPosition, duration)
            .SetEase(Ease.OutBounce));


        // Scale up at the same time
        seq.Join(transform.DOScale(Vector3.one * 1.5f, duration));


        // Rotate after that
        seq.Append(transform.DORotate(new Vector3(360,0 , 0), duration, RotateMode.FastBeyond360));

        // Make it loop forever (back and forth)
        seq.SetLoops(-1, LoopType.Yoyo);

        seq.Play();
    }
}
