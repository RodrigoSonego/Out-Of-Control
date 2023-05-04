using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public Image fadePanel;
    public static int numberOfScenesLoaded;

    private int currentSceneIndex;

    private void Start()
    {
        print(SceneManager.GetSceneAt(0).isLoaded);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(currentSceneIndex);
    }


    public void ChangeScene()
    {
        if(numberOfScenesLoaded == 8)
        {
            SceneManager.LoadScene(8);
            SceneManager.UnloadSceneAsync(currentSceneIndex);
            numberOfScenesLoaded++;
            return;
        } else if (numberOfScenesLoaded == 9)
        {
            SceneManager.LoadScene(9);
        }

        int index = Random.Range(1, 8);
        Scene nextScene = SceneManager.GetSceneByBuildIndex(index);
        while (nextScene == SceneManager.GetActiveScene() && nextScene.isLoaded)
        {
            index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        }
        SceneManager.LoadScene(index);
        numberOfScenesLoaded++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine("fadeCoroutine");        
    }

    private IEnumerator fadeCoroutine()
    {     
        fadePanel.GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        ChangeScene();
    }

}
