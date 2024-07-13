using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

// Allows the game object to follow the main camera as if it were a child.
public class FollowMainCamera : MonoBehaviour
{
    [SerializeField]
    private ParentConstraint parentConstraint = null;

    private ConstraintSource constraintSource;

    void Start()
    {
        constraintSource = new ConstraintSource();

        // Gives the ParentConstraint component a reference to the main camera.
        constraintSource.sourceTransform = GameManager.Instance.MainCamera.transform;
        constraintSource.weight = 1.0f;

        parentConstraint.SetSource(0, constraintSource);
        //parentConstraint.AddSource(constraintSource);
        //parentConstraint.SetTranslationOffset(0, new Vector3(0f, 0f, 9.6f));  // change 9.6f to the gamesetting in the future to support different screen aspect ratio
        parentConstraint.constraintActive = true;
    }
}
