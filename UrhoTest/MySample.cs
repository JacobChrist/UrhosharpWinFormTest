using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Actions;
using Urho.Audio;
using Urho.Desktop;
using Urho.Gui;
using Urho.IO;
using Urho.Navigation;
using Urho.Network;
using Urho.Physics;
using Urho.Repl;
using Urho.Resources;
using Urho.Shapes;
using Urho.Urho2D;

// Issues with Urho articles:
// o. Introduction article is incomplete code, almost not worth reading past the "Getting Start" section
//    https://developer.xamarin.com/guides/cross-platform/urho/introduction/
//
// o. These are the notes up the the section on "Identification and scene hierarchy" from this article: 
//    https://developer.xamarin.com/guides/cross-platform/urho/using/
//
// o. How to install UrhoSharp in VS2015
//    o. Install NuGet into Visual Studio
//       Download installer from here: https://www.nuget.org/
//    o. Install UrhoSharp
//       In Visual Studio goto: Tools->NuGet Package Manager->Package Manager Console
//       Follow install instructions on this page:
//       https://www.nuget.org/packages/UrhoSharp/
//       PM> Install-Package UrhoSharp -Version 1.0.410
//
// o. Where to put your class 
//    In a file by itself
//
// o. How to get your class to run at starup
//    o. Method 1
//       o. Change this:
//          [STAThread]
//          static void Main()
//          {
//              Application.EnableVisualStyles();
//              Application.SetCompatibleTextRenderingDefault(false);
//              Application.Run(new Form1());
//          }
//
//       o. To this:
//          static void Main(string[] args)
//          {
//              DesktopUrhoInitializer.AssetsDirectory = @"../../../../Assets";
//              new MySample().Run();
//          }
//
//     o. Method 2
//        o. Launch urho from a button on another form (do not modify main)
//            private void button1_Click(object sender, EventArgs e)
//            {
//                MySample f = new MySample();
//                f.Run();
//
//            }
//
// o. Where to create the "Assets" folder.
//    In the root of the project folder
//    I'm not sure where to download the assets talked about in the article
//
// o. What referances are needed, I just added everything:
//    using Urho;
//    using Urho.Actions;
//    using Urho.Audio;
//    using Urho.Desktop;
//    using Urho.Gui;
//    using Urho.IO;
//    using Urho.Navigation;
//    using Urho.Network;
//    using Urho.Physics;
//    using Urho.Repl;
//    using Urho.Resources;
//    using Urho.Shapes;
//    using Urho.Urho2D;
//
// o. The scene 'var' is not defined.
//
// o. The CameraNode 'var' is not defined
//
// o. The camera 'var' is not defined
//
// o. The Renderer.SetViewport case is incorrect and the code is missing a semi colon
//
// o. "And now you should be able to see the results of your creation." 
//    o. Only after you set the configuration manager to x64
//       If you do not do this you will get the following exception: An unhandled exception of type 'System.BadImageFormatException' occurred in Urho.dll

namespace UrhoTest
{
    class MySample : Application
    {
        bool movementsEnabled;
        Scene scene;
        Node planeNode;
        Node boxNode;
        Node sphereNode;

        public float y_speed = 0;


        public MySample(ApplicationOptions options = null) : base(SetOptions(options)) { }

        private static ApplicationOptions SetOptions(ApplicationOptions options)
        {
            options.TouchEmulation = true;
            return options;
        }

        protected override void Start()
        {
            CreateScene();
            Input.MouseMode = MouseMode.Absolute; // Use OS Mouse
            Input.MouseGrabbed = false;

            //Input.KeyDown += HandleKeyDown;
            Input.MouseButtonDown += HandleMouseButtonDown;
        }
        void HandleKeyDown(KeyDownEventArgs args)
        {
            //this.Engine.Exit();
            System.Console.WriteLine("key pressed");
        }

        void HandleMouseButtonDown(MouseButtonDownEventArgs args)
        {
            System.Console.WriteLine("button pressed");
        }

