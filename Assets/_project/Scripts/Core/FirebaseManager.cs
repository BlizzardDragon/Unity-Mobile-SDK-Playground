using _project.Scripts.Services.Firebase;
using UnityEngine;

namespace _project.Scripts.Core
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