using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Functions specific to Assault Cube
namespace DK_T_AC
{
    public class ACFunctions
    {

        //Base of player
        public static Vec2 vFoot = new Vec2();
        //Head of player
        public static Vec2 vHead = new Vec2();

        public static int fGetDistance(VecInt2 player, VecInt2 enemy)
        {
            double dDistance = Math.Sqrt(Math.Pow(enemy.x - player.x, 2) + Math.Pow(enemy.y - player.y, 2));
            return (int)dDistance;
        }

        public static bool WorldToScreenHPos(Vec3 pos, float[] matrix, int windowWidth, int windowHeight)
        {

            //Matrix-vector Product, multiplying world(eye) coordinates by projection matrix = clipCoords
            Vec4 clipCoords;
            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[4] + pos.z * matrix[8] + matrix[12];
            clipCoords.y = pos.x * matrix[1] + pos.y * matrix[5] + pos.z * matrix[9] + matrix[13];
            clipCoords.z = pos.x * matrix[2] + pos.y * matrix[6] + pos.z * matrix[10] + matrix[14];
            clipCoords.w = pos.x * matrix[3] + pos.y * matrix[7] + pos.z * matrix[11] + matrix[15];

            if (clipCoords.w < 0.1f)
                return false;

            //perspective division, dividing by clip.W = Normalized Device Coordinates
            Vec3 NDC;
            NDC.x = clipCoords.x / clipCoords.w;
            NDC.y = clipCoords.y / clipCoords.w;
            NDC.z = clipCoords.z / clipCoords.w;

            //Transform to window coordinates
            vHead.x = (windowWidth / 2 * NDC.x) + (NDC.x + windowWidth / 2);
            vHead.y = -(windowHeight / 2 * NDC.y) + (NDC.y + windowHeight / 2);
            return true;
        }

        public static bool WorldToScreenFPos(Vec3 pos, float[] matrix, int windowWidth, int windowHeight)
        {

            //Matrix-vector Product, multiplying world(eye) coordinates by projection matrix = clipCoords
            Vec4 clipCoords;
            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[4] + pos.z * matrix[8] + matrix[12];
            clipCoords.y = pos.x * matrix[1] + pos.y * matrix[5] + pos.z * matrix[9] + matrix[13];
            clipCoords.z = pos.x * matrix[2] + pos.y * matrix[6] + pos.z * matrix[10] + matrix[14];
            clipCoords.w = pos.x * matrix[3] + pos.y * matrix[7] + pos.z * matrix[11] + matrix[15];

            if (clipCoords.w < 0.1f)
                return false;

            //perspective division, dividing by clip.W = Normalized Device Coordinates
            Vec3 NDC;
            NDC.x = clipCoords.x / clipCoords.w;
            NDC.y = clipCoords.y / clipCoords.w;
            NDC.z = clipCoords.z / clipCoords.w;

            //Transform to window coordinates
            vFoot.x = (windowWidth / 2 * NDC.x) + (NDC.x + windowWidth / 2);
            vFoot.y = -(windowHeight / 2 * NDC.y) + (NDC.y + windowHeight / 2);
            return true;
        }

        public static bool WorldToScreenog(Vec3 pos, float[] matrix, int windowWidth, int windowHeight)
        {
            Vec4 clipCoords;
            // OpenGL Column Major
            
            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[4] + pos.z * matrix[8] + matrix[12];
            clipCoords.y = pos.x * matrix[1] + pos.y * matrix[5] + pos.z * matrix[9] + matrix[13];
            clipCoords.z = pos.x * matrix[2] + pos.y * matrix[6] + pos.z * matrix[10] + matrix[14];
            clipCoords.w = pos.x * matrix[3] + pos.y * matrix[7] + pos.z * matrix[11] + matrix[15];
            
            /*
            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[1] + pos.z * matrix[2] + matrix[3];
            clipCoords.y = pos.x * matrix[4] + pos.y * matrix[5] + pos.z * matrix[6] + matrix[7];
            clipCoords.z = pos.x * matrix[8] + pos.y * matrix[9] + pos.z * matrix[10] + matrix[11];
            clipCoords.w = pos.x * matrix[12] + pos.y * matrix[13] + pos.z * matrix[14] + matrix[15];
            */

            if (clipCoords.w < 0.1f)
            {
                return false;
            }

            Vec3 NDC = new Vec3();
             NDC.x = clipCoords.x / clipCoords.w;
             NDC.y = clipCoords.y / clipCoords.w;
             NDC.z = clipCoords.z / clipCoords.w;

            //vScreen.x = (windowWidth / 2 * NDC.x) + (NDC.x + windowWidth / 2);
           // vScreen.y = (windowHeight / 2 * NDC.y) + (NDC.y + windowHeight / 2);

            return true;
        }

        public static bool WorldToScreen2(Vec3 pos, float[] matrix, int windowWidth, int windowHeight)
        {
            Vec4 clipCoords;
            // OpenGL Column Major

            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[4] + pos.z * matrix[8] + matrix[12];
            clipCoords.y = pos.x * matrix[1] + pos.y * matrix[5] + pos.z * matrix[9] + matrix[13];
            clipCoords.z = pos.x * matrix[2] + pos.y * matrix[6] + pos.z * matrix[10] + matrix[14];
            clipCoords.w = pos.x * matrix[3] + pos.y * matrix[7] + pos.z * matrix[11] + matrix[15];

            /*
            clipCoords.x = pos.x * matrix[0] + pos.y * matrix[1] + pos.z * matrix[2] + matrix[3];
            clipCoords.y = pos.x * matrix[4] + pos.y * matrix[5] + pos.z * matrix[6] + matrix[7];
            clipCoords.z = pos.x * matrix[8] + pos.y * matrix[9] + pos.z * matrix[10] + matrix[11];
            clipCoords.w = pos.x * matrix[12] + pos.y * matrix[13] + pos.z * matrix[14] + matrix[15];
            */

            if (clipCoords.w < 0.1f)
            {
                return false;
            }

            Vec3 NDC = new Vec3();
             NDC.x = clipCoords.x / clipCoords.w;
             NDC.y = clipCoords.y / clipCoords.w;
             NDC.z = clipCoords.z / clipCoords.w;

            vHead.x = (windowWidth / 2 * NDC.x) + (NDC.x + windowWidth / 2);
            vHead.y = (windowHeight / 2 * NDC.y) + (NDC.y + windowHeight / 2);

            return true;
        }
    }


    public struct Vec3
    {
        public float x;
        public float y;
        public float z;
    }

    public struct Vec4
    {
        public float x, y, z, w;
    }

    public struct Vec2
    {
        public float x, y;
    }

    public struct VecInt2
    {
        public int x, y;
    }
}
