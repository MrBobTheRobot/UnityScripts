using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

public class HoverGrowVisuals : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    [SerializeField] private Vector3 hoverScale = new Vector3(1.05f, 1.05f, 1.05f);
    [SerializeField] private float animationDuration = 0.1f;

    [SerializeField] private TextMeshProUGUI buttonText; // Assign this in Inspector
 

    void Start()
    {
        originalScale = transform.localScale;

        //Check for TMP gui 
        if (buttonText == null)
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(hoverScale));

        // Make text bold
        if (buttonText != null)
            buttonText.fontStyle |= FontStyles.Bold;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(ScaleTo(originalScale));

        // Remove bold
        if (buttonText != null)
            buttonText.fontStyle &= ~FontStyles.Bold;
    }

    private IEnumerator ScaleTo(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float time = 0f;

        while (time < animationDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / animationDuration);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}