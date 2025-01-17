﻿//========= Copyright 2018, HTC Corporation. All rights reserved. ===========
using System;
using System.Runtime.InteropServices;

namespace Vive
{
    namespace Plugin.SR
    {
        public class SRWorkModule_API
        {
            public delegate void CallbackBasic(IntPtr data);

            /** Turn on the specific SRruntime engine.
            * @param ModuleType What kind of engine should be turn on
            * @param config
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int Initial(ModuleType moduleType, IntPtr config);

            /** Initial the specific SRruntime engine without start.
            * @param ModuleType What kind of engine should be turn on
            * @param config
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int InitialWOStart(ModuleType moduleType, IntPtr config);

            /** Start the specific SRruntime engine.
            * @param ModuleType What kind of engine should be turn on
            * @param config
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int StartModule(ModuleType moduleType);

            /** Stop ViveSR all modules.
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int StopViveSR();

            /** Turn off and release the specific SRruntime engine.
            * @param ModuleType What kind of engine should be turn off
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int Release(ModuleType moduleType);

            /** Get the status of the specific engine.
            * @param ModuleType What kind of engine is interested in
            * @param status The status of the specific engine
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetStatus(ModuleType moduleType, out ModuleStatus status);

            /** Link two modules.
            * @param module_type_in The first module.
            * @param module_type_out The second module.
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int LinkModule(int module_type_in, int module_type_out);

            /** Unlink two modules.
            * @param module_type_in The first module.
            * @param module_type_out The second module.
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int UnlinkModule(int module_type_in, int module_type_out);


            /** Get controller tracking pose from see-through module.
            * @param value the pointer of controller pose. The struct is defined in TrackingPoseInfo.
            * @return one of Vive.Plugin.SR.Error
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetControllerTrackingPose(ref ViveSR_ControllerLatency.TrackingPoseInfo value);

            #region see_through

            /** Get the camera parameters from engine.
            * @param[out] camera_params The camera parameter array. The array of Vive.Plugin.SR.CAMERA_Param
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraParams(double[] camera_params);

            /** Gets the SeeThroughData from engine.
            * @param[out] data ViveSR.SRWork.SeeThrough.SeeThroughData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThroughData(ref SeeThrough.SeeThroughData data);

            /** Get the see through parameter boolean from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThroughParam
            * @param[out] param_value The parameter output.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThrougParameterBool(int parameter_name, ref bool value);

            /** Get the see through parameter integer from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThroughParam
            * @param[out] param_value The parameter output.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThrougParameterInt(int parameter_name, ref int value);

            /** Get the see through parameter float from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThroughParam
            * @param[out] param_value The parameter output.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThrougParameterFloat(int parameter_name, ref float value);

            /** Get the see through parameter double from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThroughParam
            * @param[out] param_value The parameter output.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThrougParameterDouble(int parameter_name, ref double value);

            /**
             * Get camera control status.
             * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
             * @param[out] status The camera status pointer.
             * @return Indicate the API's error code.
             */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraStatus(int camera_tpye, ref Int32 status);

