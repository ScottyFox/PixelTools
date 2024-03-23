using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace ScottyFoxArt.PixelTools.ShaderTextures
{
    public static class ShaderTextureBuilder
    {
        public static BlendModeShaderLibrary shaderLibrary = null;
        //TODO handle Async Render Jobs utilizing AsyncGPUReadbackRequest
        //private static Task _jobTask = null;
        //private static Queue<ShaderTextureBuilder_Job> _jobs = new Queue<ShaderTextureBuilder_Job>();
        public static void SetShaderLibrary(BlendModeShaderLibrary library)
        {
            shaderLibrary = library;
        }
        public static Texture2D RenderBundle(LayerBundle bundle, int width, int height, bool ReadToMemory = false)
        {
            var new_job = new ShaderTextureBuilder_Job(shaderLibrary, null, bundle, width, height, ReadToMemory);
            return new_job.Render();
        }
        public static Texture2D RenderBundle(LayerBundleData bundleData)
        {
            var new_job = new ShaderTextureBuilder_Job(bundleData.library, null, bundleData.layerBundle, bundleData.outputSize.x, bundleData.outputSize.y, bundleData.generateOutput);
            return new_job.Render();
        }
        public static void RenderBundle_Async(System.Action<Texture2D> listener, LayerBundle bundle, int width, int height, bool ReadToMemory = false)
        {
            //var new_job = new ShaderTextureBuilder_Job(shaderLibrary, listener, bundle, width, height, ReadToMemory);
            //_jobs.Enqueue(new_job);
            //StartJobs();
        }
        public static void RenderBundle_Async(System.Action<Texture2D> listener, LayerBundleData bundleData)
        {
            //var new_job = new ShaderTextureBuilder_Job(bundleData.library, listener, bundleData.layerBundle, bundleData.outputSize.x, bundleData.outputSize.y, bundleData.generateOutput);
            //_jobs.Enqueue(new_job);
            //StartJobs();
        }
        /*
        private static void StartJobs()
        {
            if (_jobTask == null || _jobTask.IsCompleted)
                _jobTask = Task.Run(HandleJobs);
        }
        private static Task HandleJobs()
        {
            while (_jobs.TryDequeue(out var job))
            {
                job.Render();
            }
            return Task.CompletedTask;
        }
        */
    }
}