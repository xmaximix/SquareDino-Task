using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private Vector3 lowScale = new Vector3(.9f, .9f, .9f);
    private Vector3 highScale = new Vector3(1.1f, 1.1f, 1.1f);

    void Start() 
    { 
        StartCoroutine(AnimateSize(text.rectTransform));
    }

    IEnumerator AnimateSize(RectTransform rectTransform)
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                rectTransform.localScale = Vector3.Lerp(lowScale, highScale, t);
                yield return null;
            }

            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                rectTransform.localScale = Vector3.Lerp(highScale, lowScale, t);
                yield return null;
            }
        }
    }
}
