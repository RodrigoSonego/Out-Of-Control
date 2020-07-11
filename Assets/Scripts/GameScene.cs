using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct SomeScene
{
    public Scene scene;
    public bool wasLoaded;
}

[CreateAssetMenu(fileName = "Game Scene")]
public class GameScene : ScriptableObject
{
    public List<SomeScene> scenes;

}
