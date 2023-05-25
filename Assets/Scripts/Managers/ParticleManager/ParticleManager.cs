using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyInteraction.OnCollisionParticle += PlayParticle;
        EnemyBase.OnGameSuccessParticle += PlayParticle;
        PlayerStickmanSpawner.OnStickmanSpawnParticle += PlayParticle;
        GameFailLineInteraction.OnGameFailParticle += PlayParticle;
    }
    private void PlayParticle(int _index, Vector3 _position)
    {
        ParticleSystem part = transform.GetChild(_index).GetComponent<ParticleSystem>();
        transform.GetChild(_index).position = _position;
        part.Clear();
        part.Play();
    }
    private void OnDisable()
    {
        GameFailLineInteraction.OnGameFailParticle -= PlayParticle;
        EnemyInteraction.OnCollisionParticle -= PlayParticle;
        PlayerStickmanSpawner.OnStickmanSpawnParticle -= PlayParticle;
        EnemyBase.OnGameSuccessParticle -= PlayParticle;

    }
}
