﻿using System;
using System.Collections.Generic;
using BEPUphysics.BroadPhaseSystems;
using BEPUphysics.Collidables.MobileCollidables;
using BEPUphysics.Entities;
using Microsoft.Xna.Framework;
using BEPUphysics.CollisionShapes.ConvexShapes;
using BEPUphysics.DataStructures;

namespace BEPUphysics.ResourceManagement
{
    /// <summary>
    /// Handles allocation and management of commonly used resources.
    /// </summary>
    public static class Resources
    {
        static Resources()
        {
            ResetPools();
        }

        public static void ResetPools()
        {
            SubPoolRayHitList = new LockingResourcePool<RawList<RayHit>>();
            SubPoolRayCastResultList = new LockingResourcePool<RawList<RayCastResult>>();
            SubPoolCollisionEntryList = new LockingResourcePool<RawList<BroadPhaseEntry>>();
            SubPoolCompoundChildList = new LockingResourcePool<RawList<CompoundChild>>();
            SubPoolIntList = new LockingResourcePool<List<int>>();
            SubPoolFloatList = new LockingResourcePool<List<float>>();
            SubPoolVectorList = new LockingResourcePool<List<Vector3>>();
            SubPoolEntityRawList = new LockingResourcePool<RawList<Entity>>(16);
            SubPoolTriangleShape = new LockingResourcePool<TriangleShape>();
        }

        //#if WINDOWS
        //        //[ThreadStatic]
        //        private static ResourcePool<List<bool>> subPoolBoolList;

        //        private static ResourcePool<List<bool>> SubPoolBoolList
        //        {
        //            get { return subPoolBoolList ?? (subPoolBoolList = new UnsafeResourcePool<List<bool>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<RawList<RayHit>> subPoolRayHitList;

        //        private static ResourcePool<RawList<RayHit>> SubPoolRayHitList
        //        {
        //            get { return subPoolRayHitList ?? (subPoolRayHitList = new UnsafeResourcePool<RawList<RayHit>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<RawList<RayCastResult>> subPoolRayCastResultList;

        //        private static ResourcePool<RawList<RayCastResult>> SubPoolRayCastResultList
        //        {
        //            get { return subPoolRayCastResultList ?? (subPoolRayCastResultList = new UnsafeResourcePool<RawList<RayCastResult>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<RawList<BroadPhaseEntry>> subPoolCollisionEntryList;

        //        private static ResourcePool<RawList<BroadPhaseEntry>> SubPoolCollisionEntryList
        //        {
        //            get { return subPoolCollisionEntryList ?? (subPoolCollisionEntryList = new UnsafeResourcePool<RawList<BroadPhaseEntry>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<RawList<CompoundChild>> subPoolCompoundChildList;

        //        private static ResourcePool<RawList<CompoundChild>> SubPoolCompoundChildList
        //        {
        //            get { return subPoolCompoundChildList ?? (subPoolCompoundChildList = new UnsafeResourcePool<RawList<CompoundChild>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<List<int>> subPoolIntList;

        //        private static ResourcePool<List<int>> SubPoolIntList
        //        {
        //            get { return subPoolIntList ?? (subPoolIntList = new UnsafeResourcePool<List<int>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<Queue<int>> subPoolIntQueue;

        //        private static ResourcePool<Queue<int>> SubPoolIntQueue
        //        {
        //            get { return subPoolIntQueue ?? (subPoolIntQueue = new UnsafeResourcePool<Queue<int>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<List<float>> subPoolFloatList;

        //        private static ResourcePool<List<float>> SubPoolFloatList
        //        {
        //            get { return subPoolFloatList ?? (subPoolFloatList = new UnsafeResourcePool<List<float>>()); }
        //        }

        //        //[ThreadStatic]
        //        private static ResourcePool<List<Vector3>> subPoolVectorList;

        //        private static ResourcePool<List<Vector3>> SubPoolVectorList
        //        {
        //            get { return subPoolVectorList ?? (subPoolVectorList = new UnsafeResourcePool<List<Vector3>>()); }
        //        }

        //        private static readonly ResourcePool<List<Entity>> SubPoolEntityList = new LockingResourcePool<List<Entity>>(16, InitializeEntityListDelegate);

        //        //[ThreadStatic]
        //        private static ResourcePool<RawList<Entity>> subPoolEntityRawList;
        //        private static ResourcePool<RawList<Entity>> SubPoolEntityRawList
        //        {
        //            get { return subPoolEntityRawList ?? (subPoolEntityRawList = new UnsafeResourcePool<RawList<Entity>>(16)); }
        //        }


        //        //[ThreadStatic]
        //        private static ResourcePool<Queue<Entity>> subPoolEntityQueue;

        //        private static ResourcePool<Queue<Entity>> SubPoolEntityQueue
        //        {
        //            get { return subPoolEntityQueue ?? (subPoolEntityQueue = new UnsafeResourcePool<Queue<Entity>>()); }
        //        }



        //        //[ThreadStatic]
        //        private static ResourcePool<TriangleShape> subPoolTriangleShape;

