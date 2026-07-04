using UnityEngine;

namespace _project.Scripts.Core.SDK.Firebase
{
    public class FirebaseManager : MonoBehaviour
    {
        public static FirebaseFacade Firebase { get; private set; }

        private void Awake()
        {
            Firebase = new FirebaseFacade();
            DontDestroyOnLoad(gameObject);
        }
    }
}