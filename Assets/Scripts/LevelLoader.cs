using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private float firstAnimationTime = 3f;
        [SerializeField] private float secondAnimationTime= 2f ;
        [SerializeField] private Animator animator;
        [SerializeField] private Canvas canvas;

        private static LevelLoader instance;
        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }
        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
            }
            else
            {
                instance = new LevelLoader();
                DontDestroyOnLoad(this);
            }
        }

        public void LoadNextScene()
        {
            StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex + 1));
            DontDestroyOnLoad(canvas);
        }
        
        private IEnumerator ChangeScene(int sceneIndex)
        {
            yield return new WaitForSeconds(firstAnimationTime);
            animator.SetBool("PackageReceived", true);
            SceneManager.LoadScene(sceneIndex);
            yield return new WaitForSeconds(secondAnimationTime);
            
        }
    }
}