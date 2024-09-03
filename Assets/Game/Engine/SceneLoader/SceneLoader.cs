using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public static SceneLoader inst { get; private set; }

    [SerializeField] private float timeToFade = 0.5f;
    [SerializeField] private AnimationClip fadeoutClip;
    private Animation anim => GetComponent<Animation>();

    public void LoadScene(int id, bool saveState = false) => StartCoroutine(FadeAndLoad(SceneUtility.GetScenePathByBuildIndex(id), false));
    public void LoadScene(string scene, bool saveState = false) => StartCoroutine(FadeAndLoad(scene, false));
    public void ExitGame() => Application.Quit();

    private IEnumerator FadeAndLoad(string sceneName, bool doUnpause) {
        //Animation
        anim.clip = fadeoutClip;
        anim.Play();
        yield return new WaitForSeconds(timeToFade);
        SceneManager.LoadScene(sceneName);
        if (doUnpause) DialogueSystem.inst.Pause(false);
    }

    private void Awake() {
        if (inst != null && inst != this) {
            Destroy(this);
        } else {
            inst = this;
        }
    }
}
