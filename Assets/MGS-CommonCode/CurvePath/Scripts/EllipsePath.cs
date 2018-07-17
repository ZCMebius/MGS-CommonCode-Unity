﻿/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipsePath.cs
 *  Description  :  Define path base on ellipse curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/14/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Mogoson.Curve;
using UnityEngine;

namespace Mogoson.CurvePath
{
    /// <summary>
    /// Path base on ellipse curve.
    /// </summary>
    [AddComponentMenu("Mogoson/CurvePath/EllipsePath")]
    public class EllipsePath : MonoCurvePath
    {
        #region Field and Property
        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMinorAxis = 1.0f;

        /// <summary>
        /// Semi minor axis of ellipse.
        /// </summary>
        public float SemiMinorAxis
        {
            set
            {
                semiMinorAxis = value;
                ellipse.semiMinorAxis = semiMinorAxis;
            }
            get { return semiMinorAxis; }
        }

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        [SerializeField]
        protected float semiMajorAxis = 1.5f;

        /// <summary>
        /// Semi major axis of ellipse.
        /// </summary>
        public float SemiMajorAxis
        {
            set
            {
                semiMajorAxis = value;
                ellipse.semiMajorAxis = semiMajorAxis;
            }
            get { return semiMajorAxis; }
        }

        /// <summary>
        /// Max around radian of ellipse.
        /// </summary>
        public override float MaxKey { get { return 2 * Mathf.PI; } }

        /// <summary>
        /// Ellipse info of path curve.
        /// </summary>
        protected EllipseInfo ellipse = new EllipseInfo();
        #endregion

        #region Public Method
        /// <summary>
        /// Rebuild path.
        /// </summary>
        public override void Rebuild()
        {
            ellipse.semiMinorAxis = semiMinorAxis;
            ellipse.semiMajorAxis = semiMajorAxis;
        }

        /// <summary>
        /// Get point on path curve at radian.
        /// </summary>
        /// <param name="radian">Radian of curve.</param>
        /// <returns>The point on path curve at radian.</returns>
        public override Vector3 GetPointAt(float radian)
        {
            return transform.TransformPoint(EllipseCurve.GetPointAt(ellipse, radian));
        }
        #endregion
    }
}