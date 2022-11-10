using System;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject currentLevel;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private ScreenFade screenFade;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerStartPos;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<PlayerMovement>().isFinish = true;
            screenFade.fadeOut();
            _animator.SetBool("Opened", true);
            Invoke("NextLevel", 1f);
        }
    }

    private void NextLevel()
    {
        _animator.SetBool("Opened", false);
        player.position = playerStartPos.position;
        currentLevel.SetActive(false);
        nextLevel.SetActive(true);
        screenFade.fadeIn();
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isFinish = false;
    }
}
