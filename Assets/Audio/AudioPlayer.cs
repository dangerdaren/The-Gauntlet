using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip enemyHurt;
    [SerializeField] AudioClip enemyDie;

    [SerializeField] AudioSource towerAudio;
    [SerializeField] AudioClip placeTowerSFX;
    [SerializeField] AudioClip towerRemoveSFX;
    [SerializeField] AudioClip denyTowerPlace;

    [SerializeField] AudioClip enemyBreakInSFX;

    TargetLocator tower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEnemyHurt()
    {
        enemyAudio.PlayOneShot(enemyHurt);
    }

    public void PlayEnemyDown()
    {
        enemyAudio.PlayOneShot(enemyDie, 3f);
    }

    public void PlayTowerPlace()
    {
        towerAudio.PlayOneShot(placeTowerSFX, .5f);
    }

    public void PlayTowerRemove()
    {
        towerAudio.PlayOneShot(towerRemoveSFX, 1.5f);
    }

    public void PlayTowerDeny()
    {
        towerAudio.PlayOneShot(denyTowerPlace);
    }

    public void PlayEnemyStealsGold()
    {
        towerAudio.PlayOneShot(enemyBreakInSFX);
    }
}
