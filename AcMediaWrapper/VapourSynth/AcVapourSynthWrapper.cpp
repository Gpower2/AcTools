#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <io.h>

#include "VapourSynth.h"
#include "VSHelper.h"
#include "VSScript.h"

#ifdef __cplusplus
#    define AC_EXTERN_C extern "C"
#    if __cplusplus >= 201103L || (defined(_MSC_VER) && _MSC_VER >= 1900)
#        define AC_NOEXCEPT noexcept
#    else
#        define AC_NOEXCEPT
#    endif
#else
#    define AC_EXTERN_C
#    define AC_NOEXCEPT
#endif

#if defined(_WIN32) && !defined(_WIN64)
#    define AC_CC __stdcall
#else
#    define AC_CC
#endif

#if defined(_WIN32)
#    define AC_EXTERNAL_API(ret) AC_EXTERN_C __declspec(dllexport) ret AC_CC
#elif defined(__GNUC__) && __GNUC__ >= 4
#    define AC_EXTERNAL_API(ret) AC_EXTERN_C __attribute__((visibility("default"))) ret AC_CC
#else
#    define AC_EXTERNAL_API(ret) AC_EXTERN_C ret AC_CC
#endif

#if defined(_WIN32)
#    define AC_API(ret) AC_EXTERN_C __declspec(dllimport) ret AC_CC
#else
#    define AC_API(ret) AC_EXTERNAL_API(ret)
#endif

//-------------------------------------------------------------------------------------------------
// VSScript Declarations
//-------------------------------------------------------------------------------------------------

/* Get the api version */
AC_API(int) AC_vsscript_getApiVersion(void);

/* Initialize the available scripting runtimes, returns zero on failure */
AC_API(int) AC_vsscript_init(void);

/* Free all scripting runtimes */
AC_API(int) AC_vsscript_finalize(void);

/*
* Pass a pointer to a null handle to create a new one
* The values returned by the query functions are only valid during the lifetime of the VSScript
* scriptFilename is if the error message should reference a certain file, NULL allowed in vsscript_evaluateScript()
* core is to pass in an already created instance so that mixed environments can be used,
* NULL creates a new core that can be fetched with vsscript_getCore() later OR implicitly uses the one associated with an already existing handle when passed
* If efSetWorkingDir is passed to flags the current working directory will be changed to the path of the script
* note that if scriptFilename is NULL in vsscript_evaluateScript() then __file__ won't be set and the working directory won't be changed
* Set efSetWorkingDir to get the default and recommended behavior
*/
AC_API(int) AC_vsscript_evaluateScript(VSScript** handle, const char* script, const char* scriptFilename, int flags);

/* Convenience version of the above function that loads the script from a file */
AC_API(int) AC_vsscript_evaluateFile(VSScript** handle, const char* scriptFilename, int flags);

/* Create an empty environment for use in later invocations, mostly useful to set script variables before execution */
AC_API(int) AC_vsscript_createScript(VSScript** handle);

AC_API(void) AC_vsscript_freeScript(VSScript* handle);

AC_API(const char*) AC_vsscript_getError(VSScript* handle);

/* The node returned must be freed using freeNode() before calling vsscript_freeScript() */
AC_API(VSNodeRef*) AC_vsscript_getOutput(VSScript* handle, int index);

/* Both nodes returned must be freed using freeNode() before calling vsscript_freeScript(), the alpha node pointer will only be set if an alpha clip has been set in the script */
AC_API(VSNodeRef*) AC_vsscript_getOutput2(VSScript* handle, int index, VSNodeRef** alpha); /* api 3.1 */

/* Unset an output index */
AC_API(int) AC_vsscript_clearOutput(VSScript* handle, int index);

/* The core is valid as long as the environment exists */
AC_API(VSCore*) AC_vsscript_getCore(VSScript* handle);

/* Convenience function for retrieving a vsapi pointer */
AC_API(const VSAPI*) AC_vsscript_getVSApi(void); /* deprecated as of api 3.2 since it's impossible to tell the api version supported */

AC_API(const VSAPI*) AC_vsscript_getVSApi2(int version); /* api 3.2, generally you should pass VAPOURSYNTH_API_VERSION */

/* Variables names that are not set or not of a convertible type will return an error */
AC_API(int) AC_vsscript_getVariable(VSScript* handle, const char* name, VSMap* dst);

AC_API(int) AC_vsscript_setVariable(VSScript* handle, const VSMap* vars);

