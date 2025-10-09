using UnityEngine;
using System.Collections;

namespace VLB
{
    public static class GlobalMesh
    {
        public static Mesh Get()
        {
            var needDoubleSided = Config.Instance.requiresDoubleSidedMesh;

            if (ms_Mesh == null
                || ms_DoubleSided != needDoubleSided)
            {
                Destroy();

                ms_Mesh = MeshGenerator.GenerateConeZ_Radius(
                    1f,
                    1f,
                    1f,
                    Config.Instance.sharedMeshSides,
                    Config.Instance.sharedMeshSegments,
                    true,
                    needDoubleSided);

                ms_Mesh.hideFlags = Consts.Internal.ProceduralObjectsHideFlags;
                ms_DoubleSided = needDoubleSided;
            }

            return ms_Mesh;
        }

        public static void Destroy()
        {
            if (ms_Mesh != null)
            {
                Object.DestroyImmediate(ms_Mesh);
                ms_Mesh = null;
            }
        }

        private static Mesh ms_Mesh = null;
        private static bool ms_DoubleSided = false;
    }
}