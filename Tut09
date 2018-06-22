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
    public class HierarchyInput : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;
        private float _camAngle = 0;
        private TransformComponent _baseTransform;
        private TransformComponent _bodyTransform;
        private TransformComponent _upperArmTransform;
        private TransformComponent _foreArmTransform;
        private TransformComponent _claw1Transform;
        private TransformComponent _claw2Transform;
        private TransformComponent _clawBaseTransform;
        private Boolean geschlossen;

        SceneContainer CreateScene()
        {
            // Initialize transform components that need to be changed inside "RenderAFrame"
            _baseTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 0, 0)
            };
            _bodyTransform = new TransformComponent
            {
                Rotation = new float3(0, 1.2f, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(0, 6, 0)
            };
            _upperArmTransform = new TransformComponent
            {
                Rotation = new float3(0.8f, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(2, 4, 0)
            };
            _foreArmTransform = new TransformComponent
            {
                Rotation = new float3(0, 0, 0),
                Scale = new float3(1, 1, 1),
                Translation = new float3(-2, 8, 0)
            };
            _clawBaseTransform = new TransformComponent
            {
                Rotation = new float3(0,0,0),
                Scale = new float3(1,1,1),
                Translation = new float3(0,5.5f,0)
            };
            _claw1Transform = new TransformComponent
            {
                Rotation = new float3(0,0,0),
                Scale = new float3(1 ,1 , 1),
                Translation = new float3(-3,5.5f,0)
            };
            _claw2Transform = new TransformComponent
            {
                Rotation = new float3(0,0,0),
                Scale = new float3(1 ,1 , 1),
                Translation = new float3(3,5.5f,0)
            };

            // Setup the scene graph
            return new SceneContainer
            {
                Children = new List<SceneNodeContainer>
                {
                    // GREY BASE
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
                            SimpleMeshes.CreateCuboid(new float3(10, 2, 10))
                        }
                    },
                    // RED BODY
                    new SceneNodeContainer
                    {
                        Components = new List<SceneComponentContainer>
                        {
                            _bodyTransform,
                            new MaterialComponent
                            {
                                Diffuse = new MatChannelContainer { Color = new float3(1, 0, 0) },
                                Specular = new SpecularChannelContainer { Color = new float3(1, 1, 1), Shininess = 5 }
                            },
                            SimpleMeshes.CreateCuboid(new float3(2, 10, 2))
                        },
                        Children = new List<SceneNodeContainer>
                        {
                            // GREEN UPPER ARM
                            new SceneNodeContainer
                            {
                                Components = new List<SceneComponentContainer>
                                {
                                    _upperArmTransform,
                                },
                                Children = new List<SceneNodeContainer>
                                {
                                    new SceneNodeContainer
                                    {
                                        Components = new List<SceneComponentContainer>
                                        {
                                            new TransformComponent
                                            {
                                                Rotation = new float3(0, 0, 0),
                                                Scale = new float3(1,1, .5f),
                                                Translation = new float3(0, 4, 0)
                                            },
                                            new MaterialComponent
                                            {
                                                Diffuse = new MatChannelContainer { Color = new float3(0, 1, 0) },
                                                Specular = new SpecularChannelContainer { Color = new float3(1, 1, 1), Shininess = 5 }
                                            },
                                            SimpleMeshes.CreateCuboid(new float3(2, 10, 2))
                                        }
                                    },
                                    // BLUE FOREARM
                                    new SceneNodeContainer
                                    {
                                        Components = new List<SceneComponentContainer>
                                        {
                                            _foreArmTransform,
                                        },
                                        Children = new List<SceneNodeContainer>
                                        {
                                            new SceneNodeContainer
                                            {
                                                Components = new List<SceneComponentContainer>
                                                {
                                                    new TransformComponent
                                                    {
                                                        Rotation = new float3(0, 0, 0),
                                                        Scale = new float3(1,1, .5f),
                                                        Translation = new float3(0, 4, 0)
                                                    },
                                                    new MaterialComponent
                                                    {
                                                        Diffuse = new MatChannelContainer { Color = new float3(0, 0, 1) },
                                                        Specular = new SpecularChannelContainer { Color = new float3(1, 1, 1), Shininess = 5 }
                                                    },
                                                    SimpleMeshes.CreateCuboid(new float3(2, 10, 2))
                                                }
                                            },
                                            //Claw base
                                            new SceneNodeContainer
                                            {
                                                Components = new List<SceneComponentContainer>
                                                {
                                                    _clawBaseTransform,
                                                },
                                                Children = new List<SceneNodeContainer>
                                                {
                                                    new SceneNodeContainer
                                                    {
                                                        Components = new List<SceneComponentContainer>
                                                        {
                                                            new TransformComponent
                                                            {
                                                                Rotation = new float3(0,0,0),
                                                                Scale = new float3(7,.1f,.5f),
                                                                Translation = new float3(0,4,0)
                                                            },
                                                            new MaterialComponent
                                                            {
                                                                Diffuse = new MatChannelContainer { Color = new float3(0,1,1) },
                                                                Specular = new SpecularChannelContainer{ Color = new float3(1, 1, 1), Shininess = 5 }
                                                            
                                                        },
                                                        SimpleMeshes.CreateCuboid(new float3(2,10,2))
                                                        }   
                                                    },
                                                    //Claw 2
                                            new SceneNodeContainer
                                            {
                                                Components = new List<SceneComponentContainer>
                                                {
                                                    _claw2Transform,
                                                },
                                                Children = new List<SceneNodeContainer>
                                                {
                                                    new SceneNodeContainer
                                                    {
                                                        Components = new List<SceneComponentContainer>
                                                        {
                                                            new TransformComponent
                                                            {
                                                                Rotation = new float3(0,0,0),
                                                                Scale = new float3(.5f,1,.5f),
                                                                Translation = new float3(3.5f,9.5f,0)
                                                            },
                                                            new MaterialComponent
                                                            {
                                                                Diffuse = new MatChannelContainer { Color = new float3(1,0,1) },
                                                                Specular = new SpecularChannelContainer{ Color = new float3(1, 1, 1), Shininess = 5 }
                                                            
                                                            },
                                                            SimpleMeshes.CreateCuboid(new float3(2,10,2))
                                                                }      
                                                            }
                                                    
                                                        }
                                            
                                                    },
                                                    //Claw 1 
                                                    new SceneNodeContainer
                                                {   
                                                Components = new List<SceneComponentContainer>
                                                {
                                                    _claw1Transform,
                                                },
                                                Children = new List<SceneNodeContainer>
                                                {
                                                    new SceneNodeContainer
                                                    {
                                                        Components = new List<SceneComponentContainer>
                                                        {
                                                            new TransformComponent
                                                            {
                                                                Rotation = new float3(0,0,0),
                                                                Scale = new float3(.5f,1,.5f),
                                                                Translation = new float3(-3.5f,9.5f,0)
                                                            },
                                                            new MaterialComponent
                                                            {
                                                                Diffuse = new MatChannelContainer { Color = new float3(1,0,1) },
                                                                Specular = new SpecularChannelContainer{ Color = new float3(1, 1, 1), Shininess = 5 }
                                                            
                                                            },
                                                            SimpleMeshes.CreateCuboid(new float3(2,10,2))
                                                        }
                                                    },
                                                }
                                                }
                                                }
                                            }

                                        }   
                                    }
                                }
                            },
                        }
                    }
                }
            };
        }

        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to white (100% intentsity in all color channels R, G, B, A).
            RC.ClearColor = new float4(0.8f, 0.9f, 0.7f, 1);

            _scene = CreateScene();

            // Create a scene renderer holding the scene above
            _sceneRenderer = new SceneRenderer(_scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            //Rot und Base Y-Drehung
            float bodyRot = _bodyTransform.Rotation.y;
            bodyRot +=2 * Keyboard.ADAxis * DeltaTime;
            _bodyTransform.Rotation = new float3(0, bodyRot, 0);
            
            
            //grün X-Drehung
            float greenupperarm = _upperArmTransform.Rotation.x;
            greenupperarm += 2f * Keyboard.WSAxis * DeltaTime;
          if ((greenupperarm * 10) > -20 && (greenupperarm * 10) < 20)
            _upperArmTransform.Rotation = new float3(greenupperarm, 0, 0);


            //Blau X-Drehung
            float blueforearm = _foreArmTransform.Rotation.x;
            blueforearm += 2f * Keyboard.UpDownAxis * DeltaTime;
          if ((blueforearm * 20) > -26 && (blueforearm * 20) < 26)
            _foreArmTransform.Rotation = new float3(blueforearm, 0, 0);


            //Claw 1 Bewegung
            float claw1 = _claw1Transform.Translation.z;
            claw1 += 2.8f * Keyboard.LeftRightAxis;
            _claw1Transform.Translation = new float3(-claw1,0,0);
             //Claw 2 Bewegung
           float claw2 = _claw2Transform.Translation.z;
            claw2 += 2.8f * Keyboard.LeftRightAxis;
            _claw2Transform.Translation = new float3(claw2,0,0);  
    
       

            if(Mouse.LeftButton == true){
            //  float3 cam = _camAngle.Rotation.z;
             _camAngle+= 0.001f * Mouse.Velocity.x *DeltaTime;
           }

           if (Keyboard.GetKey(KeyCodes.F))
            {
                claw1 = _claw1Transform.Translation.z;
                claw2 = _claw2Transform.Translation.z;
                        claw1 += 2.80f ;
                        claw2 += 2.80f;
                        _claw1Transform.Translation = new float3(-claw1, 0, 0);
                        _claw2Transform.Translation = new float3(claw1, 0, 0);
            }

            if (Keyboard.GetKey(KeyCodes.E))
            {
                claw1 = _claw1Transform.Translation.z;
                claw2 = _claw2Transform.Translation.z;
                        claw1 += 2.80f ;
                        claw2 += 2.80f;
                        _claw1Transform.Translation = new float3(claw1, 0, 0);
                        _claw2Transform.Translation = new float3(-claw1, 0, 0);
            }


            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // Setup the camera 
            RC.View = float4x4.CreateTranslation(0* DeltaTime , -10 , 50) * float4x4.CreateRotationY(_camAngle);

            if(Keyboard.GetKey(KeyCodes.R)){
                _camAngle = _camAngle + 90.0f * M.Pi/180.0f * DeltaTime;
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

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }
    }
}
