using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class FieldElement : BoardElement
    {
        //Destiny: Types of available fields (only for fields elements)
        public enum FieldType
        {
            Forest,
            Pasture,
            Field,
            Hills,
            Mountains,
            Desert
        }

        //Destiny: List of all neighbour junctions to the field (only for fields elements)
        public List<int> junctionsID;

        //Destiny: List of all neighbour paths to the field (only for fields elements)
        private List<int> pathsID;

        //Destiny: Means that thief is on that field
        private bool isThief;
        
        //Destiny: The number above the field
        private int number;

        //Destiny: The type of the field
        [Header("Type of the field")]
        [Space(5)]
        [Tooltip("Type of the field")]
        [SerializeField]
        private FieldType type;

        /// <summary>
        /// Setting number over the field
        /// </summary>
        /// <param name="n">Number over the field to set</param>
        public void SetNumberAndApply(int n)
        {
            number = n;
            transform.GetComponent<NumberOverField.NumberOverField>().SetNumberValue(number);
        }

        /// <summary>
        /// Setting neighbors of path type
        /// </summary>
        /// <param name="pathsID">List of neighbors of path type to set</param>
        public void SetPathsID(List<int> pathsID)
        {
            this.pathsID = pathsID;
        }

        /// <summary>
        /// Setting neighbors of junction type
        /// </summary>
        /// <param name="junctionsID">List of neighbors of junction type to set</param>
        public void SetJunctionsID(List<int> junctionsID)
        {
            this.junctionsID = junctionsID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Info about the type in FieldType format</returns>
        public FieldType GetTypeInfo()
        {
            return type;
        }

        void Awake()
        {
            boardElementType = BoardElementType.Field;
            isThief = false;
        }
    }
}