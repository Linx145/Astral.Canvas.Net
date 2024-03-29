﻿using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Astral.Canvas
{
    public static unsafe class AstralCanvas
    {
        public delegate void OnKeyInteractedFunction(IntPtr windowHandle, Keys key, int action);

        public delegate void OnTextInputFunction(IntPtr windowHandle, uint unicodeCharacter);

        public const string dllPath = "Astral.Canvas.Dynamic";

        [DllImport(dllPath, EntryPoint = "AstralCanvas_SetGlobalErrorCallback", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void SetGlobalErrorCallback(delegate* unmanaged<IntPtr, void> callback);

        [DllImport(dllPath, EntryPoint = "AstralCanvas_SetGlobalWarningCallback", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void SetGlobalWarningCallback(delegate* unmanaged<IntPtr, void> callback);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_ResetDeltaTimer", CallingConvention = CallingConvention.Winapi)]
        public static extern void Application_ResetDeltaTimer(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_GetApplicationName", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Application_GetApplicationName(IntPtr handle);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_GetEngineName", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Application_GetEngineName(IntPtr handle);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_GetFramesPerSecond", CallingConvention = CallingConvention.Winapi)]
        public static extern float Application_GetFramesPerSecond(IntPtr handle);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_SetFramesPerSecond", CallingConvention = CallingConvention.Winapi)]
        public static extern float Application_SetFramesPerSecond(IntPtr handle, float fps);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_AddWindow", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Application_AddWindow(IntPtr handle, string name, int width, int height, bool resizeable, IntPtr iconData, uint iconWidth, uint iconHeight);
        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_GetWindow", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Application_GetWindow(IntPtr handle, uint index);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_Init", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern IntPtr Application_Init(string appName, string engineName, uint appVersion, uint engineVersion, float framesPerSecond);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_Run", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void Application_Run(IntPtr handle, delegate* unmanaged<float, void> updateFunc, delegate* unmanaged<float, void> drawFunc, delegate* unmanaged<float, void> postEndDrawFunc, delegate* unmanaged<void> initFunc, delegate* unmanaged<void> deinitFunc);

        [DllImport(dllPath, EntryPoint = "AstralCanvasApplication_GetGraphicsDevice", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern IntPtr Application_GetGraphicsDevice(IntPtr ptr);


        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetMouseVisible", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetMouseVisible(IntPtr handle, bool visible);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetMouseIcon", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetMouseIcon(IntPtr handle, IntPtr data, uint width, uint height, int originX, int originY);

        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_GetResolution", CallingConvention = CallingConvention.Winapi)]
        public static extern Point Window_GetResolution(IntPtr handle);

        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetResolution", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetResolution(IntPtr handle, Point resolution);

        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_GetPosition", CallingConvention = CallingConvention.Winapi)]
        public static extern Point Window_GetPosition(IntPtr handle);

        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetPosition", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetPosition(IntPtr handle, Point position);

        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_AsRectangle", CallingConvention = CallingConvention.Winapi)]
        public static extern Rectangle Window_AsRectangle(IntPtr handle);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetTitle", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Window_SetTitle(IntPtr ptr, string title);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_GetIsFullscreen", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Window_GetIsFullscreen(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetFullscreen", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetFullscreen(IntPtr ptr, bool isFullscreen);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetOnKeyInteractCallback", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetOnKeyInteractCallback(IntPtr ptr, [MarshalAs(UnmanagedType.FunctionPtr)] OnKeyInteractedFunction callback);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_SetOnTextInputCallback", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_SetOnTextInputCallback(IntPtr ptr, [MarshalAs(UnmanagedType.FunctionPtr)] OnTextInputFunction callback);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_CloseWindow", CallingConvention = CallingConvention.Winapi)]
        public static extern void Window_CloseWindow(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasWindow_GetCurrentMonitorFramerate", CallingConvention = CallingConvention.Winapi)]
        public static extern int Window_GetCurrentMonitorFramerate(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetType", CallingConvention = CallingConvention.Winapi)]
        public static extern ShaderType Shader_GetType(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetModule1", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Shader_GetModule1(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetModule2", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Shader_GetModule2(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetPipelineLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Shader_GetPipelineLayout(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetVariableBinding", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern int Shader_GetVariableBinding(IntPtr ptr, string varName);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void Shader_Deinit(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_FromString", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern unsafe int Shader_FromString(ShaderType shaderType, string jsonString, IntPtr* result);

        [DllImport(dllPath, EntryPoint = "AstralCanvasSamplerState_Init", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr SamplerState_Init(SampleMode thisSampleMode, RepeatMode thisRepeatMode, bool isAnisotropic, float thisAnisotropyLevel);

        [DllImport(dllPath, EntryPoint = "AstralCanvasSamplerState_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void SamplerState_Deinit(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasSampler_GetPointClamp", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Sampler_GetPointClamp();

        [DllImport(dllPath, EntryPoint = "AstralCanvasSampler_GetLinearClamp", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Sampler_GetLinearClamp();

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Sampler_GetPointWrap();

        [DllImport(dllPath, EntryPoint = "AstralCanvasSampler_GetLinearWrap", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Sampler_GetLinearWrap();
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetData", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe void *Texture2D_GetData(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_RetrieveCurrentData", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe void* Texture2D_RetrieveCurrentData(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetWidth", CallingConvention = CallingConvention.Winapi)]
        public static extern uint Texture2D_GetWidth(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetHeight", CallingConvention = CallingConvention.Winapi)]
        public static extern uint Texture2D_GetHeight(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_StoreData", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Texture2D_StoreData(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetMipLevels", CallingConvention = CallingConvention.Winapi)]
        public static extern uint Texture2D_GetMipLevels(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetImageFormat", CallingConvention = CallingConvention.Winapi)]
        public static extern ImageFormat Texture2D_GetImageFormat(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_OwnsHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Texture2D_OwnsHandle(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_UsedForRenderTarget", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Texture2D_UsedForRenderTarget(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetImageHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Texture2D_GetImageHandle(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_GetImageView", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Texture2D_GetImageView(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Texture2D_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_FromHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Texture2D_FromHandle(IntPtr handle, uint width, uint height, ImageFormat imageFormat, bool usedForRenderTarget);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_FromData", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Texture2D_FromData(IntPtr data, uint width, uint height, ImageFormat imageFormat, bool usedForRenderTarget, bool storeData);
        [DllImport(dllPath, EntryPoint = "AstralCanvasTexture2D_FromFile", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern IntPtr Texture2D_FromFile(string fileName, bool storeData);

        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexDeclaration_AddElement", CallingConvention = CallingConvention.Winapi)]
        public static extern void VertexDeclaration_AddElement(IntPtr ptr, VertexElement element);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexDeclaration_Create", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr VertexDeclaration_Create(UIntPtr size, VertexInputRate inputRate);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexDeclaration_GetElementSize", CallingConvention = CallingConvention.Winapi)]
        public static extern UIntPtr VertexDeclaration_GetElementSize(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexDeclaration_GetInputRate", CallingConvention = CallingConvention.Winapi)]
        public static extern VertexInputRate VertexDeclaration_GetInputRate(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexDeclaration_GetElements", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe void VertexDeclaration_GetElements(IntPtr ptr, UIntPtr* outputCount, VertexElement* outputData);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGetVertexPositionColorDecl", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetVertexPositionColorDecl();
        [DllImport(dllPath, EntryPoint = "AstralCanvasGetVertexPositionColorTextureDecl", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetVertexPositionColorTextureDecl();
        [DllImport(dllPath, EntryPoint = "AstralCanvasGetVertexPositionTextureColorDecl", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetVertexPositionTextureColorDecl();
        [DllImport(dllPath, EntryPoint = "AstralCanvasGetVertexPositionNormalTextureDecl", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetVertexPositionNormalTextureDecl();
        [DllImport(dllPath, EntryPoint = "AstralCanvasGetInstanceDataMatrixDecl", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr GetInstanceDataMatrixDecl();

        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexBuffer_GetVertexDeclaration", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr VertexBuffer_GetVertexDeclaration(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexBuffer_GetCount", CallingConvention = CallingConvention.Winapi)]
        public static extern UIntPtr VertexBuffer_GetCount(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexBuffer_Create", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr VertexBuffer_Create(IntPtr thisVertexType, UIntPtr verticesCount, bool isDynamic, bool canRead);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexBuffer_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void VertexBuffer_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasVertexBuffer_SetData", CallingConvention = CallingConvention.Winapi)]
        public static extern void VertexBuffer_SetData(IntPtr ptr, IntPtr verticesData, UIntPtr verticesCount);

        [DllImport(dllPath, EntryPoint = "AstralCanvasIndexBuffer_GetSize", CallingConvention = CallingConvention.Winapi)]
        public static extern IndexBufferSize IndexBuffer_GetSize(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasIndexBuffer_GetCount", CallingConvention = CallingConvention.Winapi)]
        public static extern UIntPtr IndexBuffer_GetCount(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasIndexBuffer_Create", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr IndexBuffer_Create(IndexBufferSize indexSize, UIntPtr indexCount);
        [DllImport(dllPath, EntryPoint = "AstralCanvasIndexBuffer_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void IndexBuffer_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasIndexBuffer_SetData", CallingConvention = CallingConvention.Winapi)]
        public static extern void IndexBuffer_SetData(IntPtr ptr, IntPtr bytes, UIntPtr sizeOfBytes);

        [DllImport(dllPath, EntryPoint = "AstralCanvasInstanceBuffer_GetInstanceSize", CallingConvention = CallingConvention.Winapi)]
        public static extern UIntPtr InstanceBuffer_GetInstanceSize(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInstanceBuffer_GetCount", CallingConvention = CallingConvention.Winapi)]
        public static extern UIntPtr InstanceBuffer_GetCount(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInstanceBuffer_Create", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr InstanceBuffer_Create(UIntPtr instanceSize, UIntPtr instanceCount, bool canRead);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInstanceBuffer_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void InstanceBuffer_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInstanceBuffer_SetData", CallingConvention = CallingConvention.Winapi)]
        public static extern void InstanceBuffer_SetData(IntPtr ptr, IntPtr instanceData, UIntPtr instanceCount);

        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetTexture", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderTarget_GetTexture(IntPtr ptr, UIntPtr index);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetDepthBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderTarget_GetDepthBuffer(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetWidth", CallingConvention = CallingConvention.Winapi)]
        public static extern uint RenderTarget_GetWidth(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetHeight", CallingConvention = CallingConvention.Winapi)]
        public static extern uint RenderTarget_GetHeight(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_IsBackbuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern bool RenderTarget_IsBackbuffer(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetHandle", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderTarget_GetHandle(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_GetUseStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern bool RenderTarget_GetUseStatus(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_SetUseStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern void RenderTarget_SetUseStatus(IntPtr ptr, bool hasBeenUsedBefore);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_CreateWithInputTextures", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe IntPtr RenderTarget_CreateWithInputTextures(uint width, uint height, IntPtr* textures, UIntPtr numTextures);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_CreateFromTextures", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderTarget_CreateFromTextures(IntPtr thisBackendTexture, IntPtr thisDepthBuffer, bool isBackbuffer);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_Create", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderTarget_Create(uint width, uint height, ImageFormat imageFormat, ImageFormat depthFormat);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderTarget_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void RenderTarget_Deinit(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_Init", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderProgram_Init();
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_AddAttachment", CallingConvention = CallingConvention.Winapi)]
        public static extern int RenderProgram_AddAttachment(IntPtr ptr, ImageFormat imageFormat, bool clearColor, bool clearDepth, RenderPassOutputType outputType);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_GetRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderProgram_GetRenderPass(IntPtr ptr, UIntPtr index);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_AddRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderProgram_AddRenderPass(IntPtr ptr, int colorAttachmentID, int depthAttachmentID);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_AddRenderPasses", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderProgram_AddRenderPasses(IntPtr ptr, IntPtr colorAttachmentIDs, UIntPtr colorAttachmentIDsCount, int depthAttachmentID);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_Construct", CallingConvention = CallingConvention.Winapi)]
        public static extern void RenderProgram_Construct(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderProgram_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void RenderProgram_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPass_AddInput", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderPass_AddInput(IntPtr ptr, int inputIndex);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPass_GetColorAttachments", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe void RenderPass_GetColorAttachments(IntPtr ptr, int* attachmentIndices, UIntPtr* numAttachments);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPass_GetDepthAttachments", CallingConvention = CallingConvention.Winapi)]
        public static extern int RenderPass_GetDepthAttachments(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_GetCurrentRenderProgram", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Graphics_GetCurrentRenderProgram(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_GetCurrentRenderTarget", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr Graphics_GetCurrentRenderTarget(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_GetCurrentRenderProgramPass", CallingConvention = CallingConvention.Winapi)]
        public static extern uint Graphics_GetCurrentRenderProgramPass(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_GetClipArea", CallingConvention = CallingConvention.Winapi)]
        public static extern Rectangle Graphics_GetClipArea(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetClipArea", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetClipArea(IntPtr ptr, int x, int y, int w, int h);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_GetViewport", CallingConvention = CallingConvention.Winapi)]
        public static extern Rectangle Graphics_GetViewport(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetViewport", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetViewport(IntPtr ptr, int x, int y, int w, int h);

        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetVertexBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetVertexBuffer(IntPtr ptr, IntPtr vb, uint bindingPoint);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetInstanceBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetInstanceBuffer(IntPtr ptr, IntPtr instanceBuffer, uint bindingPoint);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetIndexBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetIndexBuffer(IntPtr ptr, IntPtr indexBuffer);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetRenderTarget", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SetRenderTarget(IntPtr ptr, IntPtr target);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_StartRenderProgram", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_StartRenderProgram(IntPtr ptr, IntPtr program, Color clearColor);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_NextRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_NextRenderPass(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_EndRenderProgram", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_EndRenderProgram(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_UseRenderPipeline", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_UseRenderPipeline(IntPtr ptr, IntPtr pipeline);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_AwaitGraphicsIdle", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_AwaitGraphicsIdle(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetShaderVariable", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Graphics_SetShaderVariable(IntPtr ptr, string variableName, IntPtr data, UIntPtr size);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetShaderVariableTexture", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Graphics_SetShaderVariableTexture(IntPtr ptr, string variableName, IntPtr texture);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetShaderVariableTextures", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Graphics_SetShaderVariableTextures(IntPtr ptr, string variableName, IntPtr textures, UIntPtr count);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetShaderVariableSampler", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Graphics_SetShaderVariableSampler(IntPtr ptr, string variableName, IntPtr sampler);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SetShaderVariableSamplers", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern void Graphics_SetShaderVariableSamplers(IntPtr ptr, string variableName, IntPtr samplers, UIntPtr count);

        [DllImport(dllPath, EntryPoint = "AstralCanvasShader_GetVariableAt", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern IntPtr Shader_GetVariableAt(IntPtr ptr, UIntPtr index);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetName", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi)]
        public static extern string ShaderVariable_GetName(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetSet", CallingConvention = CallingConvention.Winapi)]
        public static extern uint ShaderVariable_GetSet(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetBinding", CallingConvention = CallingConvention.Winapi)]
        public static extern uint ShaderVariable_GetBinding(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetType", CallingConvention = CallingConvention.Winapi)]
        public static extern ShaderResourceType ShaderVariable_GetType(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetAccessedBy", CallingConvention = CallingConvention.Winapi)]
        public static extern ShaderInputAccessedBy ShaderVariable_GetAccessedBy(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetArrayLength", CallingConvention = CallingConvention.Winapi)]
        public static extern uint ShaderVariable_GetArrayLength(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasShaderVariable_GetSize", CallingConvention = CallingConvention.Winapi)]
        public static extern uint ShaderVariable_GetSize(IntPtr ptr);

        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_SendUpdatedUniforms", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_SendUpdatedUniforms(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasGraphics_DrawIndexedPrimitives", CallingConvention = CallingConvention.Winapi)]
        public static extern void Graphics_DrawIndexedPrimitives(IntPtr ptr, uint indexCount, uint instanceCount, uint firstIndex, uint vertexOffset, uint firstInstance);

        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_GetLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderPipeline_GetLayout(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_GetShader", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr RenderPipeline_GetShader(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_GetCullMode", CallingConvention = CallingConvention.Winapi)]
        public static extern CullMode RenderPipeline_GetCullMode(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_GetPrimitiveType", CallingConvention = CallingConvention.Winapi)]
        public static extern PrimitiveType RenderPipeline_GetPrimitiveType(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_GetBlendState", CallingConvention = CallingConvention.Winapi)]
        public static extern BlendState RenderPipeline_GetBlendState(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_IsDepthWrite", CallingConvention = CallingConvention.Winapi)]
        public static extern bool RenderPipeline_IsDepthWrite(IntPtr ptr);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_IsDepthTest", CallingConvention = CallingConvention.Winapi)]
        public static extern bool RenderPipeline_IsDepthTest(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_Deinit", CallingConvention = CallingConvention.Winapi)]
        public static extern void RenderPipeline_Deinit(IntPtr ptr);
        [DllImport(dllPath, EntryPoint = "AstralCanvasRenderPipeline_Init", CallingConvention = CallingConvention.Winapi)]
        public static extern unsafe IntPtr RenderPipeline_Init(
            IntPtr pipelineShader,
            CullMode pipelineCullMode,
            PrimitiveType pipelinePrimitiveType,
            BlendState pipelineBlendState,
            bool testDepth,
            bool writeToDepth,
            IntPtr* vertexDeclarations,
            UIntPtr vertexDeclarationCount);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsKeyDown", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsKeyDown(Keys key);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsKeyPressed", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsKeyPressed(Keys key);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsKeyReleased", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsKeyReleased(Keys key);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsMouseDown", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsMouseDown(MouseButtons button);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsMousePressed", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsMousePressed(MouseButtons button);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_IsMouseReleased", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_IsMouseReleased(MouseButtons button);

        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_SimulateMousePress", CallingConvention = CallingConvention.Winapi)]
        public static extern void Input_SimulateMousePress(MouseButtons button);

        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_SimulateMouseRelease", CallingConvention = CallingConvention.Winapi)]
        public static extern void Input_SimulateMouseRelease(MouseButtons button);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsButtonDown", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsButtonDown(uint controllerIndex, ControllerButtons button);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsButtonPress", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsButtonPress(uint controllerIndex, ControllerButtons button);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsButtonRelease", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsButtonRelease(uint controllerIndex, ControllerButtons button);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsR2Down", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsR2Down(uint controllerIndex);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerGetR2DownAmount", CallingConvention = CallingConvention.Winapi)]
        public static extern float Input_ControllerGetR2DownAmount(uint controllerIndex);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsL2Down", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsL2Down(uint controllerIndex);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerGetL2DownAmount", CallingConvention = CallingConvention.Winapi)]
        public static extern float Input_ControllerGetL2DownAmount(uint controllerIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsConnected", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsConnected(uint controllerIndex);

        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_GetLeftStickAxis", CallingConvention = CallingConvention.Winapi)]
        public static extern Vector2 Input_GetLeftStickAxis(uint controllerIndex);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_GetRightStickAxis", CallingConvention = CallingConvention.Winapi)]
        public static extern Vector2 Input_GetRightStickAxis(uint controllerIndex);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsL2Pressed", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsL2Pressed(uint controllerIndex);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsR2Pressed", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsR2Pressed(uint controllerIndex);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsL2Released", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsL2Released(uint controllerIndex);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_ControllerIsR2Released", CallingConvention = CallingConvention.Winapi)]
        public static extern bool Input_ControllerIsR2Released(uint controllerIndex);

        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_GetMousePosition", CallingConvention = CallingConvention.Winapi)]
        public static extern Vector2 Input_GetMousePosition();
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_SetMousePosition", CallingConvention = CallingConvention.Winapi)]
        public static extern void Input_SetMousePosition(Vector2 position);
        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_GetMouseScroll", CallingConvention = CallingConvention.Winapi)]
        public static extern Vector2 Input_GetMouseScroll();

        [DllImport(dllPath, EntryPoint = "AstralCanvasInput_AwaitInputChar", CallingConvention = CallingConvention.Winapi)]
        public static extern uint Input_AwaitInputChar();

    }
}