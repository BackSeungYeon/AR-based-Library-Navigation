﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{

    /// This component listens for images detected by the <c>XRImageTrackingSubsystem</c>
    /// and overlays some information as well as the source Texture2D on top of the
    /// detected image.
    /// </summary>
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class TrackedImageInfoManager : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The camera to set on the world space UI canvas for each instantiated image info.")]
        Camera m_WorldSpaceCanvasCamera;
        public GameObject Marker;
        /// <summary>
        /// The prefab has a world space UI canvas,
        /// which requires a camera to function properly.
        /// </summary>
        public Camera worldSpaceCanvasCamera
        {
            get { return m_WorldSpaceCanvasCamera; }
            set { m_WorldSpaceCanvasCamera = value; }
        }

        [SerializeField]
        [Tooltip("If an image is detected but no source texture can be found, this texture is used instead.")]
        Texture2D m_DefaultTexture;

        /// <summary>
        /// If an image is detected but no source texture can be found,
        /// this texture is used instead.
        /// </summary>
        public Texture2D defaultTexture
        {
            get { return m_DefaultTexture; }
            set { m_DefaultTexture = value; }
        }

        ARTrackedImageManager m_TrackedImageManager;

        void Awake()
        {
            m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        void OnEnable()
        {
            m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        void OnDisable()
        {
            m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        void UpdateInfo(ARTrackedImage trackedImage)
        {
            // Set canvas camera
            var canvas = trackedImage.GetComponentInChildren<Canvas>();
            canvas.worldCamera = worldSpaceCanvasCamera;

            // Update information about the tracked image
            var text = canvas.GetComponentInChildren<Text>();
            text.text = string.Format(
                "{0}\ntrackingState: {1}\nGUID: {2}\nReference size: {3} cm\nDetected size: {4} cm",
                trackedImage.referenceImage.name,
                trackedImage.trackingState,
                trackedImage.referenceImage.guid,
                trackedImage.referenceImage.size * 100f,
                trackedImage.size * 100f);

            var planeParentGo = trackedImage.transform.GetChild(0).gameObject;
            var planeGo = planeParentGo.transform.GetChild(0).gameObject;

            // Disable the visual plane if it is not being tracked
            if (trackedImage.trackingState != TrackingState.None)
            {
                planeGo.SetActive(true);

                 // The image extents is only valid when the image is being tracked
                Debug.Log("Here!!!!!!!!!!!!!");
                Debug.Log(trackedImage.transform.position);
                Marker.transform.position = trackedImage.transform.position;

                //Debug.Log(GetTrack.p1);

                /*여기여기*for (int i = 0; i < Marker.transform.childCount; i++)
                {
                    Marker.transform.GetChild(i);
                } */ 

                Debug.Log(planeParentGo.transform.position);
                //GameObject obj = GameObject.FindWithTag("MainCamera");
                //Marker.transform.position = obj.transform.position;

                trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);

                // Set the texture
                var material = planeGo.GetComponentInChildren<MeshRenderer>().material;
                material.mainTexture = (trackedImage.referenceImage.texture == null) ? defaultTexture : trackedImage.referenceImage.texture;
            }
            else
            {
                planeGo.SetActive(false);
            }
        }

        void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            foreach (var trackedImage in eventArgs.added)
            {
                // Give the initial image a reasonable default scale
                trackedImage.transform.localScale = new Vector3(0.01f, 1f, 0.01f);

                UpdateInfo(trackedImage);
            }

            foreach (var trackedImage in eventArgs.updated)
                UpdateInfo(trackedImage);
        }
    }
}