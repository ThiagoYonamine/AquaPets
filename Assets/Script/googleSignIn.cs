using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Google;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using System.Linq;

public class googleSignIn : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser FBuser;
    private string email;
    public Text Info;
    private bool goHome;
    Task<GoogleSignInUser> signIn;
    // Start is called before the first frame update
    void Start()
    {
        goHome = false;
        InitializeFirebase();
    }

    void InitializeFirebase()
    {
      
            Debug.Log("Setting up Firebase Auth");
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        
    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != null)
        {
            bool signedIn = FBuser != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && FBuser != null)
            {
                Debug.Log("Signed out " + FBuser.UserId);
                Info.text = "sign out " + FBuser.UserId.ToString() + " " + FBuser.Email;
            }
            FBuser = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + FBuser.UserId);
                Info.text = "sign in " + FBuser.UserId.ToString() + " " + FBuser.Email.ToString();
            }
        }
    }



    public void googleSignInButton()
    {
        GoogleSignIn.Configuration = new GoogleSignInConfiguration
        {
            RequestIdToken = true,
            RequestEmail=true,
            WebClientId = "839470842031-4r3tb633g6f6li070e0udahd6p6gs0qe.apps.googleusercontent.com"
        };

        TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();

        signIn = GoogleSignIn.DefaultInstance.SignIn();
        
        signIn.ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                signInCompleted.SetCanceled();
                Info.text = "canceled  1 " + FBuser.UserId.ToString();
            }
            else if (task.IsFaulted)
            {
                signInCompleted.SetException(task.Exception);
                Info.text = "is faulted 1 " + FBuser.UserId.ToString();
            }
            else
            {

                Credential credential = GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
               
                auth.SignInWithCredentialAsync(credential).ContinueWith(authTask =>
                {
                    if (authTask.IsCanceled)
                    {
                        signInCompleted.SetCanceled();
                        Info.text = "canceled  " + FBuser.UserId.ToString();
                    }
                    else if (authTask.IsFaulted)
                    {
                        signInCompleted.SetException(authTask.Exception);
                        Info.text = "is faulted  " + FBuser.UserId.ToString();
                    }
                    else
                    {
                        signInCompleted.SetResult(authTask.Result);
                        goHome = true;
                    }
                });
            }
        });
        
    }

    void Update()
    {
        if (goHome)
        {
            if (auth.CurrentUser!=null)
            {
                PlayerPrefs.SetString("userEmail", signIn.Result.Email);
                Info.text = "Signed in: " + signIn.Result.Email;

                if (signIn.Status.Equals(TaskStatus.RanToCompletion))
                {
                    Info.text += " #completed";
                    SceneManager.LoadScene("Home", LoadSceneMode.Single);
                }
            }
        }
    }
}