using System.Collections;
using UnityEngine;

namespace Tricks
{
    [Icon("Assets/_Tricks/Artwork/Icons/attribute.png")]
    [DefaultExecutionOrder(1)] // Call order of this Script, -1 is before 1
    [ExecuteAlways] // Execute Instances of this Script In Edit Mode and Play Mode
    [ExecuteInEditMode] // Execute All Instances of this Script in Edit Mode
    [RequireComponent(typeof(Camera))] // State the Dependencies of this Script
    public class UsefulAttributes : MonoBehaviour
    {
        #region VARIABLES

        [Header("Header")]
        [TextArea(0, 10)]
        // [TextArea(min lines, max lines)]
        // Adds additional Lines to the String Field in the Inspector
        // Changes a String Field to a Text Area in the Inspector
        public string HeaderExplained;
        [Multiline]
        public string MultilineString;

        [Header("Number Attributes")]
        public float NormalFloat = 0f;
        [Range(0f, 1f)]
        public float RangeFormatFloat = 0f;
        [Range(0, 10)]
        public int RangeFormatInt = 0;
        [Min(0)]
        public int IntSetToAMin = 10;

        [Header("Other Attributes")]
        [Tooltip("This is a Reference to the Main Camera")]
        public Camera MainCamera;
        [ColorUsage(true, true)]
        public Color Color;
        [Space(10f)] // Adds Space between fields in the Inspector
        [SerializeField]
        private string _serializedAPrivateField;
        [HideInInspector]
        public string HidesThisFieldFromTheInspector;

        #endregion
    }
}