using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsScripts : MonoBehaviour
{
    [SerializeField] private AudioSource _backGroundMusic;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _throwSound;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _toTheSeaSound;
    [SerializeField] private AudioSource _inTheCavesSound;
    [SerializeField] private AudioSource _blowSound;
    [SerializeField] private AudioSource _letterSound;
    [SerializeField] private AudioSource _crackSound;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _inTheCavesSound.Play();
        }

        _backGroundMusic.loop = true;
        _backGroundMusic.Play();
    }

    private void OnEnable()
    {
        PlayerInput.ShootEvent += ThrowSoundPlay;
        PlayerInput.JumpEvent += PlayJumpSound;
        Healths.IsDamagedEvent += PlayHitSound;
        Healths.IsDeadEvent += DeathSoundPlay;
        BoomScript.BlowEvent += PlayBlowSound;
        WhatDoesTheFoxSay.Talk += PlayToneSound;
        EnemyShoot.IsShootingEvent += ThrowSoundPlay;
        EarthCrack.Crack += PlayCrackSound;
    }

    private void OnDisable()
    {
        PlayerInput.ShootEvent -= ThrowSoundPlay;
        PlayerInput.JumpEvent -= PlayJumpSound;
        Healths.IsDamagedEvent -= PlayHitSound;
        Healths.IsDeadEvent -= DeathSoundPlay;
        BoomScript.BlowEvent -= PlayBlowSound;
        WhatDoesTheFoxSay.Talk -= PlayToneSound;
        EnemyShoot.IsShootingEvent -= ThrowSoundPlay;
        EarthCrack.Crack -= PlayCrackSound;
    }

    private void PlayCrackSound()
    {
        _crackSound.Play();
    }

    private void PlayToneSound()
    {
        _letterSound.Play();
    }

    private void PlayHitSound()
    {
        _hitSound.Play();
    }

    private void PlayJumpSound()
    {
        _jumpSound.Play();
    }

    private void DeathSoundPlay()
    {
        _deathSound.Play();
    }

    private void PlayBlowSound()
    {
        _blowSound.Play();
    }

    public void ToTheSeaSound()
    {
        _toTheSeaSound.Play();
    }

    private void ThrowSoundPlay()
    {
        _throwSound.Play();
    }
}
