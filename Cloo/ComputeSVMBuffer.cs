using System;
using System.Collections.Generic;
using System.Text;

namespace Cloo
{
    /// <summary>
    /// Wraps the clSVMAlloc  / clSVMFree APIs. 
    /// </summary>
    public class ComputeSVMBuffer : IDisposable
    {
        private ComputeContext _context;
        private ComputeMemoryFlags _flags;
        private int _sizeInBytes;
        private IntPtr _memory;

        /// <summary>
        /// Instantiates a new SVM buffer. 
        /// </summary>
        public unsafe ComputeSVMBuffer(ComputeContext context, ComputeMemoryFlags memoryFlags, int sizeInBytes)
        {
            _context = context;
            _flags = memoryFlags;
            _sizeInBytes = sizeInBytes;

            _memory = Cloo.Bindings.CL21.clSVMAlloc(
                context.Handle, memoryFlags, sizeInBytes, 4096);

            if (_memory == IntPtr.Zero)
            {
                throw new Exception("Alloc failed.");
            }
        }

        /// <summary>
        /// Finalizer. 
        /// </summary>
        ~ComputeSVMBuffer()
        {
            InnerDispose(true); 
        }

        /// <summary>
        /// Implements IDisposable.
        /// </summary>
        public void Dispose()
        {
            InnerDispose(false); 
        }

        /// <summary>
        /// Generic IDisposable. 
        /// </summary>
        private void InnerDispose(bool fromGC)
        {
            if (!fromGC)
            {
                GC.SuppressFinalize(this);
            }

            Cloo.Bindings.CL21.clSVMFree(
                _context.Handle, _memory);
        }
    }
}