AC_API(int) AC_vsscript_clearVariable(VSScript* handle, const char* name);

/* Tries to clear everything set in an environment, normally it is better to simply free an environment completely and create a new one */
AC_API(void) AC_vsscript_clearEnvironment(VSScript* handle);

//-------------------------------------------------------------------------------------------------
// VSScript Implementations
//-------------------------------------------------------------------------------------------------

int AC_CC AC_vsscript_getApiVersion(void) 
{
	return vsscript_getApiVersion();
}

int AC_CC AC_vsscript_init(void)
{
	return vsscript_init();
}

int AC_CC AC_vsscript_finalize(void) 
{
	return vsscript_finalize();
}

int AC_CC AC_vsscript_evaluateScript(VSScript** handle, const char* script, const char* scriptFilename, int flags)
{
	return vsscript_evaluateScript(handle, script, scriptFilename, flags);
}

int AC_CC AC_vsscript_evaluateFile(VSScript** handle, const char* scriptFilename, int flags) 
{
	return vsscript_evaluateFile(handle, scriptFilename, flags);
}

int AC_CC AC_vsscript_createScript(VSScript** handle)
{
	return vsscript_createScript(handle);
}

void AC_CC AC_vsscript_freeScript(VSScript* handle) 
{
	return vsscript_freeScript(handle);
}

const char* AC_CC AC_vsscript_getError(VSScript* handle) 
{
	return vsscript_getError(handle);
}

VSNodeRef* AC_CC AC_vsscript_getOutput(VSScript* handle, int index)
{
	return vsscript_getOutput(handle, index);
}

VSNodeRef* AC_CC AC_vsscript_getOutput2(VSScript* handle, int index, VSNodeRef** alpha)
{
	return vsscript_getOutput2(handle, index, alpha);
}

int AC_CC AC_vsscript_clearOutput(VSScript* handle, int index)
{
	return vsscript_clearOutput(handle, index);
}

VSCore* AC_CC AC_vsscript_getCore(VSScript* handle)
{
	return vsscript_getCore(handle);
}

const VSAPI* AC_CC AC_vsscript_getVSApi(void)
{
	return vsscript_getVSApi();
}

const VSAPI* AC_CC AC_vsscript_getVSApi2(int version)
{
	return vsscript_getVSApi2(version);
}

int AC_CC AC_vsscript_getVariable(VSScript* handle, const char* name, VSMap* dst)
{
	return vsscript_getVariable(handle, name, dst);
}

int AC_CC AC_vsscript_setVariable(VSScript* handle, const VSMap* vars)
{
	return vsscript_setVariable(handle, vars);
}

int AC_CC AC_vsscript_clearVariable(VSScript* handle, const char* name)
{
	return vsscript_clearVariable(handle, name);
}

/* Tries to clear everything set in an environment, normally it is better to simply free an environment completely and create a new one */
void AC_CC AC_vsscript_clearEnvironment(VSScript* handle)
{
	return vsscript_clearEnvironment(handle);
}

//-------------------------------------------------------------------------------------------------
// VapourSynth Declarations
//-------------------------------------------------------------------------------------------------

AC_API(const VSAPI*) AC_vsapi_getVapourSynthAPI(int version) AC_NOEXCEPT;

// VSAPI methods
//-------------------------------------------------------------------------------------------------
AC_API(VSCore*) AC_vsapi_createCore(const VSAPI* vsapi, int threads) AC_NOEXCEPT;
AC_API(void) AC_vsapi_freeCore(const VSAPI* vsapi, VSCore* core) AC_NOEXCEPT;
/* deprecated as of api 3.6, use getCoreInfo2 instead */
AC_API(const VSCoreInfo*) AC_vsapi_getCoreInfo(const VSAPI* vsapi, VSCore* core) AC_NOEXCEPT;

AC_API(const VSFrameRef*) AC_vsapi_cloneFrameRef(const VSAPI* vsapi, const VSFrameRef* f) AC_NOEXCEPT;
AC_API(VSNodeRef*) AC_vsapi_cloneNodeRef(const VSAPI* vsapi, VSNodeRef* node) AC_NOEXCEPT;
AC_API(VSFuncRef*) AC_vsapi_cloneFuncRef(const VSAPI* vsapi, VSFuncRef* f) AC_NOEXCEPT;

