using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDestroyer : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //파티클이 재생주이 아니면 삭제
        if(particle.isPlaying == false)
        {
            Destroy(this.gameObject);
        }      
    }
}
