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
    public class AssetsPicking : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;
        private TransformComponent _baseTransform; 
        private ScenePicker _scenePicker;
        private TransformComponent _turretTransform;
        private TransformComponent _gunTransform1;
         private TransformComponent _gunTransform2; 
         private TransformComponent _gunTransform3;
        private TransformComponent _tankTransform;
         private TransformComponent _radvl;
        private TransformComponent _radvr;
        private TransformComponent _radhl;
        private TransformComponent _radhr;
      

        private PickResult newPick;
        private PickResult _currentPick;
        private float3 _oldColor;
        

        SceneContainer CreateScene()
        {
            // Initialize transform components that need to be changed inside "RenderAFrame"
            _baseTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 0, 0)
            };

            // Setup the scene graph
            return new SceneContainer
            {
                Children = new List<SceneNodeContainer>
                {
                    new SceneNodeContainer
                    {
                        Components = new List<SceneComponentContainer>
                        {
                            // TRANSFROM COMPONENT
                            _baseTransform,

                            // MATERIAL COMPONENT
                            new MaterialComponent
                            {
                                Diffuse = new MatChannelContainer { Color = new float3(0.7f, 0.7f, 0.7f) },
                                Specular = new SpecularChannelContainer { Color = new float3(1, 1, 1), Shininess = 5 }
                            },

                            // MESH COMPONENT
                            // SimpleAssetsPickinges.CreateCuboid(new float3(10, 10, 10))
                            SimpleMeshes.CreateCuboid(new float3(10, 10, 10))
                        }
                    },
                }
            };
        }

        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intentsity in all color channels R, G, B, A).
            RC.ClearColor = new float4(0.8f, 0.9f, 0.7f, 1);

            _scene = AssetStorage.Get<SceneContainer>("radpanzer2.fus");

         
            
            _radvl = _scene.Children.FindNodes(node => node.Name == "rad_vl")?.FirstOrDefault()?.GetTransform();
            _radhl = _scene.Children.FindNodes(node => node.Name == "rad_hl")?.FirstOrDefault()?.GetTransform();
          
            _radvr= _scene.Children.FindNodes(node => node.Name == "rad_vr")?.FirstOrDefault()?.GetTransform();
            _radhr = _scene.Children.FindNodes(node => node.Name == "rad_hr")?.FirstOrDefault()?.GetTransform();
           
            _turretTransform = _scene.Children.FindNodes(node => node.Name == "turm")?.FirstOrDefault()?.GetTransform();
            _tankTransform = _scene.Children.FindNodes(node => node.Name == "hull")?.FirstOrDefault()?.GetTransform();
            _gunTransform1 = _scene.Children.FindNodes(node => node.Name == "gun1")?.FirstOrDefault()?.GetTransform();
            _gunTransform2 = _scene.Children.FindNodes(node => node.Name == "gun2")?.FirstOrDefault()?.GetTransform();
            _gunTransform3 = _scene.Children.FindNodes(node => node.Name == "gun3")?.FirstOrDefault()?.GetTransform();
            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRenderer(_scene);
            _scenePicker = new ScenePicker(_scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
         //   _rightRearTransform.Rotation = new float3(0, M.MinAngle(TimeSinceStart), 0);


            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Setup the camera 
             RC.View = float4x4.CreateTranslation(0, 0, 10) * float4x4.CreateRotationX(-(float) Atan(15.0 / 40.0));

           
    if (Mouse.LeftButton)
            {
                float2 pickPosClip = Mouse.Position * new float2(2.0f / Width, -2.0f / Height) + new float2(-1, 1);
                _scenePicker.View = RC.View;
                _scenePicker.Projection = RC.Projection;
                List<PickResult> pickResults = _scenePicker.Pick(pickPosClip).ToList();
                PickResult newPick = null;
                if (pickResults.Count > 0)
                {
                    pickResults.Sort((a, b) => Sign(a.ClipPos.z - b.ClipPos.z));
                    newPick = pickResults[0];
                }
                if (newPick?.Node != _currentPick?.Node)
                {
                    if (_currentPick != null)
                    {
                        _currentPick.Node.GetMaterial().Diffuse.Color = _oldColor;
                    }
                    if (newPick != null)
                    {
                        var mat = newPick.Node.GetMaterial();
                        _oldColor = mat.Diffuse.Color;
                        mat.Diffuse.Color = new float3(0, 1f, 1f);
                    }
                    _currentPick = newPick;
                    }
            }
          
     //   _gunTransform.Rotation = new float3(0,0,1.5f);
      //  _leftFrontTransform.Rotation = new float3(5,0,0);

      if (_currentPick != null) {
              
                if (_currentPick.Node.Name == "hull") {
                    if (Keyboard.UpDownAxis != 0) {
                        _tankTransform.Translation += new float3(-3 * Keyboard.UpDownAxis* DeltaTime, 0, 0);
                        _radvl.Rotation += new float3(-3 * Keyboard.UpDownAxis* DeltaTime, 0, 0);
                        _radvr.Rotation += new float3(-3 * Keyboard.UpDownAxis* DeltaTime, 0, 0);
                    
                        _radhl.Rotation += new float3(-3 * Keyboard.UpDownAxis* DeltaTime, 0, 0);
                        _radhr.Rotation += new float3(-3 * Keyboard.UpDownAxis* DeltaTime, 0, 0);
                       
                    }
                  
                }
                if (_currentPick.Node.Name == "hull") {
                  if (Keyboard.LeftRightAxis != 0) {
                        _tankTransform.Rotation += new float3(0, -3f * Keyboard.LeftRightAxis*DeltaTime, 0);
                        _radvl.Rotation += new float3(-3f * Keyboard.LeftRightAxis*DeltaTime, 0, 0);
                        _radvr.Rotation += new float3(-3f * Keyboard.LeftRightAxis*DeltaTime, 0, 0);
                    
                        _radhl.Rotation += new float3(-3f * Keyboard.LeftRightAxis*DeltaTime, 0, 0);
                        _radhr.Rotation += new float3(-3f * Keyboard.LeftRightAxis*DeltaTime, 0, 0);
                    
                    }
                    }
                if (_currentPick.Node.Name == "turm") {
                   if (Keyboard.LeftRightAxis != 0) {
                        _turretTransform.Rotation += new float3(0, 0.9f * Keyboard.LeftRightAxis* DeltaTime, 0);
                   }
                        if (Keyboard.UpDownAxis != 0) {
                        _gunTransform1.Rotation += new float3(0,0,  -1 * Keyboard.UpDownAxis*DeltaTime);
                        _gunTransform2.Rotation += new float3(0,0,  -1 * Keyboard.UpDownAxis*DeltaTime);
                        _gunTransform3.Rotation += new float3(0,0,  -1 * Keyboard.UpDownAxis*DeltaTime);
                }    
        }

        if(_currentPick.Node.Name == "gun1"){
                    if (Keyboard.UpDownAxis != 0) {
                        
                    _gunTransform1.Rotation += new float3(0, 0, -1 * Keyboard.UpDownAxis*DeltaTime);
            
                  }
            }
         
        if(_currentPick.Node.Name == "gun2"){
                    if (Keyboard.UpDownAxis != 0) {
                    _gunTransform2.Rotation += new float3(0, 0, -1 * Keyboard.UpDownAxis*DeltaTime);
                    }
                }
        if(_currentPick.Node.Name == "gun3"){
                    if (Keyboard.UpDownAxis != 0) {
                    _gunTransform3.Rotation += new float3(0, 0, -1 * Keyboard.UpDownAxis*DeltaTime);
                    }
                }

        if(_currentPick.Node.Name == "rad_vr"){
                    if (Keyboard.UpDownAxis != 0) {
                    _radvr.Rotation += new float3(-0.02f * Keyboard.UpDownAxis, 0, 0);
                    }
                }
        if(_currentPick.Node.Name == "rad_vl"){
                    if (Keyboard.UpDownAxis != 0) {
                    _radvl.Rotation += new float3(-0.02f * Keyboard.UpDownAxis, 0, 0);
                    }
                }

        if(_currentPick.Node.Name == "rad_hl"){
                    if (Keyboard.UpDownAxis != 0) {
                    _radhl.Rotation += new float3(-0.02f * Keyboard.UpDownAxis, 0, 0);
                    }
                }
        if(_currentPick.Node.Name == "rad_hr"){
                    if (Keyboard.UpDownAxis != 0) {
                    _radhr.Rotation += new float3(-0.025f * Keyboard.UpDownAxis, 0, 0);
                    }
                }
      }
      
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

            // 0.25*PI Rad -> 45� Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }
    }
}
