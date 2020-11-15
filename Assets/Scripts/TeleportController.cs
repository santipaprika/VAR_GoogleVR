using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TeleportController : InteractableItem
{
    public Transform player;
    public Image colorImage;
    public int fadeSpeed = 5;

    override public void OnButtonDownB() {
        StartCoroutine(FadeTP(fadeSpeed));
    }

    IEnumerator FadeTP(int fadeSpeed = 3) {
        float fadeAmount;
        while (colorImage.color.a < 1) {
            fadeAmount = colorImage.color.a + fadeSpeed * Time.deltaTime;
            colorImage.color = new Color(colorImage.color.r, colorImage.color.g, colorImage.color.b, fadeAmount);
            yield return null;
        }

        player.position = new Vector3(transform.position.x, transform.position.y + player.position.y, transform.position.z);
        
        while (colorImage.color.a > 0) {
            fadeAmount = colorImage.color.a - fadeSpeed * Time.deltaTime;
            colorImage.color = new Color(colorImage.color.r, colorImage.color.g, colorImage.color.b, fadeAmount);
            yield return null;
        }
    }
}
