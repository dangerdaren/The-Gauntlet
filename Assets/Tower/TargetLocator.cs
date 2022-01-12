using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    public ParticleSystem boltParticle;
    [SerializeField] float towerRange = 15;

    [SerializeField] AudioClip arrowFireSFX;
    Transform target;

    Tower tower;

    GameManager gameManager;

    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }
    //this is an expensive method for larger games. In that case, only call if target dies or leaves range.
    private void FindClosestTarget() 
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestEnemy = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestEnemy;
    }

    private void AimWeapon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);

            weapon.LookAt(target);

            if (targetDistance <= towerRange)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }

    }

    void Attack(bool canFire)
    {
        tower = GetComponentInParent<Tower>();

        var boltEmitter = boltParticle.emission;
        boltEmitter.enabled = canFire;

        var towerAudio = GetComponent<AudioSource>();


        if (!gameManager.IsPaused && boltParticle.particleCount == 1 && !towerAudio.isPlaying && canFire)
        {
            towerAudio.PlayOneShot(arrowFireSFX, .2f);
        }

    }
}