AC_API(void) AC_vsapi_freeFrame(const VSAPI* vsapi, const VSFrameRef* f) AC_NOEXCEPT;
AC_API(void) AC_vsapi_freeNode(const VSAPI* vsapi, VSNodeRef* node) AC_NOEXCEPT;
AC_API(void) AC_vsapi_freeFunc(const VSAPI* vsapi, VSFuncRef* f) AC_NOEXCEPT;

AC_API(const VSFormat*) AC_vsapi_getFormatPreset(const VSAPI* vsapi, int id, VSCore* core) AC_NOEXCEPT;

AC_API(int) AC_vsapi_getStride(const VSAPI* vsapi, const VSFrameRef* f, int plane) AC_NOEXCEPT;
AC_API(const uint8_t*) AC_vsapi_getReadPtr(const VSAPI* vsapi, const VSFrameRef* f, int plane) AC_NOEXCEPT;

AC_API(const VSVideoInfo*) AC_vsapi_getVideoInfo(const VSAPI* vsapi, VSNodeRef* node) AC_NOEXCEPT;
AC_API(const VSFormat*) AC_vsapi_getFrameFormat(const VSAPI* vsapi, const VSFrameRef* f) AC_NOEXCEPT;
AC_API(int) AC_vsapi_getFrameWidth(const VSAPI* vsapi, const VSFrameRef* f, int plane) AC_NOEXCEPT;
AC_API(int) AC_vsapi_getFrameHeight(const VSAPI* vsapi, const VSFrameRef* f, int plane) AC_NOEXCEPT;
AC_API(const VSMap*) AC_vsapi_getFramePropsRO(const VSAPI* vsapi, const VSFrameRef* f) AC_NOEXCEPT;
AC_API(VSMap*) AC_vsapi_getFramePropsRW(const VSAPI* vsapi, VSFrameRef* f) AC_NOEXCEPT;

AC_API(int) AC_vsapi_propNumKeys(const VSAPI* vsapi, const VSMap* map) AC_NOEXCEPT;
AC_API(const char*) AC_vsapi_propGetKey(const VSAPI* vsapi, const VSMap* map, int index) AC_NOEXCEPT;
AC_API(int) AC_vsapi_propNumElements(const VSAPI* vsapi, const VSMap* map, const char* key) AC_NOEXCEPT;
AC_API(char) AC_vsapi_propGetType(const VSAPI* vsapi, const VSMap* map, const char* key) AC_NOEXCEPT;

