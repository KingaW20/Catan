using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Board;
using DataStorage;
using UnityEngine;
using static Board.States.GameState;

namespace Interactions
{
    public class InteractiveJunction : InteractiveElement
    {
        //Destiny: Materials for selected and unselected junction
        [Header("Materials")][Space(5)]
        [Tooltip("Normal material")] [SerializeField] private Material normalMaterial;
        [Tooltip("Glowing material")] [SerializeField] private Material glowingMaterial;
        
        //Destiny: Junction element renderer
        private MeshRenderer rend;

        //Destiny: Defines if junction can be selected
        private bool canBeBuilt;

        //Destiny: Defines if junction should blink if can be build
        private bool isBlinking;

        private List<Material> queuedMaterials;

        /// <summary>
        /// Realizes basic procedure of blocking of all junctions and additional conditions for the junction
        /// </summary>
        /// <returns>If junction is blocked</returns>
        protected override bool CheckBlockStatus()
        {
            //Destiny: There is no possibility to build on junction
            if (!gameObject.GetComponent<JunctionElement>().Available(GameManager.Selected.Pointed))
            {
                return true;
            }

            //Destiny: Here we return true in cases we want to block the junctions pointing
            if (GameManager.State.MovingUserMode == MovingMode.MovingThief)
            {
                return true;
            }
            
            //Destiny: Here there are block cases for all interactive elements
            return base.CheckBlockStatus();
        }
        
        /// <summary>
        /// Checks if player is able to build on the junction
        /// </summary>
        /// <returns>If player can build on junction</returns>
        private bool CheckInteractableStatus()
        {
            return GameManager.BuildManager.CheckIfPlayerCanBuildBuilding(gameObject.GetComponent<JunctionElement>().State.id);
        }
        
        /// <summary>
        /// Does specific action for the junction on start (it is run on start in class InteractiveElement)
        /// </summary>
        protected override void DoSpecificActionsOnStart()
        {
            rend = gameObject.GetComponent<MeshRenderer>();
            var pb = new MaterialPropertyBlock();
            rend.GetPropertyBlock(pb);
            pb.SetColor("_Color", rend.material.color);
            rend.SetPropertyBlock(pb);
        }
        
        /// <summary>
        /// Does specific action for the junction on update (it is run on update in class InteractiveElement)
        /// </summary>
        protected override void DoSpecificActionsOnUpdate()
        {
            if (!isBlinking)
            {
                isBlinking = true;
                StartCoroutine(Blink());
            }

            canBeBuilt = CheckInteractableStatus();
            
            var pb = new MaterialPropertyBlock();
            rend.GetPropertyBlock(pb);
            var color = pb.GetColor("_Color");
            pb.SetColor("_Color", IsPointed && canBeBuilt && !Blocked ? Color.black : color);
            rend.SetPropertyBlock(pb);
        }

        /// <summary>
        /// Moves junction down and then changes it's material to default one
        /// </summary>
        protected override void UnselectElement()
        {
            base.UnselectElement();
            rend.material = normalMaterial;
        }
        
        /// <summary>
        /// Moves junction up and then changes it's material to selected one
        /// </summary>
        protected override void SelectElement()
        {
            base.SelectElement();
            rend.material = glowingMaterial;
        }

        private IEnumerator Blink()
        {
            var pb = new MaterialPropertyBlock();
            rend.GetPropertyBlock(pb);
            var color = pb.GetColor("_Color");
            float hue = 0;
            var raisingUp = true;
            while(gameObject.GetComponent<JunctionElement>().Available(gameObject.GetComponent<JunctionElement>()))
            {
                if (hue >= 0.2f) raisingUp = false;
                else if (hue <= 0f) raisingUp = true;
                
                if (raisingUp) hue += 0.5f * Time.deltaTime;
                else hue -= 0.5f * Time.deltaTime;
                if (canBeBuilt && !IsPointed && GameManager.Selected.Element != GetComponent<BoardElement>())
                {
                    pb.SetColor("_Color", new Color(hue, hue, hue));
                    rend.SetPropertyBlock(pb);
                }
                yield return new WaitForSeconds(0.01f);
            }
            pb.SetColor("_Color", color);
            rend.SetPropertyBlock(pb);
            isBlinking = false;
        }
    }
}