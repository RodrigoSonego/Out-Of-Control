using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{

    public Image fadePanel;

    private void Start()
    {
        print(SceneManager.GetSceneAt(0).isLoaded);
    }


    public void ChangeScene()
    {
        int index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        while (SceneManager.GetSceneByBuildIndex(index) == SceneManager.GetActiveScene())
        {
            index = Random.Range(1, SceneManager.sceneCountInBuildSettings);
        }
        SceneManager.LoadScene(index);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("fadeCoroutine");        
    }

    private IEnumerator fadeCoroutine()
    {     
        fadePanel.GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(1f);
        ChangeScene();
    }

}
