using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    private bool playerIsDead = true;

    public delegate void BulletHit();
    public static event BulletHit OnBulletHit;

    public delegate void deadPlayer();
    public static event deadPlayer OnPlayerDeath;

    public void TriggerOnBulletHit()
    {
        OnBulletHit?.Invoke();
    }

    public void TriggerOnPlayerDeath()
    {
        playerIsDead = true;
        OnPlayerDeath?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {Application.Quit(); }

        if (!playerIsDead) { return; }

        if (Input.GetKeyDown(KeyCode.Space)) { playerIsDead = false; SceneManager.LoadScene(1); }
    }
}
