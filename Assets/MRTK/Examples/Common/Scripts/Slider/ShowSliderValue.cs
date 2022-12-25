//
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    [AddComponentMenu("Scripts/MRTK/Examples/ShowSliderValue")]
    public class ShowSliderValue : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro textMesh =null ;

        public void OnSliderUpdated(SliderEventData eventData)
        {
            if (textMesh == null)
            {
                Debug.Log("Looking");
                textMesh = GetComponent<TextMeshPro>();
                if (textMesh == null)
                {
                    Debug.Log(eventData.NewValue);
                }


            }

            if (textMesh != null)
            {
                Debug.Log("found");
                textMesh.text = $"{eventData.NewValue:F2}";
            }
        }
    }
}
