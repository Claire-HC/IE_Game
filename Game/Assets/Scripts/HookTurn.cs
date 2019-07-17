using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookTurn : MonoBehaviour
{
    public GameObject hookTurnPanel;

    private void Start()
    {
        hookTurnPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hookTurnPanel.SetActive(true);
            StartCoroutine(WaitForSecs());
        }
    }

    IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(20);
        hookTurnPanel.SetActive(false);
    }
}