using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;


public class SliderValueObtain : MonoBehaviour
{
//namespace Microsoft.MixedReality.Toolkit.Examples.Demos
        private TextMeshProUGUI textMesh;
        public float maginitude;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            if (textMesh == null)
            {

                textMesh = GetComponent<TextMeshProUGUI>();
                if (textMesh == null)
                {
                    Debug.Log(eventData.NewValue);
                }


            }

            if (textMesh != null)
            {

                textMesh.text = $"{eventData.NewValue:F2}";
                maginitude = eventData.NewValue;
            }
        }
}
