using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameOperationsSamples
{
    [RequireComponent(typeof(Button))]
    public class UseCaseButton : MonoBehaviour
    {
        public string sceneName;
        public Object readmeFile;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            var button = GetComponent<Button>();
            button.onClick.RemoveListener(OnButtonClick);
        }

        void OnButtonClick()
        {
            LoadScene();
            SelectReadmeFileOnProjectWindow();
        }
        
        void LoadScene()
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        
        void SelectReadmeFileOnProjectWindow()
        {
#if UNITY_EDITOR
            if (!(readmeFile is null))
            {
                Selection.objects = new Object[] {readmeFile};   
            }
#endif
        }
    }
}