using System;
using System.Collections.Generic;
using System.Linq;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static System.Math;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;

namespace Fusee.Tutorial.Core
{
    public class FirstSteps : RenderCanvas
    {
     // private int []a = {0,3,2};
        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;
        private float _camAngle = 0;
        
        private TransformComponent _cubeTransform;
         private TransformComponent _cubeTransform1;
         private TransformComponent _cubeTransform2;
         private TransformComponent _cubeTransform3;
         private MaterialComponent cubeMaterial2;
    
         

       



        // Init is called on startup. 
        public override void Init()
        {
      



            // Set the clear color for the backbuffer to light green (intensities in R, G, B, A).
            RC.ClearColor = new float4(3f, 2f, 1f, 1.0f);
   
       // for(int i = 0; i <= a.Length; i++){
     
            _cubeTransform = new TransformComponent {Scale = new float3(2, 2, 2), Translation = new float3(0, 0, 0)};
      

          
            var cubeMaterial = new MaterialComponent
            {
           
                Diffuse = new MatChannelContainer {Color = new float3(3, 0, 1)},
                Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
            var cubeMesh = SimpleMeshes.CreateCuboid(new float3(1, 1, 1));
        
            // Assemble the cube node containing the three components
            var cubeNode = new SceneNodeContainer();
            cubeNode.Components = new List<SceneComponentContainer>();
            cubeNode.Components.Add(_cubeTransform);
            cubeNode.Components.Add(cubeMaterial);
            cubeNode.Components.Add(cubeMesh);
           
        
        
            
        
           // Create a scene with a cube
            // The three components: one XForm, one Material and the Mesh3
            _cubeTransform1 = new TransformComponent {Scale = new float3(3, 6, 7), Translation = new float3(0,3,2)};
            var cubeMaterial1 = new MaterialComponent
            {
             Diffuse = new MatChannelContainer {Color = new float3(0.5f, .8f, .5f)},
             Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
             var cubeMesh1 = SimpleMeshes.CreateCuboid(new float3(2, 3, 3));

            // Assemble the cube node containing the three components
            var cubeNode1 = new SceneNodeContainer();
            cubeNode1.Components = new List<SceneComponentContainer>();
            cubeNode1.Components.Add(_cubeTransform1);
            cubeNode1.Components.Add(cubeMaterial1);
            cubeNode1.Components.Add(cubeMesh1);
            


             // Create a scene with a cube
            // The three components: one XForm, one Material and the Mesh
            _cubeTransform2 = new TransformComponent {Scale = new float3(4, 4, 4), Translation = new float3(5, 4,7)};
            cubeMaterial2 = new MaterialComponent
            {
             Diffuse = new MatChannelContainer {Color = new float3(0, 1, 0)},
             Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
             var cubeMesh2 = SimpleMeshes.CreateCuboid(new float3(1, 1, 1));

            // Assemble the cube node containing the three components
            var cubeNode2 = new SceneNodeContainer();
            cubeNode2.Components = new List<SceneComponentContainer>();
            cubeNode2.Components.Add(_cubeTransform2);
            cubeNode2.Components.Add(cubeMaterial2);
            cubeNode2.Components.Add(cubeMesh2);


            // Create a scene with a cube
            // The three components: one XForm, one Material and the Mesh3
            _cubeTransform3 = new TransformComponent {Scale = new float3(3, 3, 1), Translation = new float3(3,0,-5)};
            var cubeMaterial3 = new MaterialComponent
            {
             Diffuse = new MatChannelContainer {Color = new float3(0.5f, .8f, .5f)},
             Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
             var cubeMesh3 = SimpleMeshes.CreateCuboid(new float3(1, 1, 1));

            // Assemble the cube node containing the three components
            var cubeNode3 = new SceneNodeContainer();
            cubeNode1.Components = new List<SceneComponentContainer>();
            cubeNode1.Components.Add(_cubeTransform3);
            cubeNode1.Components.Add(cubeMaterial3);
            cubeNode1.Components.Add(cubeMesh3);

            


            // Create the scene containing the cube as the only object
            _scene = new SceneContainer();
            _scene.Children = new List<SceneNodeContainer>();
            _scene.Children.Add(cubeNode);
            _scene.Children.Add(cubeNode1);
            _scene.Children.Add(cubeNode2); 
            _scene.Children.Add(cubeNode3);
            

            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRenderer(_scene);
           

         
      // }

        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {


//for (int i = 0; i <=a.Length; i++){

            

            Diagnostics.Log(TimeSinceStart);

            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Animate the camera angle
            _camAngle = _camAngle + 180.0f * M.Pi/360.0f * DeltaTime ;

            // Animate the cube
    
        _cubeTransform.Translation = new float3(0,1 * M.Sin(4 * 2), 0);
        _cubeTransform1.Translation = new float3(0,3 * M.Sin(8 * RealTimeSinceStart), 3);
        _cubeTransform2.Translation = new float3(0,3 * M.Sin(8 * TimeSinceStart), 6);
        _cubeTransform2.Rotation = new float3(0,10,10);
        _cubeTransform.Scale = new float3(3,5 * M.Sin(1 * TimeSinceStart), 1);
        _cubeTransform1.Scale = new float3(1,8 * M.Cos(1 * TimeSinceStart), 1);
       _cubeTransform3.Scale = new float3(3,2 * M.Cos(1 * TimeSinceStart), 7);
       _cubeTransform3.Rotation = new float3(1 * TimeSinceStart,0,0);
        
       // cubeMaterial2.Diffuse = new float3(0.2f,0.3f,0.2f);
        
        
      
        
        
         //   }
        
        
   

       
           

            // Setup the camera 
            RC.View = float4x4.CreateTranslation(0, 0, 20) * float4x4.CreateRotationY(_camAngle);


            // Render the scene on the current render context
            _sceneRenderer.Render(RC);
            

            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered farame) on the front buffer.
            Present();
            
        }


        // Is called when the window was resized
        public override void Resize()
        {
            // Set the new rendering area to the entire new windows size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width / (float)Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }
    }
}
