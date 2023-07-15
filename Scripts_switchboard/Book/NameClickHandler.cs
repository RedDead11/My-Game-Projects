//using UnityEngine;

//public class NameClickHandler : MonoBehaviour
//{
//    public string correctName;

//    private void OnMouseDown()
//    {
//        if (gameObject.name == correctName)
//        {
//            Debug.Log("Level Passed");
//        }
//        else
//        {
//            Debug.Log("Wrong Name Selected");
//        }
//    }
//}





//using UnityEngine;
//using System.Collections;

//public class NameClickHandler : MonoBehaviour
//{
//    public string correctName;
//    public Bookshelf bookshelf;
//    public Timer timer;

//    private void OnMouseDown()
//    {
//        if (!timer.timeOver && gameObject.name == correctName)
//        {
//            Debug.Log("Level Passed");
//            StartCoroutine(CloseBookWithDelay());
//        }
//        else
//        {
//            Debug.Log("Wrong Name Selected");
//        }
//    }

//    private IEnumerator CloseBookWithDelay()
//    {
//        yield return new WaitForSeconds(2f);
//        bookshelf.CloseBook();
//    }

//    public void ShowTimeOverMessage()
//    {
//        Debug.Log("Time ran out");
//    }
//}


// BELOW CODE WORKS (IT IS BEFORE IMPLEMENTING STAMPS)



//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class NameClickHandler : MonoBehaviour
//{
//    public string correctName;
//    public Bookshelf bookshelf;
//    public Timer timer;

//    private void OnMouseDown()
//    {
//        if (!timer.timeOver && gameObject.name == correctName)
//        {
//            Debug.Log("Level Passed");
//            StartCoroutine(CloseBookWithDelay());
//            StartCoroutine(LoadNextSceneWithDelay());
//        }
//        else if (!timer.timeOver)
//        {
//            Debug.Log("Wrong Name Selected");
//        }
//    }

//    private IEnumerator CloseBookWithDelay()
//    {
//        yield return new WaitForSeconds(2f);
//        bookshelf.CloseBook();
//    }

//    private IEnumerator LoadNextSceneWithDelay()
//    {
//        yield return new WaitForSeconds(1f); // delay before loading next scene
//        SceneManager.LoadScene("Level2"); // load next scene
//    }

//    public void ShowTimeOverMessage()
//    {
//        Debug.Log("Time ran out");
//    }
//}











// CODE AFTER IMPLEMENTING STAMPS



//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class NameClickHandler : MonoBehaviour
//{
//    public string correctName;
//    public Bookshelf bookshelf;
//    public Timer timer;


//    public GameObject stamp;


//    private void OnMouseDown()
//    {
//        if (!timer.timeOver && gameObject.name == correctName)
//        {
//            Debug.Log("Level Passed");
//        //    StartCoroutine(CloseBookWithDelay());
//            ShowStamp();
//            StartCoroutine(LoadNextSceneWithDelay());
//        }
//        else if (!timer.timeOver)
//        {
//            Debug.Log("Wrong Name Selected");
//        }
//    }

//    private IEnumerator CloseBookWithDelay()
//    {
//        yield return new WaitForSeconds(2f);
//        bookshelf.CloseBook();
//    }

//    private void ShowStamp()
//    {
//        stamp.SetActive(true);
//        Debug.Log("Showing Stamp");
//    }

//    private IEnumerator LoadNextSceneWithDelay()
//    {
//        yield return new WaitForSeconds(3f);
//        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
//        SceneManager.LoadScene(nextSceneIndex);
//    }

//    public void ShowTimeOverMessage()
//    {
//        Debug.Log("Time ran out");
//    }
//}







// MOBILE



//using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;

//public class NameClickHandler : MonoBehaviour
//{
//    public string correctName;
//    public Bookshelf bookshelf;
//    public Timer timer;


//    public GameObject stamp;


//    private void OnMouseDown()
//    {
//        if (!timer.timeOver && gameObject.name == correctName)
//        {
//            Debug.Log("Level Passed");
//            ShowStamp();

//        }
//        else if (!timer.timeOver)
//        {
//            Debug.Log("Wrong Name Selected");
//        }
//    }

//    private IEnumerator CloseBookWithDelay()
//    {
//        yield return new WaitForSeconds(2f);
//        bookshelf.CloseBook();
//    }

//    private void ShowStamp()
//    {
//        stamp.SetActive(true);
//        Debug.Log("Showing Stamp");
//    }

//    public void ShowTimeOverMessage()
//    {
//        Debug.Log("Time ran out");
//    }
//}




using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;

public class NameClickHandler : MonoBehaviour
{
    public GameObject[] correctNameObjects;   // Array of game objects that represent correct names.
    public Bookshelf bookshelf;
    public Timer timer;
    public GameObject stamp;

    private HashSet<GameObject> clickedCorrectNames = new HashSet<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !timer.timeOver)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;
                if (IsCorrectName(clickedObject) && !HasClickedCorrectName(clickedObject))
                {
                    Debug.Log("Correct Name Clicked: " + clickedObject.name);
                    clickedCorrectNames.Add(clickedObject);

                    if (clickedCorrectNames.Count == correctNameObjects.Length)
                    {
                        Debug.Log("Level Passed");
                        ShowStamp();
                        StartCoroutine(LoadNextSceneWithDelay());
                    }
                    else if (clickedCorrectNames.Count > 0)
                    {
                        Debug.Log("Some Correct Names Clicked");
                    }
                }
                else
                {
                    Debug.Log("Incorrect Name Clicked: " + clickedObject.name);
                }
            }
        }
    }

    private bool IsCorrectName(GameObject obj)
    {
        foreach (GameObject correctNameObject in correctNameObjects)
        {
            if (obj == correctNameObject)
            {
                return true;
            }
        }
        return false;
    }

    private bool HasClickedCorrectName(GameObject obj)
    {
        return clickedCorrectNames.Contains(obj);
    }

    private IEnumerator CloseBookWithDelay()
    {
        yield return new WaitForSeconds(2f);
        bookshelf.CloseBook();
    }

    private void ShowStamp()
    {
        stamp.SetActive(true);
        Debug.Log("Showing Stamp");
    }

    private IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(3f);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ShowTimeOverMessage()
    {
        Debug.Log("Time ran out");
    }
}