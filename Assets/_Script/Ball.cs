using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnEnable() => StartCoroutine(Disable());

    private void OnDisable() => StopCoroutine(Disable());

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}