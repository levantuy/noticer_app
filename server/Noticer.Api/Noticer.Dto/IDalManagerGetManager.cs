using System;

namespace Noticer.Dto
{
    public interface IDalManagerGetManager: IDisposable
    {
        T GetProvider<T> ( ) where T: class;
    }
}