            /**
            * Get camera control default value.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] default_value The camera default value pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraDefaultValue(int camera_tpye, ref Int32 default_mode);

            /**
            * Get camera control min.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] min The camera min pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraMin(int camera_tpye, ref Int32 min);

            /**
            * Get camera control max.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] max The camera max pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraMax(int camera_tpye, ref Int32 max);

            /**
            * Get camera control step.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] step The camera step pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraStep(int camera_tpye, ref Int32 step);

            /**
            * Get camera control default mode.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] default_mode The camera default mode pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraDefaultMode(int camera_tpye, ref Int32 default_mode);

            /**
            * Get camera control value.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] value The camera value pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraValue(int camera_tpye, ref Int32 default_value);

            /**
            * Get camera control mode.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] mode The camera mode pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetCameraMode(int camera_tpye, ref Int32 mode);

            /**
            * Set camera control status.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] status The camera status pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraStatus(int camera_tpye, Int32 status);

            /**
            * Set camera control default value.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] default_value The camera default value pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraDefaultValue(int camera_tpye, Int32 default_mode);

            /**
            * Set camera control min.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] min The camera min pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraMin(int camera_tpye, Int32 min);

            /**
            * Set camera control max.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] max The camera max pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraMax(int camera_tpye, Int32 max);

            /**
            * Set camera control step.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] step The camera step pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraStep(int camera_tpye, Int32 step);

            /**
            * Set camera control default mode.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] default_mode The camera default mode pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraDefaultMode(int camera_tpye, Int32 defaultMode);

            /**
            * Set camera control value.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] value The camera value pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraValue(int camera_tpye, Int32 default_value);

            /**
            * Set camera control mode.
            * @param[in] camera_control_type Which camera control type would you want to get.The parameters reference from Vive.Plugin.SR.ViveSR_DualCameraImageCapture.CameraQuality.
            * @param[out] mode The camera mode pointer.
            * @return Indicate the API's error code.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetCameraMode(int camera_tpye, Int32 mode);

            // Native Buffer
            [DllImport("SRWork_Client_API")]
            public static extern IntPtr GetRenderEventFunc();

            [DllImport("SRWork_Client_API")]
            public static extern void SetPosesVector(System.IntPtr pPoses);

            [DllImport("SRWork_Client_API")]
            public static extern int SetSeeThroughMaxFps(int max_fps);

            [DllImport("SRWork_Client_API")]
            public static extern void CreateCopyD3D11TextureBuffer();

            [DllImport("SRWork_Client_API")]
            public static extern void ReleaseCopyD3D11TextureBuffer();

            [DllImport("SRWork_Client_API")]
            public static extern bool SetShareHandle(IntPtr TextureSharedHandleLeft, IntPtr TextureSharedHandleRight, uint D3D11Texture2DBufferIndex, bool Is4KFlag);

            [DllImport("SRWork_Client_API")]
            public static extern int GetRingBufferSize();

            [DllImport("SRWork_Client_API")]
            public static extern bool GetShaderResourceView(int D3D11Texture2DBufferIndex, bool Is4KFlag, ref IntPtr shaderResourceViewLeft, ref IntPtr shaderResourceViewRight);

            [DllImport("SRWork_Client_API")]
            public static extern int SetSkipVGAProcess(bool value);

            [DllImport("SRWork_Client_API")]
            public static extern int GetSkipVGAProcess(ref bool value);

            [DllImport("SRWork_Client_API")]
            public static extern int TurnOnUndistortDataToDepth();

            [DllImport("SRWork_Client_API")]
            public static extern int TurnOffUndistortDataToDepth();

            [DllImport("SRWork_Client_API")]
            public static extern int TurnOnDistortData();

            [DllImport("SRWork_Client_API")]
            public static extern int TurnOffDistortData();
            #endregion

            #region see_through_4k
            /** Get the camera parameters from engine.
            * @param[out] camera_params The camera parameter array. The array of Vive.Plugin.SR.CAMERA_Param
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int Get4KCameraParams(double[] camera_params);

            /** Gets the SeeThrough4KData from engine.
            * @param[out] data Vive.Plugin.SR.SeeThrough.SeeThrough4KData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThrough4KData(ref SeeThrough.SeeThrough4KData data);

            /** Get the see through 4K parameter boolean from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThrough4KParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThroug4KParameterBool(int parameter_name, ref bool value);

            /** Get the see through 4K parameter integer from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThrough4KParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThroug4KParameterInt(int parameter_name, ref int value);

            /** Get the see through 4K parameter float from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThrough4KParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThroug4KParameterFloat(int parameter_name, ref float value);

            /** Get the see through 4K parameter double from engine.
            * @param[in] parameter_name Vive.Plugin.SR.SeeThrough4KParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSeeThroug4KParameterDouble(int parameter_name, ref double value);

            /** Set the see through 4K maximum update interval of engine.
            * @param[in] max_fps The maximum fps want to set.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetSeeThrough4KMaxFps(int max_fps);

            #endregion

            #region depth
            /** Gets the DepthData from engine.
            * @param[out] DepthData Vive.Plugin.SR.Depth.DepthData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthData(ref Depth.DepthData data);

            /** Sets the depth parameter boolean of module.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthParameterBool(int parameter_name, bool value);

            /** Sets the depth parameter integer of module.
            * @param parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthParameterInt(int parameter_name, int value);

            /** Sets the depth parameter float of module.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthParameterFloat(int parameter_name, float value);

            /** Get the depth parameter boolean from engine.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthParameterBool(int parameter_name, ref bool value);

            /** Get the depth parameter integer from engine.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthParameterInt(int parameter_name, ref int value);

            /** Get the depth parameter float from engine.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthParameterFloat(int parameter_name, ref float value);

            /** Get the depth parameter double from engine.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthParameterDouble(int parameter_name, ref double value);

            /** Set the depth maximum update interval of engine.
            * @param[in] max_fps The maximum fps want to set.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMaxFps(int max_fps);

            #endregion

            #region depth_mesh
            /** Enable or disable depth mesh of module.
            * @param[in] value Is the boolean to set enable or disable depth mesh.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMeshIsEnable(bool is_mesh_enable);

            /** Sets the depth parameter boolean of module.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMeshParameterBool(int parameter_name, bool value);

            /** Sets the depth parameter integer of module.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMeshParameterInt(int parameter_name, int value);

            /** Sets the depth parameter double of module.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMeshParameterDouble(int parameter_name, double value);

            /** Get the depth parameter integer from engine.
            * @param[in] parameter_name Vive.Plugin.SR.DepthParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthMeshParameterInt(int parameter_name, ref int value);

            /** Gets the DepthMeshData from engine.
            * @param[out] data Vive.Plugin.SR.DepthMesh.DepthMeshData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetDepthMeshData(ref DepthMesh.DepthMeshData data);

            /** Set the depth mesh maximum update interval of engine.
            * @param[in] max_fps The maximum fps want to set.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetDepthMeshMaxFps(int max_fps);

            #endregion

            #region reconstruction
            /** Gets the RigidReconstructionData from engine.
            * @param[out] DepthData Vive.Plugin.SR.RigidReconstruction.RigidReconstructionData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetRigidReconstructionData(ref RigidReconstruction.RigidReconstructionData data);

            /** Sets the rigidReconstruction parameter boolean of module.
            * @param[in] parameter_name Vive.Plugin.SR.ReconstructionParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionParameterBool(int type, bool value);

            /** Sets the rigidReconstruction parameter integer of module.
            * @param[in] parameter_name Vive.Plugin.SR.ReconstructionParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionParameterInt(int type, int value);

            /** Sets the rigidReconstruction parameter float of module.
            * @param[in] parameter_name Vive.Plugin.SR.ReconstructionParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionParameterFloat(int type, float value);

            /** Sets the rigidReconstruction parameter double of module.
            * @param[in] parameter_name Vive.Plugin.SR.ReconstructionParam
            * @param[in] param_value The parameter input value.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionParameterDouble(int type, double value);

            /** Get the rigidReconstruction parameter integer from engine.
            * @param[in] parameter_name Vive.Plugin.SR.ReconstructionParam
            * @param[out] param_value The parameter output value
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetReconstructionParameterInt(int type, ref int value);

            /** Get  the scene understanding config which set maximum counts in one label object.
            * @param[out] SceneUnderstandingConfig ViveSR::SRWork::RigidReconstruction::SceneUnderstandingConfigId
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSceneUnderstandingConfig(ref SceneUnderstandingConfig value);

            /** Set the scene understanding config which set maximum counts in one label object.
            * @param[in] SceneUnderstandingConfig ViveSR::SRWork::RigidReconstruction::SceneUnderstandingConfigId
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetSceneUnderstandingConfig(SceneUnderstandingConfig value);

            /** Set the reconstruction module output path.
            * @param[in] parameter_name The folder path.
            * @param[in] size The folder path length.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionOutputFolder(System.IntPtr value, int size);

            /** Set the reconstruction output filename and export mesh.
            * @param[in] parameter_name The array of file name.
            * @param[in] size The file name length.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionOutputFileName(System.IntPtr value, int size);

            /** Set the scene understanding output filename and export scene understanding object.
            * @param[in] parameter_name The array of file name.
            * @param[in] size The file name length.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetSceneUnderstandingOutputFileName(System.IntPtr value, int size);

            /** Get the reconstruction mesh export progress.
            * @param[out] value The progress between 0 to 100.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetExportMeshProgress(ref int value);

            /** Get the scene understanding export progress.
            * @param[out] value The progress between 0 to 100.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetSceneUnderstandingProgress(ref int value);

            /** Set the reconstruction maximum update interval of engine.
            * @param[out] max_fps The maximum fps want to set.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int SetReconstructionMaxFps(int max_fps);

            /** Reset the reconstruction to initial situation.
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int ResetReconstructionModule();
            #endregion
            #region
            /** Gets the controller pose from engine.
            * @param[out] ControlerPoseData Vive.Plugin.SR.ControllPose.ControllPoseData
            * @return Indicates the resulting Vive.Plugin.SR.Error status of this method.
            */
            [DllImport("SRWork_Client_API")]
            public static extern int GetControllerPoseData(ref ControllPose.ControllPoseData data);
            #endregion
        }
    }
}
