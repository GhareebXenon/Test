using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // important for DOTween

public class UIImageAnimation : MonoBehaviour
{
    public Image targetImage;       // assign your image here
    public Vector3 targetPosition;  // where the image will move to
    public float duration = 1f;     // animation speed

    void Start()
    {
        // Make sure we have an image
        if (targetImage == null)
            targetImage = GetComponent<Image>();

        // Start with image invisible and small
        targetImage.color = new Color(1, 1, 1, 0);
        transform.localScale = Vector3.zero;

        // Sequence = combine multiple animations


        targetImage.DOFade(1f, duration)
    .OnComplete(() => {
        Debug.Log("Fade started!");
        targetImage.color = Color.red; // example: change color to red when fade begins
    });            // fade in
        transform.DOScale(Vector3.one, duration);         // scale up
        transform.DOLocalMove(targetPosition, duration); // move after fade+scale

       
    }
}
