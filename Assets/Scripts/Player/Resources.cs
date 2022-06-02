using Board;
using System.Collections.Generic;

namespace Player
{
    public class Resources
    {
        //Destiny: Types of resources
        public enum ResourceType
        {
            Wood,
            Clay,
            Wool,
            Iron,
            Wheat
        }

        private int woodNumber;
        private int clayNumber;
        private int woolNumber;
        private int ironNumber;
        private int wheatNumber;

        public Resources()
        {
            woodNumber = 10;
            clayNumber = 10;
            woolNumber = 10;
            ironNumber = 10;
            wheatNumber = 10;
        }

        /// <summary>
        /// Adds given number of specified type of field 
        /// </summary>
        /// <param name="fieldType"></param>
        /// <param name="number"></param>
        public void AddSpecifiedFieldResource(FieldElement.FieldType fieldType, int number = 1)
        {
            switch(fieldType)
            {
                case FieldElement.FieldType.Forest:
                    woodNumber += number;
                    break;
                case FieldElement.FieldType.Hills:
                    clayNumber += number;
                    break;
                case FieldElement.FieldType.Pasture:
                    woolNumber += number;
                    break;
                case FieldElement.FieldType.Mountains:
                    ironNumber += number;
                    break;
                case FieldElement.FieldType.Field:
                    wheatNumber += number;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Adds given number of specified type of field 
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="number"></param>
        public void AddSpecifiedResource(ResourceType resourceType, int number = 1)
        {
            switch (resourceType)
            {
                case ResourceType.Wood:
                    woodNumber += number;
                    break;
                case ResourceType.Clay:
                    clayNumber += number;
                    break;
                case ResourceType.Wool:
                    woolNumber += number;
                    break;
                case ResourceType.Iron:
                    ironNumber += number;
                    break;
                case ResourceType.Wheat:
                    wheatNumber += number;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Subtracts given number of specified type of resource owned by player
        /// </summary>
        /// <param name="resourceType"></param>
        /// <param name="number"></param>
        public void SubtractSpecifiedResource(ResourceType resourceType, int number)
        {
            switch (resourceType)
            {
                case ResourceType.Wood:
                    woodNumber -= number;
                    break;
                case ResourceType.Clay:
                    clayNumber -= number;
                    break;
                case ResourceType.Wool:
                    woolNumber -= number;
                    break;
                case ResourceType.Iron:
                    ironNumber -= number;
                    break;
                case ResourceType.Wheat:
                    wheatNumber -= number;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceType">type of resource</param>
        /// <returns>number of resources owned by player</returns>
        public int GetResourceNumber(ResourceType resourceType)
        {
            switch (resourceType)
            {
                case ResourceType.Wood:
                    return woodNumber;
                case ResourceType.Clay:
                    return clayNumber;
                case ResourceType.Wool:
                    return woolNumber;
                case ResourceType.Iron:
                    return ironNumber;
                case ResourceType.Wheat:
                    return wheatNumber;
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resources">key: resource type, value: number of resource which player should have</param>
        /// <returns>true if player has enough resource</returns>
        public bool CheckIfPlayerHasEnoughResources(Dictionary<ResourceType, int> resources)
        {
            foreach (KeyValuePair<ResourceType, int> resource in resources)
            {
                if (GetResourceNumber(resource.Key) < resource.Value)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Subtracts resources based on given price
        /// </summary>
        /// <param name="price"></param>
        public void SubtractResources(Dictionary<ResourceType, int> price)
        {
            foreach (KeyValuePair<ResourceType, int> p in price)
            {
                if (GetResourceNumber(p.Key) >= p.Value)
                    SubtractSpecifiedResource(p.Key, p.Value);
            }
        }
    }
}