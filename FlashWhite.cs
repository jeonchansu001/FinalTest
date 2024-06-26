using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhite : MonoBehaviour
{
    private Material material;
    private Color originalColor;
    public float flashDuration = 0.5f;
    public float whiteIntensity = 0.5f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    public void StartFlash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < flashDuration)
        {
            elapsedTime += Time.deltaTime;
            float lerpValue = Mathf.PingPong(elapsedTime, flashDuration / 2) / (flashDuration / 2);
            material.color = Color.Lerp(originalColor, Color.white * whiteIntensity, lerpValue);
            yield return null;
        }
        material.color = originalColor; // 원래 색상으로 복원
    }
}
