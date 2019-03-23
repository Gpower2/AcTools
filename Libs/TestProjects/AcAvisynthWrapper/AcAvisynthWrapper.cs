using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AcAvisynthWrapper
{
    public class AcAvisynthWrapper
    {
        UInt16 MAX_CLIPS = 1024;
        UInt16 ERRMSG_LEN = 1024;

        #region "struct tagSafeStruct"

        //typedef struct tagSafeStruct
//{
//    char err[ERRMSG_LEN];
//    IScriptEnvironment* env;
//    AVSValue* res;
//    PClip clp;
//    HMODULE dll;
//}SafeStruct;

        private struct tagSafeStruct
        {
            String err;
            IntPtr env;
            IntPtr res;
            IntPtr clp;
            IntPtr dll;
        }

        #endregion

        #region "struct AVSDLLVideoInfo"

        //        typedef struct AVSDLLVideoInfo {
//    // Video
//    int width;
//    int height;
//    int raten;
//    int rated;
//    int aspectn;
//    int aspectd;
//    int interlaced_frame;
//    int top_field_first;
//    int num_frames;
//    int pixel_type;

//    // Audio
//    int audio_samples_per_second;
//    int sample_type;
//    int nchannels;
//    int num_audio_frames;
//    int64_t num_audio_samples;
//} AVSDLLVideoInfo;

        private struct AVSDLLVideoInfo
        {
            // Video
            Int32 width;
            Int32 height;
            Int32 raten;
            Int32 rated;
            Int32 aspectn;
            Int32 aspectd;
            Int32 interlaced_frame;
            Int32 top_field_first;
            Int32 num_frames;
            Int32 pixel_type;

            // Audio
            Int32 audio_samples_per_second;
            Int32 sample_type;
            Int32 nchannels;
            Int32 num_audio_frames;
            Int64 num_audio_samples;
        }

        #endregion

        #region "struct AVSDLLVideoPlane"

        //        typedef struct AVSDLLVideoPlane {
//    int width;
//    int height;
//    int pitch;
//    BYTE *data;
//} AVSDLLVideoPlane;

        private struct AVSDLLVideoPlane
        {
            int width;
            int height;
            int pitch;
            Byte[] data;
        }

        #endregion

        #region "struct AVSDLLVideoFrame"

        //typedef struct AVSDLLVideoFrame {
        //    AVSDLLVideoPlane plane[3];
        //} AVSDLLVideoFrame;

        private struct AVSDLLVideoFrame
        {
            AVSDLLVideoPlane[] plane;
        }

        #endregion

        #region "struct FRAME"

        //typedef struct FRAME {
        //    int *data;
        //} FRAME;

        private struct FRAME
        {
            Int32[] data;
        }

        #endregion

        #region "struct AVSDLLAudioPos"

//typedef struct AVSDLLAudioPos {
//    int64_t start;
//    int64_t count;
//} AVSDLLAudioPos;

        private struct AVSDLLAudioPos
        {
            Int64 start;
            Int64 count;
        }

        #endregion


        #region "extern C functions"

        //        extern "C" {
//__declspec(dllexport) int __stdcall dimzon_avs_init(SafeStruct** ppstr, char *func ,char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs);
//__declspec(dllexport) int __stdcall dimzon_avs_init_2(SafeStruct** ppstr, char *func ,char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs);
//__declspec(dllexport) int __stdcall dimzon_avs_destroy(SafeStruct** ppstr);
//__declspec(dllexport) int __stdcall dimzon_avs_getlasterror(SafeStruct* pstr, char *str,int len);
//__declspec(dllexport) int __stdcall dimzon_avs_getvframe(SafeStruct* pstr, void *buf, int stride, int frm );
//__declspec(dllexport) int __stdcall dimzon_avs_getaframe(SafeStruct* pstr, void *buf, __int64 start, __int64 count);
//__declspec(dllexport) int __stdcall dimzon_avs_getintvariable(SafeStruct* pstr, const char* name , int* result);
        //}
        #endregion

        #region "kernel32.dll Imports"

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(String dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, String procedureName);
        
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeLibrary(IntPtr hModule);

        #endregion

        //SafeStruct** ppstr, char *func ,char *arg, AVSDLLVideoInfo *vi, int* originalPixelType, int* originalSampleType, char *cs
        public int AcAvsInit()
        {
    //SafeStruct* pstr = ((SafeStruct*)malloc(sizeof(SafeStruct)));
    //*ppstr = pstr;
    //memset(pstr,0,sizeof(SafeStruct));

    //pstr->dll = LoadLibrary("avisynth.dll");
    //if(!pstr->dll)
    //{
    //    strncpy_s(pstr->err, ERRMSG_LEN,"Cannot load avisynth.dll",_TRUNCATE);
    //    return 1;
    //}

    //IScriptEnvironment* (* CreateScriptEnvironment)(int version) = (IScriptEnvironment*(*)(int)) GetProcAddress(pstr->dll, "CreateScriptEnvironment");
    //if(!CreateScriptEnvironment)
    //{
    //    strncpy_s(pstr->err, ERRMSG_LEN,"Cannot load CreateScriptEnvironment",_TRUNCATE);
    //    return 2;
    //}

    //pstr->env = CreateScriptEnvironment(AVISYNTH_INTERFACE_VERSION);

    //if (pstr->env == NULL)
    //{
    //    strncpy_s(pstr->err, ERRMSG_LEN,"Required Avisynth 2.5",_TRUNCATE);
    //    return 3;
    //}

    //try
    //{
    //    AVSValue arg(arg);
    //    AVSValue res = pstr->env->Invoke(func, AVSValue(&arg, 1));
    //    if (!res.IsClip()) {
    //        strncpy_s(pstr->err, ERRMSG_LEN, "The script's return was not a video clip.",_TRUNCATE);
    //        return 4;
    //    }
    //    pstr->clp = res.AsClip();
    //    VideoInfo inf  = pstr->clp->GetVideoInfo();
    //    VideoInfo infh = pstr->clp->GetVideoInfo();

    //    if (inf.HasVideo())
    //    {
    //        *originalPixelType =  inf.pixel_type;

    //        if ( strcmp("RGB24", cs)==0 && (!inf.IsRGB24()) )
    //        {
    //            res = pstr->env->Invoke("ConvertToRGB24", AVSValue(&res, 1));
    //            pstr->clp = res.AsClip();
    //            infh = pstr->clp->GetVideoInfo();

    //            if(!infh.IsRGB24())
    //            {
    //                strncpy_s(pstr->err, ERRMSG_LEN,"Cannot convert video to RGB24",_TRUNCATE);
    //                return	5;
    //            }
    //        }

    //        if ( strcmp("RGB32", cs)==0 && (!inf.IsRGB32()) )
    //        {
    //            res = pstr->env->Invoke("ConvertToRGB32", AVSValue(&res, 1));
    //            pstr->clp = res.AsClip();
    //            infh = pstr->clp->GetVideoInfo();

    //            if(!infh.IsRGB32()) {
    //                strncpy_s(pstr->err, ERRMSG_LEN,"Cannot convert video to RGB32",_TRUNCATE);
    //                return 5;
    //            }
    //        }

    //        if ( strcmp("YUY2", cs)==0 && (!inf.IsYUY2()) )
    //        {
    //            res = pstr->env->Invoke("ConvertToYUY2", AVSValue(&res, 1));
    //            pstr->clp = res.AsClip();
    //            infh = pstr->clp->GetVideoInfo();
    //            if(!infh.IsYUY2())
    //            {
    //                strncpy_s(pstr->err, ERRMSG_LEN,"Cannot convert video to YUY2",_TRUNCATE);
    //                return 5;
    //            }
    //        }

    //        if ( strcmp("YV12", cs)==0 && (!inf.IsYV12()) )
    //        {
    //            res = pstr->env->Invoke("ConvertToYV12", AVSValue(&res, 1));
    //            pstr->clp = res.AsClip();
    //            infh = pstr->clp->GetVideoInfo();
    //            if(!infh.IsYV12())
    //            {
    //                strncpy_s(pstr->err, ERRMSG_LEN,"Cannot convert video to YV12",_TRUNCATE);
    //                return 5;
    //            }
    //        }

    //    }

    //    if (inf.HasAudio())
    //    {
    //        *originalSampleType = inf.SampleType();
    //        if( *originalSampleType != SAMPLE_INT16)
    //        {
    //            res = pstr->env->Invoke("ConvertAudioTo16bit", res);
    //            pstr->clp = res.AsClip();
    //            infh = pstr->clp->GetVideoInfo();
    //            if(infh.SampleType() != SAMPLE_INT16)
    //            {
    //                strncpy_s(pstr->err, ERRMSG_LEN,"Cannot convert audio to 16bit",_TRUNCATE);
    //                return 6;
    //            }
    //        }
    //    }

    //    inf = pstr->clp->GetVideoInfo();
    //    if (vi != NULL) {
    //        vi->width   = inf.width;
    //        vi->height  = inf.height;
    //        vi->raten   = inf.fps_numerator;
    //        vi->rated   = inf.fps_denominator;
    //        vi->aspectn = 0;
    //        vi->aspectd = 1;
    //        vi->interlaced_frame = 0;
    //        vi->top_field_first  = 0;
    //        vi->num_frames = inf.num_frames;
    //        vi->pixel_type = inf.pixel_type;

    //        vi->audio_samples_per_second = inf.audio_samples_per_second;
    //        vi->num_audio_samples        = inf.num_audio_samples;
    //        vi->sample_type              = inf.sample_type;
    //        vi->nchannels                = inf.nchannels;
    //    }

    //    pstr->res = new AVSValue(res);

    //    pstr->err[0] = 0;
    //    return 0;
    //}
    //catch(AvisynthError err)
    //{
    //    strncpy_s(pstr->err, ERRMSG_LEN,err.msg,_TRUNCATE);
    //    return 999;
    //}
            return -1;
        }
    }


}
