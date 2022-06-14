using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MultiScene.General;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MultiScene.Managers
{
    public class ScenesManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Loading Progress Scene")]
        private List<AsyncOperation> _sceneLoadingOperations = new List<AsyncOperation>();
        private float _totalSceneProgress;

        private SceneIndex _loadedScene = SceneIndex.None;
        private List<SceneIndex> _loadedScenes = new List<SceneIndex>();

        public static ScenesManager Instance;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            if (Instance != this && Instance != null) Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        #endregion

        #region LOAD SCENE METHODS

        public void LoadAWorldScene_FromTitle(SceneIndex sceneIndex)
        {
            _loadedScene = sceneIndex;
            if (_sceneLoadingOperations == null) _sceneLoadingOperations = new List<AsyncOperation>();
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync((int)sceneIndex));

            StartCoroutine(GetLoadingProgress());
        }

        #endregion

        #region LOAD AND UNLOAD SCENE METHODS

        public void LoadWorldScene_FromTitle(SceneIndex sceneIndex)
        {
            _loadedScene = sceneIndex;
            if (_sceneLoadingOperations == null) _sceneLoadingOperations = new List<AsyncOperation>();
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(SceneIndex.Title.GetHashCode()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(sceneIndex.GetHashCode(), LoadSceneMode.Additive));

            StartCoroutine(GetLoadingProgress());
        }
        
        public void UnloadAWorldScene_ToTitle()
        {
            LoadAWorldScene_FromTitle(SceneIndex.Title);
        }

        public void UnloadWorldScene_ToTitle()
        {
            if (_loadedScenes.Any())
            {
                UnloadWorldScenes_ToTitle();
                return;
            }

            if (_sceneLoadingOperations == null) _sceneLoadingOperations = new List<AsyncOperation>();
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(_loadedScene.GetHashCode()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(SceneIndex.Title.GetHashCode(), LoadSceneMode.Additive));
            _loadedScene = SceneIndex.None;

            StartCoroutine(GetLoadingProgress());
        }

        public void LoadWorldScenes_FromTitle(List<SceneIndex> sceneIndices)
        {
            if (_sceneLoadingOperations == null) _sceneLoadingOperations = new List<AsyncOperation>();
            _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(SceneIndex.Title.GetHashCode()));
            foreach (SceneIndex sceneIndex in sceneIndices)
                _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(sceneIndex.GetHashCode(), LoadSceneMode.Additive));
            _loadedScenes = sceneIndices;

            StartCoroutine(GetLoadingProgress());
        }

        public void UnloadWorldScenes_ToTitle()
        {
            if (_sceneLoadingOperations == null) _sceneLoadingOperations = new List<AsyncOperation>();
            foreach (SceneIndex sceneIndex in _loadedScenes)
                _sceneLoadingOperations.Add(SceneManager.UnloadSceneAsync(sceneIndex.GetHashCode()));
            _sceneLoadingOperations.Add(SceneManager.LoadSceneAsync(SceneIndex.Title.GetHashCode(), LoadSceneMode.Additive));
            _loadedScenes.Clear();

            StartCoroutine(GetLoadingProgress());
        }

        #endregion

        #region PROGRESS METHOD

        private IEnumerator GetLoadingProgress()
        {
            for (int i = 0; i < _sceneLoadingOperations.Count; i++)
            {
                while (!_sceneLoadingOperations[i].isDone)
                {
                    _totalSceneProgress = 0;
                    foreach (AsyncOperation operation in _sceneLoadingOperations)
                    {
                        _totalSceneProgress += operation.progress;
                    }

                    _totalSceneProgress = (_totalSceneProgress / _sceneLoadingOperations.Count) * 100f;

                    // Loading Progress
                    // LoadingProgress.Current = Mathf.Round(_totalSceneProgress);

                    print(_totalSceneProgress);

                    yield return null;
                }
            }

            // Loading Progress
            // LoadingProgress.Current = Mathf.Round(_totalSceneProgress);
            _sceneLoadingOperations.Clear();
        }

        #endregion
    }
}