        async void CreateScene()
        {
            scene = new Scene();

            // Create the Octree component to the scene. This is required before
            // adding any drawable components, or else nothing will show up. The
            // default octree volume will be from -1000, -1000, -1000) to 
            //(1000, 1000, 1000) in world coordinates; it is also legal to place 
            // objects outside the volume but their visibility can then not be
            // checked in a hierarchically optimizing manner
            scene.CreateComponent<Octree>();

            // Create a child scene node (at world origin) and a StaticModel
            // component into it. Set the StaticModel to show a simple plane mesh
            // with a material. Note that naming the scene nodes is
            // optional. Scale the scene node larger (100 x 100 world units)
            planeNode = scene.CreateChild("Mushroom");
            planeNode.Scale = new Vector3(25, 25, 25);
            planeNode.Position = new Vector3(0.0f, 0.0f, 0.0f);
            var planeObject = planeNode.CreateComponent<StaticModel>();
            planeObject.Model = ResourceCache.GetModel("Models/Mushroom.mdl");
            planeObject.SetMaterial(ResourceCache.GetMaterial("Materials/Mushroom.xml"));


            // Create a child scene node that uses a primitive
            boxNode = scene.CreateChild("Box Primitive");
            boxNode.Scale = new Vector3(10.0f, 10.0f, 10.0f);
            boxNode.Position = new Vector3(25.0f, 5.0f, 0.0f);
            var box = boxNode.CreateComponent<Box>();
            box.Color = Color.Yellow;

            sphereNode = scene.CreateChild("Box Primitive");
            sphereNode.Scale = new Vector3(10.0f, 10.0f, 10.0f);
            sphereNode.Position = new Vector3(-25.0f, 5.0f, 0.0f);
            var sphere = sphereNode.CreateComponent<Sphere>();
            sphere.Color = Color.Red;

            // Add a light to the world so that we can see something. 
            var lightNode = scene.CreateChild("DirectionalLight");
            //lightNode.SetDirection(new Vector3(0.6f, 1.0f, 0.8f));
            lightNode.Position = new Vector3(0, -20, 10);
            lightNode.Rotation = new Quaternion(10, 10, 0);

            var light = lightNode.CreateComponent<Light>();
            light.Brightness = 0.9f;
            light.LightType = LightType.Directional;
            //light.LightType = LightType.Spot;
            //light.Fov = 500.5f;
            //light.Range = 0.1f;

            var CameraNode = scene.CreateChild("camera");
            var camera = CameraNode.CreateComponent<Camera>();
            //camera.Orthographic = true;

            // Top View
            CameraNode.Position = new Vector3(0, 200, 0);
            CameraNode.Rotation = new Quaternion(90, 0, 0);

            // Side View
            CameraNode.Position = new Vector3(0, 10, -100);
            CameraNode.Rotation = new Quaternion(10, 0, 0);

            var viewport = new Viewport(Context, scene, camera, null);
            Renderer.SetViewport(0, viewport);
            viewport.SetClearColor(Color.Gray);

            var myLight = lightNode.GetComponent<Light>();

            await planeNode.RunActionsAsync(new EaseBackOut(new RotateBy(2f, 0, 360, 0)));
            movementsEnabled = true;
        }
        protected override void OnUpdate(float timeStep)
        {
            if (Input.NumTouches == 1 && movementsEnabled)
            {
                var touch = Input.GetTouch(0);
                //planeNode.Rotate(new Quaternion(-touch.Delta.Y, 0, -touch.Delta.X), TransformSpace.Local);
                //barNode.Translate(new Vector3(touch.Delta.X, 0, -touch.Delta.Y), TransformSpace.World);
                planeNode.Translate(new Vector3(touch.Delta.X, 0, -touch.Delta.Y), TransformSpace.World);
            }
            //else
            {
                planeNode.Rotate(new Quaternion(y_speed, 0, 0) * timeStep, TransformSpace.Local);
                sphereNode.Translate(new Vector3(0, y_speed, 0), TransformSpace.Local);
            }
            base.OnUpdate(timeStep);
        }
    }

}
