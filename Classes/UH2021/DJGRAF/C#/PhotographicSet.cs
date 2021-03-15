using Rendering;
using GMath;
using static DJGraphic.Tools;
using static GMath.Gfx;

namespace DJGraphic
{
    static class PhotographicSet
    {
        public static void Init(Raster render)
        {
            render.ClearRT(float4(0, 0, 0.2f, 1));
			var glass = GlassOfWater();
			
			Draw(render, ~(glass));
        }

		private static CloudPoints GlassOfWater()
		{
			CloudPoints ellipsoid = new CloudPointsGenerator<Ellipsoid>(100000)
									.WidthBoxing(x:0.96f, y:0.96f,z:2)
									.Between(Plane.ZLimit(-1.11f,0.8f))
									.ToCloudPoints(); 

			CloudPoints cylinder = new CloudPointsGenerator<Cylinder>(100000)
								.WidthBoxing(x:0.83f, y:0.83f, z:2)
								.Between(Plane.ZLimit(-1.4f,-1.04f))
								.ToCloudPoints();


			CloudPoints result = ApplyTransform( ~(ellipsoid + cylinder), 
										Transforms.Scale(1,1,1.7f));
			return result;
		}

		private static void Draw(Raster render,float3[] points)
		{
      		points = ApplyTransform(points, 
			  		 Transforms.LookAtLH(float3(0, -10f, 1f), float3(0, 0, 0), float3(0, 0, 1)));
      		points = ApplyTransform(points, 
			  		 Transforms.PerspectiveFovLH(
						pi_over_4, render.RenderTarget.Height / (float)render.RenderTarget.Width, 0.01f, 40));

      		render.DrawPoints(points);
		}
    }
}