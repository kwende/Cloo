using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Cloo.Bindings
{
    [SuppressUnmanagedCodeSecurity]
    public class CL21 : CL11
    {
        [DllImport(libName, EntryPoint = "clSVMAlloc")]
        public extern static IntPtr clSVMAlloc(
            CLContextHandle context,
            ComputeMemoryFlags flags,
            int size,
            uint alignment);

        [DllImport(libName, EntryPoint = "clEnqueueSVMMap")]
        public extern static int clEnqueueSVMMap(
            CLCommandQueueHandle queue,
            bool blockingMap,
            ComputeMemoryMappingFlags mapFlags,
            IntPtr svmPtr,
            int size,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        [DllImport(libName, EntryPoint = "clEnqueueSVMUnmap")]
        public extern static int clEnqueueSVMUnmap(
            CLCommandQueueHandle queue,
            IntPtr svmPtr,
            Int32 num_events_in_wait_list,
            [MarshalAs(UnmanagedType.LPArray)] CLEventHandle[] event_wait_list,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] CLEventHandle[] new_event);

        [DllImport(libName, EntryPoint = "clSetKernelArgSVMPointer")]
        public extern static int clSetKernelArgSVMPointer(
            CLKernelHandle kernel,
            int argIndex,
            IntPtr argValue);

        [DllImport(libName, EntryPoint = "clSetKernelExecInfo")]
        public extern static int clSetKernelExecInfo(
            CLKernelHandle kernel,
            KernelExecInfo execInfo,
            int paramValueSize,
            IntPtr paramValue);

        [DllImport(libName, EntryPoint = "clSVMFree")]
        public extern static int clSVMFree(
            CLContextHandle context,
            IntPtr svmPtr);
    }
}
