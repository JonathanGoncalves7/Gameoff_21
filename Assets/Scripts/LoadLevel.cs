using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    Animator transition;
    public float transationTime = 1f;

    // Start is called before the first frame update

    void Start()
    {
        transition = transform.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