        //        private static ResourcePool<TriangleShape> SubPoolTriangleShape
        //        {
        //            get { return subPoolTriangleShape ?? (subPoolTriangleShape = new UnsafeResourcePool<TriangleShape>()); }
        //        }

        //#else
        static ResourcePool<RawList<RayHit>> SubPoolRayHitList;// = new LockingResourcePool<RawList<RayHit>>();
        static ResourcePool<RawList<RayCastResult>> SubPoolRayCastResultList;// = new LockingResourcePool<RawList<RayCastResult>>();
        static ResourcePool<RawList<BroadPhaseEntry>> SubPoolCollisionEntryList;// = new LockingResourcePool<RawList<BroadPhaseEntry>>();
        static ResourcePool<List<int>> SubPoolIntList;// = new LockingResourcePool<List<int>>();
        static ResourcePool<List<float>> SubPoolFloatList;// = new LockingResourcePool<List<float>>();
        static ResourcePool<List<Vector3>> SubPoolVectorList;// = new LockingResourcePool<List<Vector3>>();;
        static ResourcePool<RawList<Entity>> SubPoolEntityRawList;//= new LockingResourcePool<RawList<Entity>>(16);
        static ResourcePool<TriangleShape> SubPoolTriangleShape;// = new LockingResourcePool<TriangleShape>();
        static ResourcePool<RawList<CompoundChild>> SubPoolCompoundChildList;//= new LockingResourcePool<RawList<CompoundChild>>();
        //#endif
        /// <summary>
        /// Retrieves a ray cast result list from the resource pool.
        /// </summary>
        /// <returns>Empty ray cast result list.</returns>
        public static RawList<RayCastResult> GetRayCastResultList()
        {
            return SubPoolRayCastResultList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(RawList<RayCastResult> list)
        {
            list.Clear();
            SubPoolRayCastResultList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves a ray hit list from the resource pool.
        /// </summary>
        /// <returns>Empty ray hit list.</returns>
        public static RawList<RayHit> GetRayHitList()
        {
            return SubPoolRayHitList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(RawList<RayHit> list)
        {
            list.Clear();
            SubPoolRayHitList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves an CollisionEntry list from the resource pool.
        /// </summary>
        /// <returns>Empty CollisionEntry list.</returns>
        public static RawList<BroadPhaseEntry> GetCollisionEntryList()
        {
            return SubPoolCollisionEntryList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(RawList<BroadPhaseEntry> list)
        {
            list.Clear();
            SubPoolCollisionEntryList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves an CompoundChild list from the resource pool.
        /// </summary>
        /// <returns>Empty information list.</returns>
        public static RawList<CompoundChild> GetCompoundChildList()
        {
            return SubPoolCompoundChildList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(RawList<CompoundChild> list)
        {
            list.Clear();
            SubPoolCompoundChildList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves a int list from the resource pool.
        /// </summary>
        /// <returns>Empty int list.</returns>
        public static List<int> GetIntList()
        {
            return SubPoolIntList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(List<int> list)
        {
            list.Clear();
            SubPoolIntList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves a float list from the resource pool.
        /// </summary>
        /// <returns>Empty float list.</returns>
        public static List<float> GetFloatList()
        {
            return SubPoolFloatList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(List<float> list)
        {
            list.Clear();
            SubPoolFloatList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves a Vector3 list from the resource pool.
        /// </summary>
        /// <returns>Empty Vector3 list.</returns>
        public static List<Vector3> GetVectorList()
        {
            return SubPoolVectorList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(List<Vector3> list)
        {
            list.Clear();
            SubPoolVectorList.GiveBack(list);
        }
        
        /// <summary>
        /// Retrieves an Entity RawList from the resource pool.
        /// </summary>
        /// <returns>Empty Entity raw list.</returns>
        public static RawList<Entity> GetEntityRawList()
        {
            return SubPoolEntityRawList.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="list">List to return.</param>
        public static void GiveBack(RawList<Entity> list)
        {
            list.Clear();
            SubPoolEntityRawList.GiveBack(list);
        }

        /// <summary>
        /// Retrieves a Triangle shape from the resource pool.
        /// </summary>
        /// <param name="v1">Position of the first vertex.</param>
        /// <param name="v2">Position of the second vertex.</param>
        /// <param name="v3">Position of the third vertex.</param>
        /// <returns>Initialized TriangleShape.</returns>
        public static TriangleShape GetTriangle(ref Vector3 v1, ref Vector3 v2, ref Vector3 v3)
        {
            TriangleShape toReturn = SubPoolTriangleShape.Take();
            toReturn.vA = v1;
            toReturn.vB = v2;
            toReturn.vC = v3;
            return toReturn;
        }

        /// <summary>
        /// Retrieves a Triangle shape from the resource pool.
        /// </summary>
        /// <returns>Initialized TriangleShape.</returns>
        public static TriangleShape GetTriangle()
        {
            return SubPoolTriangleShape.Take();
        }

        /// <summary>
        /// Returns a resource to the pool.
        /// </summary>
        /// <param name="triangle">Triangle to return.</param>
        public static void GiveBack(TriangleShape triangle)
        {
            SubPoolTriangleShape.GiveBack(triangle);
        }





    }
}