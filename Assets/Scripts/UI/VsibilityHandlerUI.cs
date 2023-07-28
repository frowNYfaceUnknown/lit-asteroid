using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VsibilityHandlerUI : MonoBehaviour
{
    private void Awake()
    {
        EventHandler.OnPlayerDeath += enableVisibility;
    }

    private void enableVisibility()
    {
        GetComponent<TMP_Text>().enabled = true;
    }

    private void OnDestroy()
    {
        EventHandler.OnPlayerDeath -= enableVisibility;
    }
}
