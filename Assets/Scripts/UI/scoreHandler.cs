using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static EventHandler;

public class scoreHandler : MonoBehaviour
{
    public int PlayerScore { get; set; }

    private void UpdateScoreUI()
    {
        GetComponent<TMP_Text>().SetText(string.Format("Score: {0}", ++PlayerScore));
    }

    // Start is called before the first frame update
    void Start()
    {
        EventHandler.OnBulletHit += UpdateScoreUI;
    }

    void OnDestroy()
    {
        EventHandler.OnBulletHit -= UpdateScoreUI;
    }
}
