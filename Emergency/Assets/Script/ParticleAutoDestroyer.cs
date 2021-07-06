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
        //��ƼŬ�� ������� �ƴϸ� ����
        if(particle.isPlaying == false)
        {
            Destroy(this.gameObject);
        }      
    }
}
