using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[DisallowMultipleComponent]
public class ScreenEdgeDetection : MonoBehaviour
{
    [SerializeField] GameObject target;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(target.transform.position - new Vector3(0f, target.transform.localScale.x / 2, 0f));
            if (pos.y < 0.0)
            {
                if (target.tag == "Player")
                {
                    if (!player.hasLost)
                    {
                        CameraShakeManager.instance.ShakeCamera(player.cinemachineImpulseSource);
                        player.explosionParticleSystem.Play();
                        player.playerControl.DisableControl();
                        player.hasLost = true;
                        AudioManager.instance.PlaySound(AudioManager.instance.crashSound);
                        Handheld.Vibrate();
                    } else {
                        Destroy(target, 0.2f);
                    }
                }
            }
        }
    }
}
