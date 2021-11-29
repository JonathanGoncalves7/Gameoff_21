using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    Animator transition;
    public float transationTime = 1f;

    public static LoadLevel Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        transition = transform.GetComponentInChildren<Animator>();
    }

    public void LoadLevelWithIndex(int levelIndex)
    {
        StartCoroutine(Load(levelIndex));
    }

    IEnumerator Load(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transationTime);

        SceneManager.LoadScene(levelIndex);
    }

    public IEnumerator StartCrossFade()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(5f);
    }

    public IEnumerator EndCrossFade()
    {
        transition.SetTrigger("End");

        yield return new WaitForSeconds(5f);
    }


}
