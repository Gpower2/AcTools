using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AcMediaWrapper.Video
{
    public class AviSynthProvider
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
        
        //Structure that contains Information about the video file
        public struct AcAvsWrapperVideoFileInfo
        {
            // Video
            public Int32 width;
            public Int32 height;
            public Int32 rate_numerator;
            public Int32 rate_denominator;
            public Int32 aspect_numerator;
            public Int32 aspect_denominator;
            public Int32 has_interlaced_frames;
            public Int32 is_top_field_first;
            public Int32 number_frames;
            public Int32 pixel_type;

            // Audio
            public Int32 audio_samples_per_second;
            public Int32 sample_type;
            public Int32 number_channels;
            public Int32 number_audio_frames;

            public Int64 number_audio_samples;
        };

        public struct AcAvsWrapperVideoPlane
        {
            public Int32 width;
            public Int32 height;
            public Int32 pitch;
            public Byte[] data;
        };

        public struct FRAME
        {
            public Int32[] data;
        };

        public struct AcAvsWrapperVideoFrame
        {
            public AcAvsWrapperVideoPlane[] plane;
        };

        public struct AcAvsWrapperAudioPosition
        {
            public Int64 start;
            public Int64 count;
        };

        public struct SafeStruct
        {
            public String error_msg;
            //IScriptEnvironment* environment;
            public dynamic environment;
            //AVSValue* result;
            public dynamic result;
            //PClip clp;
            public dynamic clp;
            //HMODULE dll;
            public dynamic dll;
        };

        //int __stdcall dimzon_avs_getintvariable(SafeStruct* pstr, const char* name, int* result)
        public Int32 dimzon_avs_getintvariable(SafeStruct pstr, String name, out Int32 result)
        {
            try
            {
                pstr.error_msg = String.Empty;
                //pstr->error_msg[0] = 0;
                try
                {
                    //AVSValue var = pstr->environment->GetVar(name);
                    dynamic avsValueVar = pstr.environment.GetVar(name);
                    if (avsValueVar.Defined())
                    {
                        if (!avsValueVar.IsInt())
                        {
                            //strncpy_s(pstr->error_msg, ERRMSG_LEN, "Variable is not Integer!", _TRUNCATE);
                            pstr.error_msg = "Variable is not Integer!";
                            result = Int32.MinValue;
                            return -2;
                        }
                        //*result = var.AsInt();
                        result = avsValueVar.AsInt();
                        return 0;
                    }
                    else
                    {
                        result = Int32.MinValue;
                        return 999; // Signal "Not defined"
                    }
                }
                //catch(AvisynthError err)
                catch (Exception ex)
                {
                    //strncpy_s(pstr->error_msg, ERRMSG_LEN, err.msg, _TRUNCATE);
                    pstr.error_msg = ex.Message;
                    result = Int32.MinValue;
                    return -1;
                }
            }
            //catch(IScriptEnvironment::NotFound)
            catch (Exception)
            {
                result = Int32.MinValue;
                return 666; // Signal "Not Found"
            }
        }

        //int __stdcall dimzon_avs_getaframe(SafeStruct* pstr, void *buf, INT64 start, INT64 count)
        public Int32 dimzon_avs_getaframe(SafeStruct pstr, IntPtr buf, Int64 start, Int64 count)
        {
            try
            {
                //pstr->clp->GetAudio(buf, start, count, pstr->environment);
                pstr.clp.GetAudio(buf, start, count, pstr.environment);
                //pstr->error_msg[0] = 0;
                pstr.error_msg = String.Empty;
                return 0;
            }
            //catch(AvisynthError err)
            catch (Exception ex)
            {
                //strncpy_s(pstr->error_msg, ERRMSG_LEN, err.msg, _TRUNCATE);
                pstr.error_msg = ex.Message;
                return -1;
            }
        }

        //int __stdcall dimzon_avs_getvframe(SafeStruct* pstr, void *buf, int stride, int frame_number )
        public Int32 dimzon_avs_getvframe(SafeStruct pstr, IntPtr buf, Int32 stride, Int32 frame_number)
        {
            try
            {
                //Get video frame pointer
                //PVideoFrame frame_pointer = pstr->clp->GetFrame(frame_number, pstr->environment);
                dynamic frame_pointer = pstr.clp.GetFrame(frame_number, pstr.environment);
                if ((buf != IntPtr.Zero) && (stride != 0))
                {
                    //pstr->environment->BitBlt((BYTE*)buf, stride, frame_pointer->GetReadPtr(), frame_pointer->GetPitch(),
                    //    frame_pointer->GetRowSize(), frame_pointer->GetHeight());
                    pstr.environment.BitBlt(buf, stride, frame_pointer.GetReadPtr(), frame_pointer.GetPitch(),
                        frame_pointer.GetRowSize(), frame_pointer.GetHeight());
                }
                //pstr->error_msg[0] = 0;
                pstr.error_msg = String.Empty;
            }
            //catch(AvisynthError err)
            catch (Exception ex)
            {
                //strncpy_s(pstr->error_msg, ERRMSG_LEN, err.msg, _TRUNCATE);
                pstr.error_msg = ex.Message;
                return -1;
            }
            return 0;
        }

        //int __stdcall dimzon_avs_getlasterror(SafeStruct* pstr, char *str, int len)
        public Int32 dimzon_avs_getlasterror(SafeStruct pstr, String str, Int32 len)
        {
            pstr.error_msg = str;
            //strncpy_s(str, len, pstr->error_msg, len - 1);
            return str.Length;
            //return (int)strlen(str);
        }

        //int __stdcall dimzon_avs_destroy(SafeStruct** ppstr)
        public Int32 dimzon_avs_destroy(SafeStruct ppstr)
        {
            //if(!ppstr)
            //if (ppstr == null)
            //{
            //    return 0;
            //}

            //SafeStruct* pstr = *ppstr;
            SafeStruct pstr = ppstr;
            //if(!pstr)
            //    if(pstr ==null)
            //{
            //    return 0;
            //}

            //if(pstr->clp)
            if (pstr.clp != null)
            {
                //pstr->clp = NULL;
                pstr.clp = null;
            }

            //if(pstr->result)
            if (pstr.result != null)
            {
                //delete pstr->result;
                //pstr->result = NULL;
                pstr.result = null;
            }

            //if(pstr->environment)
            if (pstr.environment != null)
            {
                //delete pstr->environment;
                //pstr->environment = NULL;
                pstr.environment = null;
            }

            //if(pstr->dll)
            if (pstr.dll != null)
            {
                //FreeLibrary(pstr->dll);
                pstr.dll = null;
            }

            //free(pstr);
            //*ppstr = NULL;
            //pstr = null;
            //ppstr = null;
            return 0;
        }

// same as old dimzon_avs_init() but without the fix audio output at 16 bit. Requires AviSynth >= v2.5.7
//int __stdcall dimzon_avs_init_2(SafeStruct** ppstr, char *func, char *arg, AcAvsWrapperVideoFileInfo *vi, int* originalPixelType, int* originalSampleType, char *cs)
        public Int32 dimzon_avs_init_2(SafeStruct ppstr, String func, String arg, AcAvsWrapperVideoFileInfo vi,Int32 originalPixelType, Int32 originalSampleType, String cs)
{
	//SafeStruct* pstr = ((SafeStruct*)malloc(sizeof(SafeStruct)));
            SafeStruct pstr = new SafeStruct();

	//*ppstr = pstr;
            ppstr = pstr;
	//memset(pstr, 0, sizeof(SafeStruct));

	//pstr->dll = LoadLibrary("avisynth.dll");
            pstr.dll = LoadLibrary("avisynth.dll");
	//if(!pstr->dll)
            if(!pstr.dll)
	{
		//strncpy_s(pstr->error_msg, ERRMSG_LEN, "Cannot load avisynth.dll!", _TRUNCATE);
                pstr.error_msg = "Cannot load avisynth.dll!";
		return 1;
	}

	//IScriptEnvironment* (* CreateScriptEnvironment)(int version) = (IScriptEnvironment*(*)(int)) GetProcAddress(pstr->dll, "CreateScriptEnvironment");
            dynamic CreateScriptEnvironment = GetProcAddress(pstr.dll, "CreateScriptEnvironment");

	if(!CreateScriptEnvironment)
	{
		//strncpy_s(pstr->error_msg, ERRMSG_LEN, "Cannot load CreateScriptEnvironment!", _TRUNCATE);
        pstr.error_msg = "Cannot load CreateScriptEnvironment!";
		return 2;
	}

	//pstr->environment = CreateScriptEnvironment(AVISYNTH_INTERFACE_VERSION);
            pstr.environment = CreateScriptEnvironment(3);

	//if (pstr->environment == NULL)
            if (pstr.environment == null)
	{
		//strncpy_s(pstr->error_msg, ERRMSG_LEN, "Required Avisynth 2.5!", _TRUNCATE);
                pstr.error_msg = "Required Avisynth 2.5+!";
		return 3;
	}

	try
	{
		AVSValue arg(arg);
        dynamic res = pstr.environment.Invoke(func, AVSValue(arg, 1));
		//AVSValue res = pstr->environment->Invoke(func, AVSValue(&arg, 1));
		if (!res.IsClip()) {
			strncpy_s(pstr->error_msg, ERRMSG_LEN, "The script's return was not a video clip!", _TRUNCATE);
			return 4;
		}
		pstr->clp = res.AsClip();
		VideoInfo inf = pstr->clp->GetVideoInfo();

		if (inf.HasVideo())
		{
			*originalPixelType = inf.pixel_type;

			if ( strcmp("RGB24", cs) == 0 && (!inf.IsRGB24()) )
			{
				res = pstr->environment->Invoke("ConvertToRGB24", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				//free(&inf);
				inf = pstr->clp->GetVideoInfo();

				if(!inf.IsRGB24())
				{
					//Add by Gpower2
					//Shouldn't we clear memory here?
					free(&inf);
					dimzon_avs_destroy(ppstr);
					strncpy_s(pstr->error_msg, ERRMSG_LEN,"Cannot convert video to RGB24",_TRUNCATE);
					return	5;
				}
			}

			if ( strcmp("RGB32", cs) == 0 && (!inf.IsRGB32()) )
			{
				res = pstr->environment->Invoke("ConvertToRGB32", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				//free(&inf);
				inf = pstr->clp->GetVideoInfo();

				if(!inf.IsRGB32()) {
					//Add by Gpower2
					//Shouldn't we clear memory here?
					free(&inf);
					dimzon_avs_destroy(ppstr);
					strncpy_s(pstr->error_msg, ERRMSG_LEN, "Cannot convert video to RGB32!", _TRUNCATE);
					return 5;
				}
			}

			if ( strcmp("YUY2", cs) == 0 && (!inf.IsYUY2()) )
			{
				res = pstr->environment->Invoke("ConvertToYUY2", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				//free(&inf);
				inf = pstr->clp->GetVideoInfo();

				if(!inf.IsYUY2())
				{
					//Add by Gpower2
					//Shouldn't we clear memory here?
					free(&inf);
					dimzon_avs_destroy(ppstr);
					strncpy_s(pstr->error_msg, ERRMSG_LEN, "Cannot convert video to YUY2!", _TRUNCATE);
					return 5;
				}
			}

			if ( strcmp("YV12", cs) == 0 && (!inf.IsYV12()) )
			{
				res = pstr->environment->Invoke("ConvertToYV12", AVSValue(&res, 1));
				pstr->clp = res.AsClip();
				//free(&inf);
				inf = pstr->clp->GetVideoInfo();

				if(!inf.IsYV12())
				{
					//Add by Gpower2
					//Shouldn't we clear memory here?
					free(&inf);
					dimzon_avs_destroy(ppstr);		
					strncpy_s(pstr->error_msg, ERRMSG_LEN, "Cannot convert video to YV12!", _TRUNCATE);
					return 5;
				}
			}
		}

		if (vi != NULL) 
		{
			vi->width = inf.width;
			vi->height = inf.height;
			vi->rate_numerator = inf.fps_numerator;
			vi->rate_denominator = inf.fps_denominator;
			vi->aspect_numerator = 0;
			vi->aspect_denominator = 1;
			vi->has_interlaced_frames = 0;
			vi->is_top_field_first  = 0;
			vi->number_frames = inf.num_frames;
			vi->pixel_type = inf.pixel_type;

			vi->audio_samples_per_second = inf.audio_samples_per_second;
			vi->number_audio_samples = inf.num_audio_samples;
			vi->sample_type = inf.sample_type;
			vi->number_channels = inf.nchannels;
		}

		pstr->result = new AVSValue(res);

		pstr->error_msg[0] = 0;
		return 0;
	}
	//catch(AvisynthError err)
            catch(Exception ex)
	{
		//strncpy_s(pstr->error_msg, ERRMSG_LEN, err.msg, _TRUNCATE);
                pstr.error_msg = ex.Message;
		return 999;
	}
}


    }
}

