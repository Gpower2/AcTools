# Microsoft Developer Studio Project File - Name="TCPDeliver" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Dynamic-Link Library" 0x0102

CFG=TCPDeliver - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "TCPDeliver.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "TCPDeliver.mak" CFG="TCPDeliver - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "TCPDeliver - Win32 Release" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE "TCPDeliver - Win32 Debug" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "TCPDeliver - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MT /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /D "_USRDLL" /D "TCPDELIVER_EXPORTS" /YX /FD /c
# ADD CPP /nologo /MT /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_WINDOWS" /D "_MBCS" /D "_USRDLL" /D "TCPDELIVER_EXPORTS" /YX /FD /c
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x417 /d "NDEBUG"
# ADD RSC /l 0x417 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /dll /machine:I386
# ADD LINK32 nafxcw.lib lzo/release/lzo.lib zlib/lib/zlibstat.lib ws2_32.lib kernel32.lib user32.lib /nologo /dll /incremental:yes /map /machine:I386 /nodefaultlib:"libc"
# Begin Special Build Tool
SOURCE="$(InputPath)"
PostBuild_Cmds=..\..\..\distrib\upx -9 release\TCPDeliver.dll
# End Special Build Tool

!ELSEIF  "$(CFG)" == "TCPDeliver - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE CPP /nologo /MTd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_MBCS" /D "_USRDLL" /D "TCPDELIVER_EXPORTS" /YX /FD /GZ /c
# ADD CPP /nologo /G6 /MTd /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_WINDOWS" /D "_MBCS" /D "_USRDLL" /D "TCPDELIVER_EXPORTS" /FR /YX /FD /GZ /c
# ADD BASE MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD MTL /nologo /D "_DEBUG" /mktyplib203 /win32
# ADD BASE RSC /l 0x417 /d "_DEBUG"
# ADD RSC /l 0x417 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /dll /debug /machine:I386 /pdbtype:sept
# ADD LINK32 nafxcwd.lib lzo/debug/lzo.lib zlib/lib/zlibstat.lib ws2_32.lib kernel32.lib user32.lib /nologo /dll /debug /machine:I386 /nodefaultlib:"libc" /nodefaultlib:"libcmt" /pdbtype:sept

!ENDIF 

# Begin Target

# Name "TCPDeliver - Win32 Release"
# Name "TCPDeliver - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Source File

SOURCE=.\huffman.c
# End Source File
# Begin Source File

SOURCE=.\StdAfx.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPClient.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPCommon.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPCompression.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPDeliver.cpp
# End Source File
# Begin Source File

SOURCE=.\TCPServer.cpp
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=.\alignplanar.h
# End Source File
# Begin Source File

SOURCE=.\avisynth.h
# End Source File
# Begin Source File

SOURCE=.\huffman.h
# End Source File
# Begin Source File

SOURCE=.\ServerGUICode.h
# End Source File
# Begin Source File

SOURCE=.\StdAfx.h
# End Source File
# Begin Source File

SOURCE=.\TCPClient.h
# End Source File
# Begin Source File

SOURCE=.\TCPCommon.h
# End Source File
# Begin Source File

SOURCE=.\TCPCompression.h
# End Source File
# Begin Source File

SOURCE=.\TCPServer.h
# End Source File
# Begin Source File

SOURCE=.\zlib\include\zlib.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# Begin Source File

SOURCE=.\ClientGUI.rc
# End Source File
# End Group
# End Target
# End Project
