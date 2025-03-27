using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public void Changescene(string sceneName)
    {
        LevelManager.instance.LoadScene(sceneName);
    }

}
