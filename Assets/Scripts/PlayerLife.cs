using System;
using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;

public class PlayerLife : MonoBehaviour
{
    private float life = 1;

    [SerializeField] private MeshRenderer body;
    [SerializeField] private CinemachineBasicMultiChannelPerlin cameraShake;
    Sequence damageSequence;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        
        damageSequence = DOTween.Sequence();
        damageSequence.Append(body.material.DOColor(Color.red, 0.3f))
            .AppendCallback(()=>cameraShake.enabled= true)
            .AppendInterval(.25f)
                        .AppendCallback(() => body.material.DOColor(Color.white, 0.3f))
            .AppendCallback(()=>cameraShake.enabled= false)            
            .AppendCallback(()=> damageSequence.Rewind());
        //damageSequence.Rewind();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLife(float change)
    {
        if (change < 0)
            TweenDamage();
        life += change; ;
        UIHandler.instance.UpdateHealthBar(life);
    }

    public void RestartLife()
    {
        life = 1;
        UIHandler.instance.UpdateHealthBar(life);
    }

    public float GetLife()
    {
        return life;
    }

    void TweenDamage()
    {
        damageSequence.Play();
    }
}
