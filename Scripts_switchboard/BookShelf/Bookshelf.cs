//using UnityEngine;

//public class Bookshelf : MonoBehaviour
//{
//    public GameObject bookObject;
//    public float proximityDistance = 2f;
//    private bool isBookOpen;

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            if (isBookOpen)
//            {
//                CloseBook();
//            }
//            else
//            {
//                if (IsPlayerNearby())
//                {
//                    OpenBook();
//                }
//            }
//        }
//    }

//    private bool IsPlayerNearby()
//    {
//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//        {
//            float distance = Vector2.Distance(transform.position, player.transform.position);
//            Debug.Log("Distance to Player: " + distance);
//            return distance <= proximityDistance;
//        }
//        return false;
//    }

//    public void OpenBook()
//    {
//        bookObject.SetActive(true);
//        isBookOpen = true;
//    }

//    public void CloseBook()
//    {
//        bookObject.SetActive(false);
//        isBookOpen = false;
//    }
//}




// FOR MOBILE:  works on First 1



//using UnityEngine;

//public class Bookshelf : MonoBehaviour
//{
//    public GameObject bookObject;
//    public float proximityDistance = 2f;
//    private bool isBookOpen;

//    private void Update()
//    {
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            if (isBookOpen)
//            {
//                CloseBook();
//            }
//            else
//            {
//                if (IsPlayerNearby())
//                {
//                    OpenBook();
//                }
//            }
//        }
//    }

//    private bool IsPlayerNearby()
//    {
//        GameObject player = GameObject.FindGameObjectWithTag("Player");
//        if (player != null)
//        {
//            float distance = Vector2.Distance(transform.position, player.transform.position);
//            return distance <= proximityDistance;
//        }
//        return false;
//    }

//    public void OpenBook()
//    {
//        bookObject.SetActive(true);
//        isBookOpen = true;
//    }

//    public void CloseBook()
//    {
//        bookObject.SetActive(false);
//        isBookOpen = false;
//    }
//}







// FOR MOBILE TRYGING TO WORK WITH 2nd level




using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    public GameObject bookObject;
    public float proximityDistance = 2f;
    private bool isBookOpen;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (IsPlayerNearby())
            {
                OpenBook();
            }      
        }
    }

    private bool IsPlayerNearby()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            return distance <= proximityDistance;
        }
        return false;
    }

    public void OpenBook()
    {
        bookObject.SetActive(true);
        isBookOpen = true;
    }

    public void CloseBook()
    {
        bookObject.SetActive(false);
        isBookOpen = false;
    }
}