AC_API(int64_t) AC_vsapi_propGetInt(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(double) AC_vsapi_propGetFloat(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(const char*) AC_vsapi_propGetData(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(int) AC_vsapi_propGetDataSize(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(VSNodeRef*) AC_vsapi_propGetNode(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(const VSFrameRef*) AC_vsapi_propGetFrame(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;
AC_API(VSFuncRef*) AC_vsapi_propGetFunc(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error) AC_NOEXCEPT;

/* api 3.1 */
AC_API(const int64_t*) AC_vsapi_propGetIntArray(const VSAPI* vsapi, const VSMap* map, const char* key, int* error) AC_NOEXCEPT;
/* api 3.1 */
AC_API(const double*) AC_vsapi_propGetFloatArray(const VSAPI* vsapi, const VSMap* map, const char* key, int* error) AC_NOEXCEPT;

/* api 3.6 */
AC_API(void) AC_vsapi_getCoreInfo2(const VSAPI* vsapi, VSCore* core, VSCoreInfo* info) AC_NOEXCEPT;


//-------------------------------------------------------------------------------------------------
// VapourSynth Implementations
//-------------------------------------------------------------------------------------------------

const VSAPI* AC_CC AC_vsapi_getVapourSynthAPI(int version)
{
	return getVapourSynthAPI(version);
}


VSCore* AC_CC AC_vsapi_createCore(const VSAPI* vsapi, int threads)
{
	return vsapi->createCore(threads);
}

void AC_CC AC_vsapi_freeCore(const VSAPI* vsapi, VSCore* core)
{
	return vsapi->freeCore(core);
}

const VSCoreInfo* AC_CC AC_vsapi_getCoreInfo(const VSAPI* vsapi, VSCore* core)
{
	return vsapi->getCoreInfo(core);
}


const VSFrameRef* AC_CC AC_vsapi_cloneFrameRef(const VSAPI* vsapi, const VSFrameRef* f)
{
	return vsapi->cloneFrameRef(f);
}

VSNodeRef* AC_CC AC_vsapi_cloneNodeRef(const VSAPI* vsapi, VSNodeRef* node)
{
	return vsapi->cloneNodeRef(node);
}

VSFuncRef* AC_CC AC_vsapi_cloneFuncRef(const VSAPI* vsapi, VSFuncRef* f)
{
	return vsapi->cloneFuncRef(f);
}


void AC_CC AC_vsapi_freeFrame(const VSAPI* vsapi, const VSFrameRef* f)
{
	vsapi->freeFrame(f);
}

void AC_CC AC_vsapi_freeNode(const VSAPI* vsapi, VSNodeRef* node)
{
	vsapi->freeNode(node);
}

void AC_CC AC_vsapi_freeFunc(const VSAPI* vsapi, VSFuncRef* f)
{
	vsapi->freeFunc(f);
}


const VSFormat* AC_CC AC_vsapi_getFormatPreset(const VSAPI* vsapi, int id, VSCore* core)
{
	return vsapi->getFormatPreset(id, core);
}

int AC_CC AC_vsapi_getStride(const VSAPI* vsapi, const VSFrameRef* f, int plane)
{
	return vsapi->getStride(f, plane);
}

const uint8_t* AC_CC AC_vsapi_getReadPtr(const VSAPI* vsapi, const VSFrameRef* f, int plane)
{
	return vsapi->getReadPtr(f, plane);
}


const VSVideoInfo* AC_CC AC_vsapi_getVideoInfo(const VSAPI* vsapi, VSNodeRef* node)
{
	return vsapi->getVideoInfo(node);
}

const VSFormat* AC_CC AC_vsapi_getFrameFormat(const VSAPI* vsapi, const VSFrameRef* f)
{
	return vsapi->getFrameFormat(f);
}

int AC_CC AC_vsapi_getFrameWidth(const VSAPI* vsapi, const VSFrameRef* f, int plane)
{
	return vsapi->getFrameWidth(f, plane);
}

int AC_CC AC_vsapi_getFrameHeight(const VSAPI* vsapi, const VSFrameRef* f, int plane)
{
	return vsapi->getFrameHeight(f, plane);
}

const VSMap* AC_CC AC_vsapi_getFramePropsRO(const VSAPI* vsapi, const VSFrameRef* f)
{
	return vsapi->getFramePropsRO(f);
}

VSMap* AC_CC AC_vsapi_getFramePropsRW(const VSAPI* vsapi, VSFrameRef* f)
{
	return vsapi->getFramePropsRW(f);
}


int AC_CC AC_vsapi_propNumKeys(const VSAPI* vsapi, const VSMap* map)
{
	return vsapi->propNumKeys(map);
}

const char* AC_CC AC_vsapi_propGetKey(const VSAPI* vsapi, const VSMap* map, int index)
{
	return vsapi->propGetKey(map, index);
}

int AC_CC AC_vsapi_propNumElements(const VSAPI* vsapi, const VSMap* map, const char* key)
{
	return vsapi->propNumElements(map, key);
}

char AC_CC AC_vsapi_propGetType(const VSAPI* vsapi, const VSMap* map, const char* key)
{
	return vsapi->propGetType(map, key);
}


int64_t AC_CC AC_vsapi_propGetInt(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetInt(map, key, index, error);
}

double AC_CC AC_vsapi_propGetFloat(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetFloat(map, key, index, error);
}

const char* AC_CC AC_vsapi_propGetData(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetData(map, key, index, error);
}

int AC_CC AC_vsapi_propGetDataSize(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetDataSize(map, key, index, error);
}

VSNodeRef* AC_CC AC_vsapi_propGetNode(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetNode(map, key, index, error);
}

const VSFrameRef* AC_CC AC_vsapi_propGetFrame(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetFrame(map, key, index, error);
}

VSFuncRef* AC_CC AC_vsapi_propGetFunc(const VSAPI* vsapi, const VSMap* map, const char* key, int index, int* error)
{
	return vsapi->propGetFunc(map, key, index, error);
}


const int64_t* AC_CC AC_vsapi_propGetIntArray(const VSAPI* vsapi, const VSMap* map, const char* key, int* error)
{
	return vsapi->propGetIntArray(map, key, error);
}

const double* AC_CC AC_vsapi_propGetFloatArray(const VSAPI* vsapi, const VSMap* map, const char* key, int* error)
{
	return vsapi->propGetFloatArray(map, key, error);
}

void AC_CC AC_vsapi_getCoreInfo2(const VSAPI* vsapi, VSCore* core, VSCoreInfo* info)
{
	vsapi->getCoreInfo2(core, info);
}
