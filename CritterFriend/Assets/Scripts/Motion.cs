using UnityEngine;
using System.Collections;
using Leap;
using System.Collections.Generic;
using Leap.Unity;

public class Motion : MonoBehaviour {


    public GameObject childRef;
    public GameObject hand;
    public Transform foreArm;
    private Transform InitialHandState;


    public GameObject AnimalPicked;
    bool isAnimalPickedCoroutineExecuting;
    public bool isAccelerationEnabled = false;


    void Start() {
        AnimalPicked = null;
        InitialHandState = transform;
    }


    /// <summary>
    /// The Leap controller.
    /// </summary>
    Controller controller;

    /// <summary>
    /// The current frame captured by the Leap Motion.
    /// </summary>
    Frame CurrentFrame
    {
        get { return ( IsReady ) ? controller.Frame() : null; }
    }

    /// <summary>
    /// Gets the hands data captured from the Leap Motion.
    /// </summary>
    /// <value>
    /// The hands data captured from the Leap Motion.
    /// </value>
    List<Hand> Hands
    {
        get { return ( CurrentFrame != null && CurrentFrame.Hands.Count > 0 ) ? CurrentFrame.Hands : null; }
    }

    /// <summary>
    /// Gets a value indicating whether the Leap Motion is ready.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is ready; otherwise, <c>false</c>.
    /// </value>
    bool IsReady
    {
        get { return ( controller != null && controller.Devices.Count > 0 && controller.IsConnected ); }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        controller = new Controller();
    }

    /// <summary>
    /// Update function called every frame.
    /// </summary>
    void Update()
    {
        Hand mainHand; // The front most hand captured by the Leap Motion Controller

        // Check if the Leap Motion Controller is ready
        if ( !IsReady || Hands == null )
        {
           // transform.position = InitialHandState.transform.position;
          //  transform.rotation = InitialHandState.transform.rotation;
            return;
        }

        mainHand = Hands[0];

        if (Hands.Count == 2)
        {
            //Debug.Log("Woooow");
            isAccelerationEnabled = true;
        }
        else {
            isAccelerationEnabled = false;
        }

        if (mainHand.IsRight)
        {
            gameObject.SetActive(true);
            Vector3 unityVector = mainHand.PalmPosition.ToVector3();
            LeapProvider provider = FindObjectOfType<LeapProvider>() as LeapProvider;
            // Matrix mat = UnityMatrixExtension.GetLeapMatrix(provider.transform);

            if (AnimalPicked != null) {
                AnimalPicked.transform.position = UnityMatrixExtension.GetLeapMatrix(provider.transform).TransformPoint(mainHand.PalmPosition).ToVector3();
                StartCoroutine(ResetAnimalState());
            }
        }

        
    }

    IEnumerator ResetAnimalState() {
        if (isAnimalPickedCoroutineExecuting) {
            yield return 0f;
        }
        isAnimalPickedCoroutineExecuting = true;
        yield return 5.0f;
        Destroy(AnimalPicked);
        AnimalPicked = null;
        isAnimalPickedCoroutineExecuting = false;
    }
}
