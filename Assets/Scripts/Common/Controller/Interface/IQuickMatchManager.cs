using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public interface IQuickMatchManager
    {
        void QueueForQuickMatch();
        void QueueQuickMatchWithInvitation();
        void BeginQuickMatch();
        void EndQuickMatch();
    }
}
