using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

namespace Adventure
{
    /// <summary>
    /// Interfaces should always Start with the Letter I
    /// </summary>
    public interface IMyInterface
    {
    }

    /// <summary>
    /// You can suffix abstract classes with the word Base
    /// </summary>
    public abstract class SomethingBase
    {
    }

    /// <summary>
    /// Class names should always be PascalCase
    /// </summary>
    public class PersonalStandard : MonoBehaviour
    {
        #region VARIABLES

        // Public fields could be either PascalCase or camelCase. Choose one design and stick with it
        public string MyPublicField;
        // Private fields should be either _camelCase or just camelCase
        private string _myPrivateField;
        // Creating Constant Fields
        public const int MIN_AGE = 18;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// 
        /// </summary>
        public string MyPrivateField
        {
            get => _myPrivateField;
            set => _myPrivateField = value;
        }

        #endregion

        #region UNITY METHODS

        #endregion

        #region METHODS

        /// <summary>
        /// Method names should always be PascalCase
        /// </summary>
        public void MyMethod()
        {
        }

        /// <summary>
        /// Parameter names should always be camelCase
        /// </summary>
        /// <param name="parameterA"></param>
        /// <param name="parameterB"></param>
        public void MyMethodWithParameters(string parameterA, string parameterB)
        {
        }

        public void MyMethodWithDefaultParameters(string parameterA, string parameterB = "ParameterB")
        {
        }

        public void OneLinerMethod() => print("Hello");

        public void OnLinerMethodWithParameters(string parameterA) => print(parameterA);

        public void WorkingWithDisposableTypes(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                // use the connection and the stream
                using (SqlCommand command = new SqlCommand(query))
                {
                }
            }
        }

        #endregion
    }
}